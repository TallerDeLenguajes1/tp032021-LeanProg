using System.ComponentModel.DataAnnotations;

namespace EmpresaCadetes.ViwModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="El campo Usuario tiene que estar lleno")]
        [StringLength(100)]
        private string nombreusuario;
        [Required(ErrorMessage ="El campo clave tiene que estar lleno")]
        [StringLength (100)]
        private string clave;

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
        private string nombreusuario;
        [Required(ErrorMessage = "El campo clave tiene que estar lleno")]
        [StringLength(100)]
        private string clave;

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
}
