using AutoMapper;
using EmpresaCadetes.DataBase;
using EmpresaCadetes.Entidades;
using EmpresaCadetes.ViewModels;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper mapper;

        //private readonly Cadeteria micadeteria;
        //private readonly DBCadeteria db;
        //private readonly IRepositorioCadetesDB mirepo;
        //private int id = 0;
        // private int idpago = 1;

        public CadeteriaController(ILogger<CadeteriaController> logger,IIDBSQLite DB, IMapper mapper)
        {
            _logger = logger;
            dB = DB;
            this.mapper = mapper;
            _logger.LogDebug(1, "NLog injected into HomeController");

        }

        //public IActionResult CargarCadetes(string nombre,string dire,string telefono)
        //{
           

        //    Cadete newCadete = new Cadete(nombre, dire, telefono);
        //    dB.repositorioCadete.SaveCadete(newCadete);

        //    _logger.LogInformation("Hello, this is the Cargar Cadetes!");



        //    //try
        //    //{
        //    //    Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
        //    //    var UsuarioMV = mapper.Map<UsuarioViewModel>(user);

        //    //    if (UsuarioMV.Nombreusuario != null)
        //    //    {
        //    //        var CadeteVM = new CadeteAltaViewModel();
        //    //        CadeteVM. = UsuarioMV;
        //    //        return View(CadeteVM);
        //    //    }
        //    //    else
        //    //    {
        //    //        return RedirectToAction("Error");
        //    //    }

        ////}
        ////    catch (Exception)
        ////    {
        ////        return Redirect("~/Usuario/Login");
        ////    }

        //    return View(newCadete);
        //}

        public IActionResult FormularioCadete()
        {
            try
            {
                Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
                var UsuarioMV = mapper.Map<UsuarioViewModel>(user);
                var CadeteVM= new CadeteAltaViewModel();
                if (UsuarioMV.Nombreusuario != null)
                {
                    return View(new Tuple<CadeteAltaViewModel, UsuarioViewModel>(CadeteVM, UsuarioMV));
                }
                else
                {
                    return Redirect("~/Usuario/Login");
                }
            }
            catch (Exception)
            {
                return Redirect("~/Usuario/Login");
            }

           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioCadete(CadeteAltaViewModel cadeteAltaVM)
        {
            try
            {
                Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
                var UsuarioMV = mapper.Map<UsuarioViewModel>(user);
                if (UsuarioMV!=null && ModelState.IsValid)
                {
                    Cadete newCadete = mapper.Map<Cadete>(cadeteAltaVM);
                    dB.repositorioCadete.SaveCadete(newCadete);// se guarda en SQLITE
                    dB.RepositorioCadetesJson.SaveCadete(newCadete); // se guarda en json
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            catch (Exception)
            {
                return Redirect("~/Usuario/Login");
              
            }
        }
        
        public IActionResult ModificarCadete(int idcadete,string nombre,string dire, string telefono)
        {
            Cadete cadete= new Cadete(nombre,dire,telefono);
            cadete.Id= idcadete;
            dB.repositorioCadete.UpdateCadete(cadete);
            return View(dB);
        }
        public IActionResult FormularioAModificar(int idcadete)
        {
            try
            {
                Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
              
                var userVM=mapper.Map<UsuarioViewModel>(user);
                if (userVM.Nombreusuario!=null)
                {
                    Cadete cadete = dB.repositorioCadete.GetCadeteById(idcadete);
                    cadete.Id = idcadete;
                    var cadeteVM = mapper.Map<CadeteViewModel>(cadete);
                    CadeteModificarViewModel cadeteModificarViewModel = new CadeteModificarViewModel();
                    return View(new Tuple<CadeteModificarViewModel, CadeteViewModel, UsuarioViewModel>(cadeteModificarViewModel, cadeteVM, userVM));
                }
                else
                {
                    return RedirectToAction("Error");
                }
                
            }
            catch (Exception)
            {

                return Redirect("~/Usuario/Login");
            }
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioAModificar(CadeteModificarViewModel cadeteVM)
        {
            try
            {
                Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
                var userVM = mapper.Map<UsuarioViewModel>(user);
                if (userVM.Nombreusuario!= null)
                {
                    
                    var cadeteAmodificar= mapper.Map<Cadete>(cadeteVM);
                    dB.repositorioCadete.UpdateCadete(cadeteAmodificar);
                    return Redirect("~/Cadeteria");
                }
                else
                {
                    return RedirectToAction("Error");
                }

            }
            catch (Exception)
            {

                return Redirect("~/Usuario/Login");
            }

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
        //private bool ControlEntregado(List<Pedidos> CadetesPedidos)
        //{
        //    bool resultado = false;
        //    foreach (var item in CadetesPedidos)
        //    {
        //        if (item.Estado == "ENTREGADO")
        //        {
        //            resultado = true;

        //        }
        //    }
        //    return resultado;
        //}
        public IActionResult Index()
        {
            //_logger.LogInformation("Hello, this is the index!");
            //List<Cadete> miscadtes= dB.repositorioCadete.ReadCadetes();
            //return View(miscadtes);
            try
            {
                Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
                var UsuarioMV = mapper.Map<UsuarioViewModel>(user);
                var CadetesMV = mapper.Map<List<CadeteViewModel>>(dB.repositorioCadete.ReadCadetes());
                if (UsuarioMV.Nombreusuario != null)
                {
                    return View(new Tuple<List<CadeteViewModel>, UsuarioViewModel>(CadetesMV, UsuarioMV));
                }
                else
                {
                    return Redirect("~/Usuario/Login");
                }
            }
            catch (Exception)
            {
                return Redirect("~/Usuario/Login");
            }
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
