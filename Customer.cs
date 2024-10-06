using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersCrudProj
{
    internal class Customer
    {
        public string CID { get; set; }           // Customer ID
        public string CName { get; set; }         // Customer Name
        public string ContactName { get; set; }   // Contact Name
        public string ContactTitle { get; set; }  // Contact Title
        public string Address { get; set; }       // Address
        public string City { get; set; }          // City
        public string Region { get; set; }        // Region (can be null)
        public string PostalCode { get; set; }    // Postal Code
        public string Country { get; set; }       // Country
        public string Phone { get; set; }         // Phone number
        public string Fax { get; set; }           // Fax number (can be null)
        public char CType { get; set; }         // Customer Type (can be null)

        public Customer(){
            }

        public Customer(string cid, string cName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, char cType)
        {
            CID = cid;
            CName = cName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
            CType = cType;

        }

        public override string ToString()
        {
            return $"ID:{CID}, Name:{CName}, ContactName{ContactName}, ContactTitle:{ContactTitle}, Address:{Address}, City:{City}, Region:{Region}, PostalCode:{PostalCode}, Country{Country}, Phone:{Phone}, Fax:{Fax}, CustomerType{CType}";
        }
    }
}
