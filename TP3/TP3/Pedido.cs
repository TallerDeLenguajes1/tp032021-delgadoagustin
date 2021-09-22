using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    public class Pedido
    {
        int numero;
        string obs;
        Cliente cliente;
        string estado;

        public int Numero { get => numero; set => numero = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }

        public Pedido(int n,string o,string e,int id_c,string nombre_c, string direccion_c, string telefono_c)
        {
            numero = n;
            obs = o;
            estado = e;
            cliente = new Cliente(id_c, nombre_c, direccion_c, telefono_c);
        }
    }
}
