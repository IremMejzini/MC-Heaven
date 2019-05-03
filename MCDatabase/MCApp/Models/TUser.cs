using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TUser
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? AddressId { get; set; }

        public virtual TAddress Address { get; set; }
    }
}
