using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    public class Cadeteria
    {
        string nombre;
        List<Cadete> listaCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    }
}
