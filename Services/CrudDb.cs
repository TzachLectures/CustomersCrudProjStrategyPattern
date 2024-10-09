using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CustomersCrudProj.Models;

namespace CustomersCrudProj.Services
{
    internal class CrudDb : ICrudOperations
    {
        private static string connectionString = "Server=LAPTOP-M1H6FNPI\\MSSQLSERVER02;Database=Northwind;Trusted_Connection=True;";


        public void PrintAllCustomers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM customers", connection);

                using (SqlDataReader sqlDataReader = command.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(sqlDataReader["CName"]);
                    }

                }

            }
        }

        public void PrintCustomerById(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT * FROM customers WHERE CID = '{id}'", connection);

                using (SqlDataReader sqlDataReader = command.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(sqlDataReader["CName"]);
                    }

                }

            }
        }

        public void CreateNewCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = $@"INSERT INTO Customers
                        VALUES ('{customer.CID}', '{customer.CName}',
                        '{customer.ContactName}', '{customer.ContactTitle}', '{customer.Address}', 
                        '{customer.City}', '{customer.Region}', '{customer.PostalCode}',
                        '{customer.Country}', '{customer.Phone}', 
                        '{customer.Fax}', '{customer.CType}')";

                SqlCommand command = new SqlCommand(query, connection);
                int rowAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowAffected} rows affected");

            }
        }


        public void EditCustomerById(string id, Customer customer)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = $@"
                                UPDATE Customers
                                SET CName = @CName,
                                    ContactName = @ContactName,
                                    ContactTitle = @ContactTitle,
                                    Address = @Address,
                                    City = @City,
                                    Region = @Region,
                                    PostalCode = @PostalCode,
                                    Country = @Country,
                                    Phone = @Phone,
                                    Fax = @Fax,
                                    CType = @CType
                                WHERE CID = @CID;
                                ";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CName", customer.CName);
                command.Parameters.AddWithValue("@ContactName", customer.ContactName);
                command.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@City", customer.City);
                command.Parameters.AddWithValue("@Region", customer.Region);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Fax", customer.Fax);
                command.Parameters.AddWithValue("@CType", customer.CType);
                command.Parameters.AddWithValue("@CID", id);

                int rowAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowAffected} rows affected");

            }
        }

        public void DeleteCustomerById(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = $@"DELETE FROM Customers WHERE CID = '{id}';";

                SqlCommand command = new SqlCommand(query, connection);
                int rowAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowAffected} rows affected");

            }
        }

    }
}
