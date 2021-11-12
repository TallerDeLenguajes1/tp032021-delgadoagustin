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
        private readonly RepositorioCadete repCadetes;

        public CadeteController(ILogger<CadeteController> logger, RepositorioCadete RepCadetes)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Cadete Controller");
            repCadetes= RepCadetes;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult addCadete(string nombre,string direccion,string telefono)
        {
            try
            {

                Cadete cad = new()
                {
                    Nombre = nombre,
                    Direccion = direccion,
                    Telefono = telefono,
                    Id = repCadetes.maxID()+1
                };
                repCadetes.añadirCadete(cad);
                _logger.LogInformation("Usuario Id: {0} Creado", cad.Id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error al Agregar Cadete");
                exception.ToString();
            }
            

            return RedirectToAction("ListarCadetes");
        }
        public IActionResult deleteCadete(int id_cad)
        {
            try
            {
                repCadetes.borrarCadete(id_cad);
                _logger.LogInformation("Usuario Id: {0} Borrado", id_cad);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error al Borrar Cadete");
                exception.ToString();
            }

            return RedirectToAction("ListarCadetes");
        }


        public IActionResult addPedido(int numero, string observacion, string estado, int cad_id, int id_c, string nombre_c, string direccion_c, string telefono_c)
        {
            try
            {
                Pedido ped = new Pedido(numero, observacion, estado, id_c, nombre_c, direccion_c, telefono_c);
                //baseDeDatos.cadeteria.listaCadetes.Find(x => x.Id == cad_id).agregarPedido(ped);
                //baseDeDatos.GuardarCadeteria();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error al Agregar Pedido");
                exception.ToString();
            }

            return RedirectToAction("ListarCadetes");
        }

        public IActionResult updateCadete(int id_cad,string nombre,string direccion,string telefono)
        {
            try
            {
                Cadete cad = new()
                {
                    Nombre = nombre,
                    Direccion = direccion,
                    Telefono = telefono,
                    Id = id_cad
                };
                repCadetes.modificarCadete(cad);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

            return RedirectToAction("ListarCadetes");
    }

        public IActionResult AgregarCadete()
        {
            return View();
        }

        public IActionResult ModificarCadete(int id_cad)
        {
            Cadete cadeteAModificar = repCadetes.cadetePorID(id_cad);
            return View(cadeteAModificar);
        }


        public IActionResult AgregarPedido()
        {
            return View(repCadetes.ListaCadetes());
        }
        public IActionResult ListarCadetes()
        {
            return View(repCadetes.ListaCadetes());
        }
        public IActionResult ListarPedidos(int id_cad)
        {
            return View(repCadetes.cadetePorID(id_cad).ListadoPedidos);
        }

    }
}
