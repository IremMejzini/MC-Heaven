using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string FlatNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        
    }
}
