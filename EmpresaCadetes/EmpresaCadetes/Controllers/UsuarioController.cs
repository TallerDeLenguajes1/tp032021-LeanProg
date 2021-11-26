using AutoMapper;
using EmpresaCadetes.DataBase;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}
