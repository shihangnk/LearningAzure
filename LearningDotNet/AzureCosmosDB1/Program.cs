using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AzureCosmosDB1.Entities;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.Azure.Storage; // Namespace for StorageAccounts
using Microsoft.Azure.CosmosDB.Table;
using Microsoft.Azure.CosmosDB.Table.Queryable;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.Win32;

// Namespace for Table storage types

namespace AzureCosmosDB1
{
    class Program
    {
        private static long _counter = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
        private static CloudTable _table;

        static void Main(string[] args)
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            _table = tableClient.GetTableReference("people");

            var obj = new Program();

//            obj.deleteTable();

            // Create the table if it doesn't exist.
  //          Console.Out.WriteLine("Wait 10 seconds for table to be deleted from server");
    //        Thread.Sleep(10000);
 //           _table.CreateIfNotExists();

            //          obj.insert();


            /*
                        for (int i = 0; i < 50; i++)
                        {
                            obj.batchInsert();
                        }
            */
            //            obj.getPagedRecords();

//            obj.insertDifferentEntityTypesInSameTable();
            obj.retrieveDifferentEntityTypes();

            //  obj.retrieveARangeOfEntitiesInAPartition();
            /*
                        obj.retrieveASingleEntity(new Tuple<string, string>("Mike", "Jordan"));
            */
            // obj.replaceAnEntity();

            //obj.insertOrReplace();
            //obj.conflict();
            //            obj.insertOrMerge();
            //obj.retrieveSubsetOfEntityProperties();
            //            obj.deleteEntity();
            //obj.deleteTable();
        }

        private void insert()
        {
            var insertOperation = TableOperation.Insert(new CustomerEntity("Mike" + (_counter++), "Jordan", "mike@hotmail.com", "123456"));
            _table.Execute(insertOperation);
        }

        private void insert(CustomerEntity entity)
        {
            _table.Execute(TableOperation.Insert(entity));
        }

        private void insertDifferentEntityTypesInSameTable()
        {
            insert(new CustomerEntity("firstName", "lastName", "email", "phoneNumber"));
            insert(new MyCustomerEntity("firstName", "lastName1", "email111", "phoneNumber1111", "Canada"));
        }

