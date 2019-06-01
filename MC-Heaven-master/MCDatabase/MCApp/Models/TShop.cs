using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TShop
    {
        public TShop()
        {
            TOpenHour = new HashSet<TOpenHour>();
            TOrder = new HashSet<TOrder>();
            TReceive = new HashSet<TReceive>();
            TShopDrink = new HashSet<TShopDrink>();
        }

        public int ShopId { get; set; }
        public string NameShop { get; set; }
        public byte IsDeliver { get; set; }
        public int? OpenHourId { get; set; }
        public int? AddressId { get; set; }

        public virtual ICollection<TOpenHour> TOpenHour { get; set; }
        public virtual ICollection<TOrder> TOrder { get; set; }
        public virtual ICollection<TReceive> TReceive { get; set; }
        public virtual ICollection<TShopDrink> TShopDrink { get; set; }
    }
}
