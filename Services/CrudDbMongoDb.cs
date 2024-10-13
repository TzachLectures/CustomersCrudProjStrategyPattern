using CustomersCrudProj.Db;
using CustomersCrudProj.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersCrudProj.Services
{
    internal class CrudDbMongoDb:ICrudOperations
    {
        private readonly MongoDbContext _mongoDbContext;

        public CrudDbMongoDb()
        {
            _mongoDbContext = new MongoDbContext();
        }

        public void PrintAllCustomers()
        {
            List<Customer> customers = _mongoDbContext.Customers.Find(customer => true).ToList();
            foreach (Customer c in customers)
            {
                Console.WriteLine(c);
            }
        }

        public void PrintCustomerById(string id)
        {
            Customer customer = _mongoDbContext.Customers.Find(customer => customer.CID==id).FirstOrDefault();
            Console.WriteLine(customer);
        }

        public void CreateNewCustomer(Customer customer)
        {
            _mongoDbContext.Customers.InsertOne(customer);

        }

        public void EditCustomerById(string id, Customer newCustomer)
        {
            //option 1 - replace

            //Customer customer = _mongoDbContext.Customers.Find(c => c.CID == id).FirstOrDefault();
            //if (customer != null)
            //{
            //    newCustomer._id = customer._id;
            //    _mongoDbContext.Customers.ReplaceOne(c => c.CID == id, newCustomer);
            //}
            //else
            //{
            //    Console.WriteLine("Customer wasn't found");
            //}


            //option 2 - update field by field

            var filter = Builders<Customer>.Filter.Eq(customer => customer.CID, id);

            var update = Builders<Customer>.Update
                .Set(customer => customer.CName, newCustomer.CName)
                .Set(customer => customer.ContactName, newCustomer.ContactName)
                .Set(customer => customer.ContactTitle, newCustomer.ContactTitle)
                .Set(customer => customer.Address, newCustomer.Address)
                .Set(customer => customer.City, newCustomer.City)
                .Set(customer => customer.Region, newCustomer.Region)
                .Set(customer => customer.PostalCode, newCustomer.PostalCode)
                .Set(customer => customer.Country, newCustomer.Country)
                .Set(customer => customer.Phone, newCustomer.Phone)
                .Set(customer => customer.Fax, newCustomer.Fax)
                .Set(customer => customer.CType, newCustomer.CType);

            var result2 = _mongoDbContext.Customers.UpdateOne(filter, update);


            Console.WriteLine("Customer updated successfully.");
        }

        public void DeleteCustomerById(string id)
        {
            DeleteResult result = _mongoDbContext.Customers.DeleteOne(c => c.CID == id);
            if (result.DeletedCount > 0) 
            {
                Console.WriteLine("Customer deleted successfully");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }

        }
    }
}
