using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cadeteria
    {
        public List<Cadete> listaCadetes = new();
        public List<Pedido> listaPedidos = new();

        public Cadeteria()
        {
            listaCadetes = new List<Cadete>();
            listaPedidos = new List<Pedido>();
        }
      
    }
    
}
