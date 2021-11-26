using AutoMapper;
using EmpresaCadetes.DataBase;
using EmpresaCadetes.Entidades;
using EmpresaCadetes.ViwModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmpresaCadetes.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IMapper mapper;
        private readonly IIDBSQLite dB;

        public UsuarioController(IMapper mapper, IIDBSQLite DB)
        {
            this.mapper = mapper;
            dB = DB;
        }


        public IActionResult Login()
        {
            return View(new UsuarioLoginViewModel());
        }
        //post de usuario
        [HttpPost]
        public IActionResult Login(UsuarioLoginViewModel UserVM)
        {
            if (dB.repositorioUsuarios.IsUserRegister(UserVM.Nombreusuario, UserVM.Clave))
            {
                HttpContext.Session.SetString("username", UserVM.Nombreusuario);
                return Redirect("~/Home");
            }
            else
            {
                UserVM.ErrorMessage = "Usuario o contraseña incorrecta";
                return View(UserVM);
            }

        }
        public IActionResult Logout()
        {

            if (HttpContext.Session.GetString("username") != null)
            {

                HttpContext.Session.Clear();
                return Redirect("~/Usuario/Login");
            }
            return View(new UsuarioLoginViewModel());
        }

        //Alta de Usuario
        public IActionResult AltaUsuario()
        {
            return View(new UsuarioAltaViewModel());
        }
        [HttpPost]
        public IActionResult AltaUsuario(UsuarioAltaViewModel UsuarioVM)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioVM.Clave != UsuarioVM.Confirm_Password)
                {
                    UsuarioVM.ErrorMessage = "Las contraseñas deben ser iguales";
                    return View(UsuarioVM);
                }
                else
                {
                    Usuario New_usuario = mapper.Map<Usuario>(UsuarioVM);
                    if (!dB.repositorioUsuarios.IsUserRegister(New_usuario.Nombreusuario, New_usuario.Clave))
                    {
                       dB.repositorioUsuarios.InsertUsuarios(New_usuario);
                        Console.WriteLine("Usuario Creado");
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        UsuarioVM.ErrorMessage = "El usuario '" + UsuarioVM.Nombreusuario + "' ya se encuentra registrado"; ;
                        return View(UsuarioVM);
                    }
                }
            }
            else
            {
                UsuarioVM.ErrorMessage = "Ha ocurrido un error. Intente nuevamente";
                return View(UsuarioVM);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
