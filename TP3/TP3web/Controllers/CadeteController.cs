﻿using Microsoft.AspNetCore.Mvc;
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
            baseDeDatos.GuardarCadeteria();
            return RedirectToAction("ListarCadetes");
        }
        public IActionResult deleteCadete(int id_cad)
        {
            Cadete cadeteToRemove = baseDeDatos.cadeteria.listaCadetes.Single(x => x.Id == id_cad);
            baseDeDatos.cadeteria.listaCadetes.Remove(cadeteToRemove);
            baseDeDatos.GuardarCadeteria();
            return RedirectToAction("ListarCadetes");
        }


        public IActionResult addPedido(int numero, string observacion, string estado, int cad_id, int id_c, string nombre_c, string direccion_c, string telefono_c)
        {
            Pedido ped = new Pedido(numero, observacion, estado, id_c, nombre_c, direccion_c, telefono_c);
            baseDeDatos.cadeteria.listaCadetes.Find(x => x.Id == cad_id).agregarPedido(ped);
            baseDeDatos.GuardarCadeteria();
            return RedirectToAction("ListarCadetes");
        }

        public IActionResult updateCadete(int id_cad,string nombre,string direccion,string telefono)
        {
            Cadete cadeteToUpdate = baseDeDatos.cadeteria.listaCadetes.Single(x => x.Id == id_cad);
            cadeteToUpdate.Nombre = nombre;
            cadeteToUpdate.Direccion = direccion;
            cadeteToUpdate.Telefono = telefono;
            baseDeDatos.GuardarCadeteria();
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
