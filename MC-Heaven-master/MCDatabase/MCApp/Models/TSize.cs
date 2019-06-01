using System;
using System.Collections.Generic;

namespace MCApp.Models
{
    public partial class TSize
    {
        public TSize()
        {
            TDrink = new HashSet<TDrink>();
        }

        public int SizeId { get; set; }
        public string TypeSize { get; set; }

        public virtual ICollection<TDrink> TDrink { get; set; }
    }
}
