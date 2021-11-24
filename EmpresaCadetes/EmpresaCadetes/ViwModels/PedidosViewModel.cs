using System.ComponentModel.DataAnnotations;
using EmpresaCadetes.Entidades;

namespace EmpresaCadetes.ViwModels
{
    public class PedidosViewModel
    {

        private int numero;
        [Required]
        [StringLength(1000)]
        private string observacion;
        [Required]
        private Cliente newCliente;
        [Required]
        [StringLength(100)]
        private string estado;


        public PedidosViewModel(string observacion, string estado, string nombre, string direcion, string telefono)
        {

            this.observacion = observacion;
            this.newCliente = new Cliente(nombre, direcion, telefono);
            this.estado = estado;
        }
        public PedidosViewModel()
        {
            this.newCliente = new Cliente();
        }
        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente NewCliente { get => newCliente; set => newCliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
