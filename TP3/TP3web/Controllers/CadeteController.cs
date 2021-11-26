using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using DB;
using AutoMapper;
using TP3web.Models.ViewModels;

namespace TP3web.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly IDB repositorio;
        private readonly IMapper mapper;

        public CadeteController(ILogger<CadeteController> logger, IDB Repositorio, IMapper Mapper)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Cadete Controller");
            repositorio= Repositorio;
            mapper = Mapper;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetString
            return View();
        }


        public IActionResult AgregarCadete2()
        {
            if (repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                return View(new CadeteViewModel());
            }

            return RedirectToAction("Login", "Home");
        }

        public IActionResult AgregarCadete()
        {
            if (repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                return View(new CadeteViewModel());
            }

            return RedirectToAction("Login", "Home");
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
                List<Cadete> listado = repositorio.RepositorioCadete.ListaCadetes();
                var listadoView = mapper.Map <List<CadeteViewModel>> (listado);
                return View(listadoView);
            }
            
            return RedirectToAction("Login","Home");
        }
        

    }
}
