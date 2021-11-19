using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;
using EmpresaCadetes.Models;
using NLog.Web;
using EmpresaCadetes.DataBase;

namespace EmpresaCadetes.Controllers
{
    public class PedidosController : Controller
    {
        
        private readonly IIDBSQLite DB;


        //int idpedidos=0;
        public PedidosController(IIDBSQLite DB)
        { 
            this.DB = DB;
        }
        public IActionResult AgregarPedidos(string obs,string nombrec,string direc,string telefonoc,string estado)
        {
            
            //if (cadeteria.MisPedidos.Count==0)
            //{
            //    idpedidos = 1;
            //}
            //else
            //{
            //    idpedidos = cadeteria.MisPedidos.Last().Numero + 1;
            //}

            Pedidos newPedido;
            newPedido = new Pedidos(obs, estado, nombrec, direc, telefonoc);
            DB.repositorioPedido.SavePedidos(newPedido);
            //cadeteria.MisPedidos.Add(newPedido);
            //db.SavePedidos(newPedido);
            //idpedidos++;
            return View(newPedido);
        }


        public IActionResult UpdatePedidos(int idpedido,string obs, string nombrec, string direc, string telefonoc, string estado)
        {

            Pedidos newPedido;
            newPedido = new Pedidos(obs, estado, nombrec, direc, telefonoc);
            newPedido.Numero = idpedido;
            DB.repositorioPedido.UpdatePedido(newPedido);
           
            return View(newPedido);
        }
        public IActionResult FormularioPedido()
        {
            //Vista para cargar pedidos
            return View();
        }

        public IActionResult MostrarPedidos()
        {
            //VISTA PARA MOSTRAR PEDIDOS
            List<Pedidos> pedidos = DB.repositorioPedido.ReadPedidos();
            return View(DB);
        }

        //Formulario ParaModificar el pedido
        public IActionResult FormularioModificar(int idpedido)
        {


            //< span asp - validation -for= "Nombre" class="text-danger"></span>
            Pedidos pedido= DB.repositorioPedido.GetPedidobyId(idpedido);
            

            return  View(pedido);
        }

        ////controlarPEDIDO EN CADETE
        //private bool controlarPedidosconCadetes(int idpedido)
        //{
        //    bool resultado = false;
        //    //foreach (var cade in cadeteria.MisCadetes)
        //    //{
        //    //    foreach (var pedi in cade.Listapedidos)
        //    //    {
        //    //        if (pedi.Numero == idpedido)
        //    //        {
        //    //            resultado = true;
        //    //        }
        //    //    }
        //    //}
        //    return resultado;
        //}


        //AGREGAR PEDIDO A CADETE
        public IActionResult PedidoAcadete(int idPedido,int idCadete)
        {
            //QuitarPedido(idPedido);
            // Cadete miCadete = cadeteria.MisCadetes.Where(a => a.Id == idCadete).First();

            // Pedidos unPedido = cadeteria.MisPedidos.Where(p => p.Numero == idPedido).First();
            // unPedido.Estado = "ENVIADO";
            // db.ModificarEstadoPedido(cadeteria.MisPedidos);
            // db.ModificarListaCadeteApedido(cadeteria.MisCadetes);
            // miCadete.Listapedidos.Add(unPedido);
            DB.repositorioPedido.AsignarPedidoAcadete(idPedido,idCadete);

            return Redirect("MostrarPedidos");
        }
        //Funcion quitar pedido
        //private void QuitarPedido(int idPedido)
        //{
        //    Pedidos pedido = cadeteria.MisPedidos.Where(pe => pe.Numero == idPedido).First();
        //    cadeteria.MisCadetes.ForEach(cad => cad.Listapedidos.Remove(pedido));
        //}

        public IActionResult EliminarPedido(int idPedido)
        {
            //QuitarPedido(idPedido);
            //cadeteria.MisPedidos.RemoveAll(p =>p.Numero==idPedido); //borro pedido de mi lista actual
            //db.DeletePedidos(idPedido); //borro el pedido de mi base de datos
            //db.ModificarListaCadeteApedido(cadeteria.MisCadetes); // y modifico mi lista cadetes
            DB.repositorioPedido.DeletePedidos(idPedido);
            return Redirect("MostrarPedidos");
        }
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
