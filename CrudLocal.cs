using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersCrudProj
{
    internal class CrudLocal :ICrudOperations
    {
        public static List<Customer> customers = new List<Customer>();

        public void PrintAllCustomers ()
        {
            foreach (Customer c in customers)
            {
                Console.WriteLine(c);
            }
        }

        public void PrintCustomerById(string id)
        {
            Customer c = customers.FirstOrDefault(c=>c.CID == id);
            Console.WriteLine(c);
        }

        public void CreateNewCustomer (Customer customer)
        {
            customers.Add(customer);
            Console.WriteLine("New customer has been added");
        }

        public void EditCustomerById(string id, Customer newCustomer)
        {
            int indexOfCustomerToEdit = customers.FindIndex(c => c.CID == id);
            customers[indexOfCustomerToEdit] = newCustomer;
            Console.WriteLine("customer has been updated");
        }

        public void DeleteCustomerById(string id)
        {
            Customer customerToDelete = customers.FirstOrDefault(c => c.CID == id);
            customers.Remove(customerToDelete);
        }

    }
}
