using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        int id;
        string nombre;
        string direccion;
        string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Cliente(int i,string n,string d,string t)
        {
            id = i;
            nombre = n;
            direccion = d;
            telefono = t;
        }
    }
}
