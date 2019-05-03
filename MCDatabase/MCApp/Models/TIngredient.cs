using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TIngredient
    {
        public TIngredient()
        {
            TDrink = new HashSet<TDrink>();
        }

        public int IngredientId { get; set; }
        public string NameIngredient { get; set; }
        public double Price { get; set; }

        public virtual ICollection<TDrink> TDrink { get; set; }
    }
}
