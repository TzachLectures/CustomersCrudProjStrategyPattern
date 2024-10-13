using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersCrudProj.Models
{
    internal class Customer
    {

        [NotMapped]
        public BsonObjectId _id { get; set; }

        [Key]
       // [BsonId]
        public string CID { get; set; }           
        public string? CName { get; set; }         
        public string? ContactName { get; set; }   
        public string? ContactTitle { get; set; }  
        public string? Address { get; set; }       
        public string? City { get; set; }          
        public string? Region { get; set; }        
        public string? PostalCode { get; set; }    
        public string? Country { get; set; }     
        public string? Phone { get; set; }         
        public string? Fax { get; set; }          
        public char? CType { get; set; }        

        public Customer()
        {
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
