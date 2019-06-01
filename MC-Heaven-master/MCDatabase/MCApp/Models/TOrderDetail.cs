using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TOrderDetail
    {
        public int OrderDid { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int? OrderId { get; set; }
        public int? ReceiveId { get; set; }

        public virtual TOrder Order { get; set; }
        public virtual TReceive Receive { get; set; }
    }
}
