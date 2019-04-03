using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class Shop
    {
        public int ShopID { get; set; }
        public string NameShop { get; set; }
        public int IsDeliver { get; set; }
        public List<OpenHour> OpenHours { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