        private void retrieveDifferentEntityTypes()
        {
            string filter = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "firstName"),
                TableOperators.And,
                TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, "last"),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, "m")
                )
            );
            // one query method
            TableQuery<DynamicTableEntity> entityQuery = new TableQuery<DynamicTableEntity>().Where(filter);
            var employees = _table.ExecuteQuery(entityQuery);
            foreach (var dynamicTableEntity in employees)
            {
                EntityProperty entityTypeProperty;
                if (dynamicTableEntity.Properties.TryGetValue("Country", out entityTypeProperty))
                {
                    Console.Out.WriteLine("------find property Country with entityTypeProperty.StringValue [" + entityTypeProperty.StringValue + "]");
                    if (entityTypeProperty.StringValue == "Canada")
                    {
                        // Use entityTypeProperty, RowKey, PartitionKey, Etag, and Timestamp
                        Console.Out.WriteLine("-------[" + entityTypeProperty.StringValue + "]");
                    }
                }
            }

            // another query method, this is better for less code
            IEnumerable<DynamicTableEntity> entities = _table.ExecuteQuery(entityQuery);
            foreach (var e in entities)
            {
                EntityProperty entityTypeProperty;
                if (e.Properties.TryGetValue("Country", out entityTypeProperty))
                {
                    Console.Out.WriteLine("find property Country with entityTypeProperty.StringValue ["+ entityTypeProperty.StringValue+"]");
                    if (entityTypeProperty.StringValue == "Canada")
                    {
                        // Use entityTypeProperty, RowKey, PartitionKey, Etag, and Timestamp
                        Console.Out.WriteLine("["+ entityTypeProperty.StringValue+"]");
                    }
                }
            }
        }

        private void batchInsert()
        {
            TableBatchOperation batchOperation = new TableBatchOperation();

            for (int i = 0; i < 100; i++)
            {
                Console.Out.WriteLine(_counter);
                batchOperation.Insert(new CustomerEntity("Mike", "Jordan" + (_counter++), "mike@hotmail.com", "12345"));
            }

            _table.ExecuteBatch(batchOperation);
        }

        private void retrieveARangeOfEntitiesInAPartition()
        {
            // Query with Fluent API
            var rangeQuery = new TableQuery<CustomerEntity>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Mike"),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, "Jordan16")));

            var result = _table.ExecuteQuery(rangeQuery);
            Console.Out.WriteLine("" + result.Count());

            foreach (var item in result)
            {
                // Note: result.Count() takes time, don't call it in loop.
                Console.Out.WriteLine("|"+item.PartitionKey+"|"+item.RowKey+"|"+item.Email+"|"+item.PhoneNumber+"|");
            }


            Console.Out.WriteLine("-----------------------------------------------------------");

            // Query with LINQ
            TableQuery<CustomerEntity> employeeQuery = _table.CreateQuery<CustomerEntity>();
            var query = (from employee in employeeQuery
                where employee.PartitionKey == "Mike" &&
                      employee.RowKey.CompareTo("Jordan16") <= 0
                select employee).AsTableQuery();
            var employees = query.Execute();
            Console.Out.WriteLine("" + employees.Count());
/*
            foreach (var item in employees)
            {
                Console.Out.WriteLine("" + employees.Count() + "|" + item.PartitionKey + "|" + item.RowKey + "|" + item.Email + "|" + item.PhoneNumber + "|");
            }
*/
        }

        private CustomerEntity retrieveASingleEntity(Tuple<string, string> tuple)
        {
            var retrieve = TableOperation.Retrieve<CustomerEntity>(tuple.Item1, tuple.Item2);
            var result = _table.Execute(retrieve);

            if (result.Result == null)
            {
                Console.Out.WriteLine("failed to find entity");
                return null;
            }

            var ret = (CustomerEntity) result.Result;
            Console.Out.WriteLine("phoneNumer is "+  ret.PhoneNumber);
            return ret;
        }

        private void replaceAnEntity()
        {
            var customer = retrieveASingleEntity(new Tuple<string, string>("Mike","Jordan"));
            if (customer == null)
            {
                return;
            }

            customer.PhoneNumber = "306-216-1234";
            var update = TableOperation.Replace(customer);
            _table.Execute(update);
            Console.Out.WriteLine("customer updated");
        }

        private void insertOrReplace()
        {
            var customer = new CustomerEntity("Shi", "Sean", "seans@iqmetrix.com", "306-123-6789");
            var insertOrReplace = TableOperation.InsertOrReplace(customer);
            _table.Execute(insertOrReplace);
        }

        private void insertOrMerge()
        {
            // we pass in a null phonenumber, the table service will use the existing phonenumber.
            var customer = new CustomerEntity("Shi", "Sean", "shi_hang_nk@hotmail.com", null);
            var insertOrMerge = TableOperation.InsertOrMerge(customer);
            _table.Execute(insertOrMerge);
        }

        private void conflict()
        {
            Task t1 = Task.Run(() => { readSleepAndUpdate(1000); });

            // we will get 412 error (precondition failed) because of the optimistic concurrency check
            Task t2 = Task.Run(() => { readSleepAndUpdate(3000); });

            t1.Wait();
            t2.Wait();
        }

        private void readSleepAndUpdate(int sleepInMs)
        {
            var customer = retrieveASingleEntity(new Tuple<string, string>("Shi", "Sean"));
            if (customer == null)
            {
                return;
            }

            Thread.Sleep(sleepInMs);
            customer.PhoneNumber = "sleep "+sleepInMs+" ms";
            var update = TableOperation.Replace(customer);
            _table.Execute(update);
            Console.Out.WriteLine("sleep "+sleepInMs+" ms and customer updated");
        }

        private void retrieveSubsetOfEntityProperties()
        {
            var projectionQuery = new TableQuery<DynamicTableEntity>().Select(new string[] {"Email"});
            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => props.ContainsKey("Email") ? props["Email"].StringValue : null;
            var ret = _table.ExecuteQuery(projectionQuery, resolver, null, null);
            foreach(var item in ret)
            {
                Console.Out.WriteLine("email ["+item+"]");
            }

            // TODO: how to get two properties
/*
            projectionQuery = new TableQuery<DynamicTableEntity>().Select(new string[] { "Email", "PhoneNumber" });
            EntityResolver<string> resolver1 = (pk, rk, ts, props, etag) => props.ContainsKey("Email") ? props["Email"].StringValue : null;
            var ret1 = _table.ExecuteQuery(projectionQuery, resolver1, null, null);
            foreach (var item in ret1)
            {
                Console.Out.WriteLine("email [" + item + "]");
            }
*/

            Console.WriteLine("----------------------------------------------------");

            string filter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Mike");
            List<string> columns = new List<string>() { "Email", "PhoneNumber" };
            TableQuery<CustomerEntity> employeeQuery = new TableQuery<CustomerEntity>().Where(filter).Select(columns);

            var entities = _table.ExecuteQuery(employeeQuery);
            foreach (var e in entities)
            {
                Console.WriteLine("RowKey: {0}, EmployeeEmail: {1} phoneNumber: {2}", e.RowKey, e.Email, e.PhoneNumber);
            }
        }

        private void deleteEntity()
        {
            var customer = retrieveASingleEntity(new Tuple<string, string>("Mike", "Jordan"));
            if (customer == null)
            {
                return;
            }

            var delete = TableOperation.Delete(customer);
            _table.Execute(delete);
        }

        private void deleteTable()
        {
            _table.DeleteIfExists();
        }

        private async void getPagedRecords()
        {
            var query = new TableQuery<CustomerEntity>();
            // The default page size is 1000
            //query.TakeCount = 500;
            TableContinuationToken token = null;

            do
            {
//                var result = await _table.ExecuteQuerySegmentedAsync(query, token);
                var result = _table.ExecuteQuerySegmented(query, token);
                token = result.ContinuationToken;
                Console.Out.WriteLine("rows "+result.Results.Count);
            } while (token != null);
        }
    }
}
