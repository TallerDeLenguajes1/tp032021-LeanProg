using EmpresaCadetes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;
using EmpresaCadetes.ViewModels;
using AutoMapper;
using EmpresaCadetes.DataBase;
using Microsoft.AspNetCore.Http;

namespace EmpresaCadetes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly IIDBSQLite dB;

        public HomeController(ILogger<HomeController> logger,IMapper mapper, IIDBSQLite DB)
        {
            _logger = logger;
            this.mapper = mapper;
            dB = DB;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        public IActionResult Index()
        {
            try
            {
                Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
                var UserVm=mapper.Map<UsuarioViewModel>(user);
                if (UserVm.Nombreusuario !=null)
                {
                    return View(UserVm);
                }
                else
                {
                    return Redirect("~/Usuario/Login");
                }
            }
            catch (Exception ex)
            {

                string erro=ex.Message;
                return Redirect("~/Usuario/Login");
            }
            
        }

        public IActionResult _NavAdminPartial()
        {
            try
            {
                Usuario user = dB.repositorioUsuarios.LoginUser(HttpContext.Session.GetString("username"));
                var UserVM = mapper.Map<UsuarioViewModel>(user);


                if (UserVM.Nombreusuario != null)
                {
                    return PartialView(UserVM);
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
