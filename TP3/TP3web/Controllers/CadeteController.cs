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
        public IActionResult AgregarCadete()
        {
            for (int i = 0; i < 5; i++)
            {
                Cadete cl = new()
                {
                    Nombre = "Agustin",
                    Direccion = "Gorriti",
                    Telefono = "1234",
                    Id = i
                };
                baseDeDatos.cadeteria.listaCadetes.Add(cl);
            }
            return View();
        }
        public IActionResult AgregarPedido()
        {
            return View();
        }
        public IActionResult ListarCadetes()
        {
            return View();
        }
        public IActionResult ListarPedidos()
        {
            return View();
        }

    }
}
