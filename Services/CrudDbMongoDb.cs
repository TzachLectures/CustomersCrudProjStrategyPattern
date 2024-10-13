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
           
        }

        public void CreateNewCustomer(Customer customer)
        {
            _mongoDbContext.Customers.InsertOne(customer);
        }

        public void EditCustomerById(string id, Customer newCustomer)
        {
           
        }

        public void DeleteCustomerById(string id)
        {
           
        }
    }
}
