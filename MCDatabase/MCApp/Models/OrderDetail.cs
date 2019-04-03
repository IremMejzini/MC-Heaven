using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class OrderDetail
    {
        public int OrderDID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public List<Order> Orders { get; set; }
        public List<Receive> Receives { get; set; }
    }
}
