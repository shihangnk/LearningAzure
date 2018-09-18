
using Microsoft.Azure.CosmosDB.Table;

namespace AzureCosmosDB1.Entities
{
    public class CustomerEntity : TableEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerEntity(string lastName, string firstName, string email, string phoneNumber)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public CustomerEntity() { }
    }
}