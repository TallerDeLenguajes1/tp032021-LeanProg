using AutoMapper;
using EmpresaCadetes.Entidades;
using EmpresaCadetes.ViewModels;
namespace EmpresaCadetes
{
    public class PerfildeMapeo : Profile
    {
        public PerfildeMapeo()
        {
            CreateMap<Usuario,UsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioAltaViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioLoginViewModel>().ReverseMap();
            CreateMap<Pedidos, PedidosViewModel>().ReverseMap();
            CreateMap<Pedidos,PedidosAltaViewModel>().ReverseMap();
            CreateMap<Pedidos, PedidosModificarViewModel>().ReverseMap();
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();
            CreateMap<Cadete,CadeteAltaViewModel>().ReverseMap();
            CreateMap<Cadete, CadeteModificarViewModel>().ReverseMap();
        }
    }
}
