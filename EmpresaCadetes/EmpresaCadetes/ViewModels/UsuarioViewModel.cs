using System.ComponentModel.DataAnnotations;

namespace EmpresaCadetes.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="El campo Usuario tiene que estar lleno")]
        [StringLength(100)]
        public string nombreusuario;
        [Required(ErrorMessage ="El campo clave tiene que estar lleno")]
        [StringLength (100)]
        public string clave;
        [Required(ErrorMessage = "El campo confirmar Password es requerido")]
        [StringLength(100)]
        public string Confirm_Password { get; set; }
        public string ErrorMessage { get; set; }


        public UsuarioViewModel(string nombreusuario, string clave)
        {
            this.Nombreusuario = nombreusuario;
            this.Clave = clave;
        }
        public UsuarioViewModel()
        {

        }
        public string Nombreusuario { get => nombreusuario; set => nombreusuario = value; }
        public string Clave { get => clave; set => clave = value; }
    }
    public class UsuarioAltaViewModel
    {
        [Required(ErrorMessage = "El campo Usuario tiene que estar lleno")]
        [StringLength(100)]
        public string nombreusuario;
        [Required(ErrorMessage = "El campo clave tiene que estar lleno")]
        [StringLength(100)]
        public string clave;
        public string ErrorMessage { get; set; }
        public string Confirm_Password { get; set; }

        public UsuarioAltaViewModel(string nombreusuario, string clave)
        {
            this.Nombreusuario = nombreusuario;
            this.Clave = clave;
        }
        public UsuarioAltaViewModel()
        {

        }

       
        public string Nombreusuario { get => nombreusuario; set => nombreusuario = value; }
        public string Clave { get => clave; set => clave = value; }
    }


    public class UsuarioLoginViewModel
    {
        [Required(ErrorMessage = "El campo Usuario tiene que estar lleno")]
        [StringLength(100)]
        public string nombreusuario;
        [Required(ErrorMessage = "El campo clave tiene que estar lleno")]
        [StringLength(100)]
        public string clave;
        [Required(ErrorMessage = "El campo Password es requerido")]
        [StringLength(100)]
        
        public string ErrorMessage { get; set; }
        public UsuarioLoginViewModel(string nombreusuario, string clave)
        {
            this.Nombreusuario = nombreusuario;
            this.Clave = clave;
        }
        public UsuarioLoginViewModel()
        {

        }
        public string Nombreusuario { get => nombreusuario; set => nombreusuario = value; }
        public string Clave { get => clave; set => clave = value; }
    }
}
