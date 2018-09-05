namespace TestAutoFixture.model
{
    public class Model1
    {
        private string privateField;
        protected string protectedField;
        public string publicField;
        public int publicInt;

        public string toString()
        {
            return "PrivateField: ["+privateField+"]  ProtectedField["+protectedField+"] PublicField["+publicField+"] publicInt["+publicInt+"]";
        }
    }
}