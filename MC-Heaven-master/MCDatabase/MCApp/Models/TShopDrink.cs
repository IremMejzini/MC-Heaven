using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TShopDrink
    {
        public int DrinkId { get; set; }
        public int ShopId { get; set; }

        public virtual TDrink Drink { get; set; }
        public virtual TShop Shop { get; set; }
    }
}
