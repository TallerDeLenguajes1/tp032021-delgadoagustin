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

        public CadeteController(ILogger<CadeteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Cliente> Clientes = new();
            for (int i = 0; i < 5; i++)
            {
                Cliente cl = new()
                {
                    Nombre = "Agustin",
                    Direccion = "Gorriti",
                    Telefono = "1234",
                    Id = i
                };
                Clientes.Add(cl);
            }
            
           
            return View(Clientes);
        }
    }
}
