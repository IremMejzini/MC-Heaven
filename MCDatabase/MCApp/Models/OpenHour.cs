using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCApp.Models
{
    public class OpenHour
    {
        public int OpenHourID { get; set; }
        public string FromO { get; set; }
        public string ToO { get; set; }
        public int IsSunday { get; set; }
        public int IsSaturday { get; set; }
    }
}
