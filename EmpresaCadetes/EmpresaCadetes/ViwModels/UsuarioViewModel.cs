using System.ComponentModel.DataAnnotations;

namespace EmpresaCadetes.ViwModels
{
    public class UsuarioViewModel
    {
        [Required]
        [StringLength(100)]
        private string nombreusuario;
        [Required]
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
}
