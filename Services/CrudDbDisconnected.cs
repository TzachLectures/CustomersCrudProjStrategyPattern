using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersCrudProj.Models;

namespace CustomersCrudProj.Services
{
    internal class CrudDbDisconnected : ICrudOperations
    {
        private static string connectionString = "Server=LAPTOP-M1H6FNPI\\MSSQLSERVER02;Database=Northwind;Trusted_Connection=True;";
        private DataSet _dataSet = new DataSet();

        public CrudDbDisconnected()
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM customers", connectionString))
            {
                dataAdapter.Fill(_dataSet, "customers");
            }
        }

        public void PrintAllCustomers()
        {

            DataTable customersTable = _dataSet.Tables["customers"];

            foreach (DataRow row in customersTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                    Console.WriteLine(row["CName"]);
            }

        }

        public void PrintCustomerById(string id)
        {
            DataTable customersTable = _dataSet.Tables["customers"];

            foreach (DataRow row in customersTable.Rows)
            {
                if (row["CID"].ToString() == id)
                {
                    Console.WriteLine(row["CName"]);
                    return;
                }
            }

            //DataRow[] result = customersTable.Select($"CID='{id}'");
            //if (result.Length == 0)
            //{
            //    Console.WriteLine("Id not found");
            //    return;
            //}
            //DataRow customerById = result[0];
            //Console.WriteLine(customerById["CName"]);

        }

        public void CreateNewCustomer(Customer customer)
        {
            //first we create new customer and ADD it to the local data table 
            DataTable? customersTable = _dataSet.Tables["customers"];

            DataRow newRow = customersTable.NewRow();

            newRow["CID"] = customer.CID;
            newRow["CName"] = customer.CName;
            newRow["ContactName"] = customer.ContactName;
            newRow["ContactTitle"] = customer.ContactTitle;
            newRow["Address"] = customer.Address;
            newRow["City"] = customer.City;
            newRow["Region"] = customer.Region;
            newRow["PostalCode"] = customer.PostalCode;
            newRow["Country"] = customer.Country;
            newRow["Phone"] = customer.Phone;
            newRow["Fax"] = customer.Fax;
            newRow["CType"] = customer.CType;

            // Add the new row to the DataTable
            customersTable.Rows.Add(newRow);

            //second, we need to update the db
            UpdateDb();


        }

        public void EditCustomerById(string id, Customer customer)
        {
            DataTable? customersTable = _dataSet.Tables["customers"];
            DataRow[] result = customersTable.Select($"CID='{id}'");
            if (result.Length == 0)
            {
                Console.WriteLine("Id not found");
                return;
            }
            DataRow customerById = result[0];

            customerById["CName"] = customer.CName;
            customerById["ContactName"] = customer.ContactName;
            customerById["ContactTitle"] = customer.ContactTitle;
            customerById["Address"] = customer.Address;
            customerById["City"] = customer.City;
            customerById["Region"] = customer.Region;
            customerById["PostalCode"] = customer.PostalCode;
            customerById["Country"] = customer.Country;
            customerById["Phone"] = customer.Phone;
            customerById["Fax"] = customer.Fax;
            customerById["CType"] = customer.CType;
            UpdateDb();
        }

        public void DeleteCustomerById(string id)
        {
            DataTable? customersTable = _dataSet.Tables["customers"];
            DataRow[] result = customersTable.Select($"CID='{id}'");
            if (result.Length == 0)
            {
                Console.WriteLine("Id not found");
                return;
            }
            DataRow customerById = result[0];
            customerById.Delete();
            UpdateDb();
        }

        public void UpdateDb()
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM customers", connectionString))
            {
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(_dataSet, "customers");
            }
        }


    }
}
