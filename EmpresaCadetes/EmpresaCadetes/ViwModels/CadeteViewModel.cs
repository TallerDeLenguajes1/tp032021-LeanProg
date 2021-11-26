using EmpresaCadetes.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace EmpresaCadetes.ViwModels
{
    public class CadeteViewModel
    {

        public int id;
        [Required]
        [StringLength(100)]
        public string nombre;
        [Required]
        [StringLength(100)]
        public string direcion;
        [Required]
        [StringLength(100)]
        public string telefono;
        public List<Pedidos> listapedidos;
        public float Pagodeldia;

        public CadeteViewModel()
        {
            this.Listapedidos = new List<Pedidos>();
        }
        public CadeteViewModel(string nombre, string direcion, string telefono)
        {

            this.nombre = nombre;
            this.direcion = direcion;
            this.telefono = telefono;
            listapedidos = new List<Pedidos>();
            Pagodeldia = 0;
        }

      
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direcion { get => direcion; set => direcion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> Listapedidos { get => listapedidos; set => listapedidos = value; }
        public float Pagodeldia1 { get => Pagodeldia; set => Pagodeldia = value; }
    }

    public class CadeteAltaViewModel
    {

     
        [Required]
        [StringLength(100)]
        public string nombre;
        [Required]
        [StringLength(100)]
        public string direcion;
        [Required]
        [StringLength(100)]
        public string telefono;
        public List<Pedidos> listapedidos;
        public float Pagodeldia;

        public CadeteAltaViewModel()
        {
            this.Listapedidos = new List<Pedidos>();
        }
        public CadeteAltaViewModel(string nombre, string direcion, string telefono)
        {

            this.nombre = nombre;
            this.direcion = direcion;
            this.telefono = telefono;
            listapedidos = new List<Pedidos>();
            Pagodeldia = 0;
        }


        
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direcion { get => direcion; set => direcion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> Listapedidos { get => listapedidos; set => listapedidos = value; }
        public float Pagodeldia1 { get => Pagodeldia; set => Pagodeldia = value; }
    }

    public class CadeteModificarViewModel
    {

        public int id;
        [Required]
        [StringLength(100)]
        public string nombre;
        [Required]
        [StringLength(100)]
        public string direcion;
        [Required]
        [StringLength(100)]
        public string telefono;
        public List<Pedidos> listapedidos;
        public float Pagodeldia;

        public CadeteModificarViewModel()
        {
            this.Listapedidos = new List<Pedidos>();
        }
        public CadeteModificarViewModel(string nombre, string direcion, string telefono)
        {

            this.nombre = nombre;
            this.direcion = direcion;
            this.telefono = telefono;
            listapedidos = new List<Pedidos>();
            Pagodeldia = 0;
        }


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direcion { get => direcion; set => direcion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> Listapedidos { get => listapedidos; set => listapedidos = value; }
        public float Pagodeldia1 { get => Pagodeldia; set => Pagodeldia = value; }
    }

}

