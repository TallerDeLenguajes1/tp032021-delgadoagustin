using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP3web.Models.ViewModels
{
    public class PedidoViewModel
    {
        int numero;
        [Required]
        [StringLength(100)]
        string obs;
        ClienteViewModel cliente;
        [Required]
        [StringLength(100)]
        string estado;

        public int Numero { get => numero; set => numero = value; }
        public string Obs { get => obs; set => obs = value; }
        public ClienteViewModel Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }

        public PedidoViewModel() { }

        public PedidoViewModel(int n, string o, string e, int id_c, string nombre_c, string direccion_c, string telefono_c)
        {
            numero = n;
            obs = o;
            estado = e;
            cliente = new ClienteViewModel(id_c, nombre_c, direccion_c, telefono_c);
        }
    }
}
