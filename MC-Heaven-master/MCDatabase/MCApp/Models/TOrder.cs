using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TOrder
    {
        public TOrder()
        {
            TOrderDetail = new HashSet<TOrderDetail>();
            TReceive = new HashSet<TReceive>();
        }

        public int OrderId { get; set; }
        public double TotalPrice { get; set; }
        public int? AddressId { get; set; }
        public int? ShopId { get; set; }
        public int? PaymentMid { get; set; }
        public int? CouponId { get; set; }

        public virtual TAddress Address { get; set; }
        public virtual TCoupon Coupon { get; set; }
        public virtual TPaymentMethod PaymentM { get; set; }
        public virtual TShop Shop { get; set; }
        public virtual ICollection<TOrderDetail> TOrderDetail { get; set; }
        public virtual ICollection<TReceive> TReceive { get; set; }
    }
}
