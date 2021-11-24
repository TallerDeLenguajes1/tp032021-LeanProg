namespace EmpresaCadetes.Entidades
{
    public class Usuario
    {
        private string nombreusuario;
        private string clave;

        public Usuario(string nombreusuario, string clave)
        {
            this.Nombreusuario = nombreusuario;
            this.Clave = clave;
        }
        public Usuario()
        {

        }
        public string Nombreusuario { get => nombreusuario; set => nombreusuario = value; }
        public string Clave { get => clave; set => clave = value; }
    }
}
