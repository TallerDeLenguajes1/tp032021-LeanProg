using System.ComponentModel.DataAnnotations;
using EmpresaCadetes.Entidades;

namespace EmpresaCadetes.ViewModels
{
    public class PedidosViewModel
    {

        public int numero;
        [Required]
        [StringLength(1000)]
        public string observacion;
        [Required]
        public Cliente newCliente;
        [Required]
        [StringLength(100)]
        public string estado;


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

    public class PedidosAltaViewModel
    {

     
        [Required]
        [StringLength(1000)]
        public string observacion;
        [Required]
        public Cliente newCliente;
        [Required]
        [StringLength(100)]
        public string estado;


        public PedidosAltaViewModel(string observacion, string estado, string nombre, string direcion, string telefono)
        {

            this.observacion = observacion;
            this.newCliente = new Cliente(nombre, direcion, telefono);
            this.estado = estado;
        }
        public PedidosAltaViewModel()
        {
            this.newCliente = new Cliente();
        }
       
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente NewCliente { get => newCliente; set => newCliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }


    public class PedidosModificarViewModel
    {

        public int numero;
        [Required]
        [StringLength(1000)]
        public string observacion;
        [Required]
        public Cliente newCliente;
        [Required]
        [StringLength(100)]
        public string estado;


        public PedidosModificarViewModel(string observacion, string estado, string nombre, string direcion, string telefono)
        {

            this.observacion = observacion;
            this.newCliente = new Cliente(nombre, direcion, telefono);
            this.estado = estado;
        }
        public PedidosModificarViewModel()
        {
            this.newCliente = new Cliente();
        }
        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente NewCliente { get => newCliente; set => newCliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
