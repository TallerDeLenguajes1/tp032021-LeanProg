﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;
using NLog.Web;

namespace EmpresaCadetes.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly DBCadeteria db;
        private readonly Cadeteria cadeteria;
        static int idpedidos=1;
        public PedidosController(ILogger<PedidosController> logger,DBCadeteria Db,Cadeteria Cadeteria)
        {
            _logger = logger;
              db = Db;
            cadeteria = Cadeteria;
            _logger.LogDebug(1, "NLog injected into Pedidos Controller");

        }
        public IActionResult AgregarPedidos(string obs,string nombrec,string direc,string telefonoc,string estado)
        {
            Pedidos newPedido;
            if (nombrec!=null&& obs!=null) { 
            newPedido = new Pedidos(idpedidos,obs,estado,nombrec,direc,telefonoc);   
            cadeteria.MisPedidos.Add(newPedido);
            idpedidos++;
            }
            else
            {
                newPedido = new Pedidos(0, "0", "0", "0", "0","0");
            }

            return View(newPedido);
        }
        public IActionResult FormularioPedido()
        {
            //_logger.LogInformation("Hello, this is the Cargar Cadetes!");
            return View();
        }

        public IActionResult MostrarPedidos()
        {
  
            return View(cadeteria);
        }
        public IActionResult PedidoAcadete(int idPedido,int idCadete)
        {
           QuitarPedido(idPedido);
            Cadete miCadete = cadeteria.MisCadetes.Where(a => a.Id == idCadete).First();
     
            Pedidos unPedido = cadeteria.MisPedidos.Where(p => p.Numero == idPedido).First();

            miCadete.Listapedidos.Add(unPedido);
       
            return Redirect("MostrarPedidos");
        }
        //Funcion quitar pedido tal cual en el video y no se aplica a mi proyecto
        private void QuitarPedido(int idPedido)
        {
            Pedidos pedido = cadeteria.MisPedidos.Where(pe => pe.Numero == idPedido).First();
            cadeteria.MisCadetes.ForEach(cad => cad.Listapedidos.Remove(pedido));
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            return View();
        }
    }
}
