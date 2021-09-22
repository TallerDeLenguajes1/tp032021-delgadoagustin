using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP3;

namespace TP3web.Controllers
{
    public class CadeteController : Controller
    {
        static int _id;
        private readonly ILogger<CadeteController> _logger;
        private readonly Base baseDeDatos;

        public CadeteController(ILogger<CadeteController> logger, Base BaseDeDatos)
        {
            _logger = logger;
            baseDeDatos = BaseDeDatos;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult addCadete(string nombre,string direccion,string telefono)
        {
            Cadete cad = new()
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Id = _id++
            };
            baseDeDatos.cadeteria.listaCadetes.Add(cad);
            return RedirectToAction("ListarCadetes");
        }

        public IActionResult AgregarCadete()
        {
            return View();
        }
        public IActionResult AgregarPedido()
        {
            return View();
        }
        public IActionResult ListarCadetes()
        {
            return View(baseDeDatos.cadeteria.listaCadetes);
        }
        public IActionResult ListarPedidos()
        {
            return View(baseDeDatos.cadeteria.listaPedidos);
        }

    }
}
