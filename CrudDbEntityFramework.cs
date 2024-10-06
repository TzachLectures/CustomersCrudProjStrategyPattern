using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersCrudProj
{
    internal class CrudDbEntityFramework
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
                Console.WriteLine(customer.CName);
            }
        }
    }
}
