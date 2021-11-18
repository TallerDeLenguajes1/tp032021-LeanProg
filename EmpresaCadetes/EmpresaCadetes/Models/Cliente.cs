using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaCadetes.Entidades
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;

        public Cliente(string nombre, string direccion,string telefono)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        public Cliente()
        {

        }

        public string Telefono { get => telefono; set => telefono = value; }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }

    }
}
