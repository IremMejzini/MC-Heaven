using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TReceive
    {
        public TReceive()
        {
            TOrderDetail = new HashSet<TOrderDetail>();
        }

        public int ReceiveId { get; set; }
        public int? ShopId { get; set; }
        public int? OrderId { get; set; }
        public int? PaymentMid { get; set; }

        public virtual TOrder Order { get; set; }
        public virtual TPaymentMethod PaymentM { get; set; }
        public virtual TShop Shop { get; set; }
        public virtual ICollection<TOrderDetail> TOrderDetail { get; set; }
    }
}
