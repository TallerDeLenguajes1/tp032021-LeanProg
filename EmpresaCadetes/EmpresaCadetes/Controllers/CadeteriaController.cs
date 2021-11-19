using EmpresaCadetes.DataBase;
using EmpresaCadetes.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace EmpresaCadetes.Controllers
{
    public class CadeteriaController : Controller
    {
        private readonly ILogger<CadeteriaController> _logger;
        private readonly IIDBSQLite dB;
        //private readonly Cadeteria micadeteria;
        //private readonly DBCadeteria db;
        //private readonly IRepositorioCadetesDB mirepo;
        //private int id = 0;
       // private int idpago = 1;

        public CadeteriaController(ILogger<CadeteriaController> logger,IIDBSQLite DB)
        {
            _logger = logger;
            dB = DB;
            _logger.LogDebug(1, "NLog injected into HomeController");

        }

        public IActionResult CargarCadetes(string nombre,string dire,string telefono)
        {
            //if (micadeteria.MisCadetes.Count==0)
            //{
            //    id = 0;
            //}
            //else
            //{
            //    id = micadeteria.MisCadetes.Count;
            //}
            
            Cadete newCadete = new Cadete(nombre,dire,telefono);
            dB.repositorioCadete.SaveCadete(newCadete);

            _logger.LogInformation("Hello, this is the Cargar Cadetes!");
            
            return View(newCadete);
        }
        public IActionResult FormularioCadete()
        {

            return View();
        }
        
        public IActionResult CadetesConPedidos()
        {

            return View(dB);
        }

        public IActionResult PagarCadete(int idCadete)
        {

            //string fechaActual=DateTime.Now.ToString();
            //float suma = 0;
            //Cadete micadete = micadeteria.MisCadetes.Where(cade => cade.Id == idCadete).First();
            //if (ControlEntregado(micadete.Listapedidos))
            //{
            //    foreach (var pedido in micadete.Listapedidos)
            //    {
            //        if (pedido.Estado == "ENTREGADO")
            //        {
            //            suma = 100 + suma;
            //            micadeteria.MisPedidos.RemoveAll(x=>x.Numero==pedido.Numero); 
            //        }
            //    }
            //    Pago nuevoPago = new Pago(fechaActual, micadete.Nombre, suma,idpago);
            //    db.SavePago(nuevoPago);
            //    micadeteria.MisPagos.Add(nuevoPago);
            //    //borroPedidodelcadete
            //    micadete.Listapedidos.RemoveAll(x=>x.Estado=="ENTREGADO");
            //    //actualizo bd
            //    db.ModificarListaCadeteApedido(micadeteria.MisCadetes);
            //    //actualizo bd
            //    db.ModificarEstadoPedido(micadeteria.MisPedidos);
            //   idpago++;
                
            //}

            return View(dB);

        }
        private bool ControlEntregado(List<Pedidos> CadetesPedidos)
        {
            bool resultado = false;
            foreach (var item in CadetesPedidos)
            {
                if (item.Estado == "ENTREGADO")
                {
                    resultado = true;

                }
            }
            return resultado;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            List<Cadete> miscadtes= dB.repositorioCadete.ReadCadetes();
            return View(miscadtes);
        }
        public IActionResult EliminarCadete(int idCadete)
        {
            //Cadete miCadete = micadeteria.MisCadetes.Where(cad => cad.Id == idCadete).First();
            //micadeteria.MisCadetes.Remove(miCadete);
            //db.DeleteCadetes(miCadete.Id);
            dB.repositorioCadete.DeleteCadetes(idCadete);
            return Redirect("Index");
        }
    }
}
