using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP3web.Models.ViewModels
{
    public class CadeteViewModel
    {
        int id;
        [Required]
        [StringLength(100)]
        string nombre;
        [Required]
        [StringLength(100)]
        string direccion;
        [Required]
        [StringLength(100)]
        string telefono;
        List<PedidoViewModel> listadoPedidos = new();

        public int Id { get => id; set => id = value; }
        [Required]
        [StringLength(100)]
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<PedidoViewModel> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    }
}
