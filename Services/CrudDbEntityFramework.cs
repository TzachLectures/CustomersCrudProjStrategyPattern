using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CustomersCrudProj.Db;
using CustomersCrudProj.Models;

namespace CustomersCrudProj.Services
{
    internal class CrudDbEntityFramework :ICrudOperations
    {
        private readonly NorthwindContext _context;

        public CrudDbEntityFramework()
        {
            _context = new NorthwindContext();
        }

        public void PrintAllCustomers()
        {
            List<Customer> customers = _context.Customers.ToList();
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
        public void PrintCustomerById(string id)
        {
            Customer? c = _context.Customers.FirstOrDefault((customer) => customer.CID == id);
            if (c == null)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine(c);
        }

        public void CreateNewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void EditCustomerById(string id, Customer newCustomer)
        {
            Customer? customer = _context.Customers.FirstOrDefault((c) => c.CID == id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found");
                return;
            }

            //solution 1
            // _context.Entry(customer).CurrentValues.SetValues(newCustomer);

            //solution 2
            //foreach (PropertyInfo property in typeof(Customer).GetProperties())
            //{
            //    var newValue = property.GetValue(newCustomer);
            //    property.SetValue(customer, newValue);
            //}

            //solution 3
            customer.CName = newCustomer.CName;
            customer.ContactName = newCustomer.ContactName;
            customer.ContactTitle = newCustomer.ContactTitle;
            customer.Address = newCustomer.Address;
            customer.City = newCustomer.City;
            customer.Region = newCustomer.Region;
            customer.PostalCode = newCustomer.PostalCode;
            customer.Country = newCustomer.Country;
            customer.Phone = newCustomer.Phone;
            customer.Fax = newCustomer.Fax;
            customer.CType = newCustomer.CType;

            _context.SaveChanges();
        }

        public void DeleteCustomerById(string id)
        {
            Customer? c = _context.Customers.FirstOrDefault((customer) => customer.CID == id);
            if (c == null)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            _context.Customers.Remove(c);
            _context.SaveChanges();
        }


    }
}
