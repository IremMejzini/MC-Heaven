using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public float TotalPrice { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Shop> Shops { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public List<Coupon> Coupons { get; set; }
    }
}
