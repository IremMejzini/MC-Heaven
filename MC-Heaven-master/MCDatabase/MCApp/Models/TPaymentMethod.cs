using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TPaymentMethod
    {
        public TPaymentMethod()
        {
            TOrder = new HashSet<TOrder>();
            TReceive = new HashSet<TReceive>();
        }

        public int PaymentMid { get; set; }
        public string TypePayment { get; set; }

        public virtual ICollection<TOrder> TOrder { get; set; }
        public virtual ICollection<TReceive> TReceive { get; set; }
    }
}
