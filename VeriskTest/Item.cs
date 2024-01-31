using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriskTest
{   
    public class Item {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
