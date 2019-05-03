using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TDrink
    {
        public TDrink()
        {
            TShopDrink = new HashSet<TShopDrink>();
        }

        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public double Price { get; set; }
        public int ParentDrinkId { get; set; }
        public int? SizeId { get; set; }
        public int? IngredientId { get; set; }

        public virtual TIngredient Ingredient { get; set; }
        public virtual TSize Size { get; set; }
        public virtual ICollection<TShopDrink> TShopDrink { get; set; }
    }
}
