using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    public class Base
    {
        public Cadeteria cadeteria { get; set; }

        public Base()
        {
            cadeteria = new();
        }
    }
}
