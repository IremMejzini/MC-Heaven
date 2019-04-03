using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public float Price { get; set; }
        public int ParentDrinkID { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Ingredian> Ingredians { get; set; }
    }
}
