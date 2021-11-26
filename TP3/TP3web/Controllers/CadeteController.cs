using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using DB;

namespace TP3web.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly IDB repositorio;

        public CadeteController(ILogger<CadeteController> logger, IDB Repositorio)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Cadete Controller");
            repositorio= Repositorio;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetString
            return View();
        }
        
        public IActionResult AgregarCadete()
                {
                    if(repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
                    {
                        return View();
                    }
            
                    return RedirectToAction("Login","Home");
                }

        [HttpPost]
        public IActionResult AgregarCadete(Cadete cadete)
        {
            try
            {
                repositorio.RepositorioCadete.AgregarCadete(cadete);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error al Agregar Cadete");
                exception.ToString();
            }
            

            return RedirectToAction("ListarCadetes");
        }

        [HttpPost]
        public IActionResult BorrarCadete(int id_cad)
        {
            try
            {
                repositorio.RepositorioCadete.BorrarCadete(id_cad);
                _logger.LogInformation("Usuario Id: {0} Borrado", id_cad);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error al Borrar Cadete");
            }

            return RedirectToAction("ListarCadetes");
        }

        [HttpPost]
        public IActionResult ModificarCadete(Cadete cadete)
        {
            try
            {
                repositorio.RepositorioCadete.ModificarCadete(cadete);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Error al Modificar cadete");
            }

            return RedirectToAction("ListarCadetes");
        }

        

        public IActionResult ModificarCadete(int id_cad)
        {
            if(repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                return View(repositorio.RepositorioCadete.CadetePorID(id_cad));
            }
            
            return RedirectToAction("Login","Home");
        }

        
        
        public IActionResult ListarCadetes()
        { 
            if(repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                return View(repositorio.RepositorioCadete.ListaCadetes());
            }
            
            return RedirectToAction("Login","Home");
        }
        

    }
}
