using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP3web.Models.ViewModels
{
    public class ClienteViewModel
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

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public ClienteViewModel() { }

        public ClienteViewModel(int i, string n, string d, string t)
        {
            id = i;
            nombre = n;
            direccion = d;
            telefono = t;
        }
    }
}
