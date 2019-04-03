using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MCApp.Models
{
    public class MCContext:DbContext
    {
        //constructor
        public MCContext(DbContextOptions<MCContext> options):base(options)
        {

            
        }
    }
}
