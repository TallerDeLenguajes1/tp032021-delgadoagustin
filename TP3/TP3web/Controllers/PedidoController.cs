using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Microsoft.Extensions.Logging;
using NLog;
using Microsoft.AspNetCore.Http;

namespace TP3web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly RepositorioCadete repCadetes;

        public PedidoController(ILogger<PedidoController> logger, RepositorioCadete RepCadetes)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Cadete Controller");
            repCadetes = RepCadetes;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarPedido()
        {
            if (repCadetes.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                return View(repCadetes.ListaCadetes());
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult addPedido(Pedido pedido,int cad_id)
        {
            try
            {
                //baseDeDatos.cadeteria.listaCadetes.Find(x => x.Id == cad_id).agregarPedido(ped);
                //baseDeDatos.GuardarCadeteria();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error al Agregar Pedido");
            }

            return RedirectToAction("ListarCadetes");
        }

        public IActionResult ListarPedidos(int id_cad)
        {

            if (repCadetes.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                return View(repCadetes.ListarPedidoCadete(id_cad));
            }

            return RedirectToAction("Login", "Home");
        }
    }
}
