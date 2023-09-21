// <Snippet1>
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace TestDatabase
{
    class Program
    {
        static void Main()
        {
            string str = "Data Source=(local);Initial Catalog=Northwind;Encrypt=False;Trusted_Connection=true;";
            string qs = "Select EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address from Employees;";
            
            CreateCommand(qs, str);
        }

        private static void CreateCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandTimeout = 15;
                command.CommandType = CommandType.Text;
                command.CommandText = queryString;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                        reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[7]));
                }
            }
        }
       
    }
}