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
            _logger.LogDebug(1, "NLog injected into Cadete Controller");
            baseDeDatos = BaseDeDatos;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult addCadete(string nombre,string direccion,string telefono)
        {
            try
            {
                int id = 0;
                if (baseDeDatos.cadeteria.listaCadetes.Count() > 0)
                {
                    id = baseDeDatos.cadeteria.listaCadetes.Max(x => x.Id) + 1;
                }

                Cadete cad = new()
                {
                    Nombre = nombre,
                    Direccion = direccion,
                    Telefono = telefono,
                    Id = id
                };
                baseDeDatos.cadeteria.listaCadetes.Add(cad);
                baseDeDatos.GuardarCadeteria();
                _logger.LogInformation("Usuario Id: {0} Creado", id);
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
                Cadete cadeteToRemove = baseDeDatos.cadeteria.listaCadetes.Single(x => x.Id == id_cad);
                baseDeDatos.cadeteria.listaCadetes.Remove(cadeteToRemove);
                baseDeDatos.GuardarCadeteria();
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
                baseDeDatos.cadeteria.listaCadetes.Find(x => x.Id == cad_id).agregarPedido(ped);
                baseDeDatos.GuardarCadeteria();
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
                Cadete cadeteToUpdate = baseDeDatos.cadeteria.listaCadetes.Single(x => x.Id == id_cad);
                cadeteToUpdate.Nombre = nombre;
                cadeteToUpdate.Direccion = direccion;
                cadeteToUpdate.Telefono = telefono;
                baseDeDatos.GuardarCadeteria();
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
            Cadete cadeteAModificar = baseDeDatos.cadeteria.listaCadetes.Single(x => x.Id == id_cad);
            return View(cadeteAModificar);
        }


        public IActionResult AgregarPedido()
        {
            return View(baseDeDatos.cadeteria.listaCadetes);
        }
        public IActionResult ListarCadetes()
        {
            return View(baseDeDatos.cadeteria.listaCadetes);
        }
        public IActionResult ListarPedidos(int id_cad)
        {

            return View(baseDeDatos.cadeteria.listaCadetes.Find(x => x.Id == id_cad).ListadoPedidos);
        }

    }
}
