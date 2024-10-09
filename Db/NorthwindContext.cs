using CustomersCrudProj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersCrudProj.Db
{
    internal class NorthwindContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-M1H6FNPI\\MSSQLSERVER02;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
