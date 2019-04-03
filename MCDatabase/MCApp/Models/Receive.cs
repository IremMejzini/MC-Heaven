using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class Receive
    {
        public int ReceiveID { get; set; }
        public List<Shop> Shops { get; set; }
        public List<Order> Orders { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
