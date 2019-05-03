using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TCoupon
    {
        public TCoupon()
        {
            TOrder = new HashSet<TOrder>();
        }

        public int CouponId { get; set; }
        public string TypeCoupon { get; set; }

        public virtual ICollection<TOrder> TOrder { get; set; }
    }
}
