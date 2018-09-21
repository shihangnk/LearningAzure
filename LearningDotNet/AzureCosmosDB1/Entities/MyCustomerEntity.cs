namespace AzureCosmosDB1.Entities
{
    public class MyCustomerEntity : CustomerEntity
    {
        public string Country { get; set; }

        public MyCustomerEntity() : base()
        {
        }

        public MyCustomerEntity(string lastName, string firstName, string email, string phoneNumber, string country) : 
            base(lastName, firstName, email, phoneNumber)
        {
            Country = country;
        }
    }
}