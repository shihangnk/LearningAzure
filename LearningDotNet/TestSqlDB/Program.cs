using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var obj = new Program();
            obj.button1_Click();
//            Console.ReadKey();
        }

        private void button1_Click()
        {
            string connetionString;
            SqlConnection conn;
            connetionString = @"Server=tcp:seanshi.database.windows.net,1433;Database=seanshi_db;User ID=seanshi;Password=Abcd1234;Encrypt=true;Connection Timeout=30;";
            conn = new SqlConnection(connetionString);
            Console.WriteLine("Connection Open  step 1!");
            conn.Open();


            SqlCommand command = new SqlCommand("Select col2 from test where col1=@col1", conn);
            command.Parameters.AddWithValue("@col1", "1");
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["col2"]));
                }
            }

            Console.WriteLine("Connection Open  step 2!");
            conn.Close();
        }
    }
}
