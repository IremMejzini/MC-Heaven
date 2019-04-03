using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class User:BaseEntity
    {
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }

    }

}
