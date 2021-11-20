using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cadete
    {
        int id;
        string nombre;
        string direccion;
        string telefono;
        List<Pedido> listadoPedidos = new();

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    
        public void agregarPedido(Pedido p)
        {
            listadoPedidos.Add(p);
        }
    }
}
