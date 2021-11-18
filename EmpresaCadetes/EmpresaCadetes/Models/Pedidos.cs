using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;
namespace EmpresaCadetes.Entidades
{
    public class Pedidos
    {
        private int numero;
        private string observacion;
        private Cliente newCliente;
        private string estado;
     

        public Pedidos(string observacion, string estado,string nombre,string direcion, string telefono)
        {
            
            this.observacion = observacion;
            this.newCliente = new Cliente(nombre,direcion,telefono);
            this.estado = estado;
        }
        public Pedidos()
        {
           this.newCliente=new Cliente();
        }
        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente NewCliente { get => newCliente; set => newCliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
