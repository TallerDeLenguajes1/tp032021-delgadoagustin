using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using TP3web.Models;

namespace TP3web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositorioCadete repCadetes;

        public HomeController(ILogger<HomeController> logger, RepositorioCadete RepCadete)
        {
            _logger = logger;
            repCadetes = RepCadete;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Auth(string usuario,string pass)
        {
            if(repCadetes.existeUsuario(usuario,pass)){
                HttpContext.Session.SetString("usuario", usuario);
                HttpContext.Session.SetString("pass", pass);
                return RedirectToAction("ListarCadetes","Cadete");
            }
            
            return RedirectToAction("Login");
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
