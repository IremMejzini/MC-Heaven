using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TOpenHour
    {
        public int OpenHourId { get; set; }
        public string FromO { get; set; }
        public string ToO { get; set; }
        public byte IsSunday { get; set; }
        public byte IsSaturday { get; set; }
        public int ShopId { get; set; }

        public virtual TShop Shop { get; set; }
    }
}
