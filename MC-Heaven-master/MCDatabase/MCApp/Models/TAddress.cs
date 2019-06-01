using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TAddress
    {
        public TAddress()
        {
            TOrder = new HashSet<TOrder>();
            TUser = new HashSet<TUser>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public virtual ICollection<TOrder> TOrder { get; set; }
        public virtual ICollection<TUser> TUser { get; set; }
    }
}
