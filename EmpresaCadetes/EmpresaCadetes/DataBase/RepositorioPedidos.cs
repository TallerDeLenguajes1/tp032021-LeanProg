using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using EmpresaCadetes.Entidades;
namespace EmpresaCadetes.DataBase
{

    public class RepositorioPedidosJson
    {
        string path2 = "Pedidos.json";

    }
    public class RepositorioPedidosSQLite
    {
        //Constructor + variables para la conexion
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;
        public RepositorioPedidosSQLite(string connectionString)
        {
            this.connectionString = connectionString;
            conexion= new SQLiteConnection(connectionString);
        }
        //obetener los pedidos de la bd en una lista
        public List<Pedidos> getAll(){
            List<Pedidos> listPedidos= new List<Pedidos>();
            using (SQLiteConnection conexion= new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "SELECT * FROM PEDIDOS";
                SQLiteCommand command= new SQLiteCommand(SQLQuery,conexion);
                SQLiteDataReader dataReader= command.ExecuteReader();
                while(dataReader.Read()){
                        Pedidos pedido= new Pedidos();
                        pedido.Estado= Convert.ToString(dataReader["pedidoEstado"]);
                        pedido.Observacion= Convert.ToString(dataReader["pedidoObs"]);
                        pedido.Numero= Convert.ToInt32(dataReader["pedidoID"]);
                        listPedidos.Add(pedido);
                }
                conexion.Close();

            }
            return listPedidos;

        }

    }
}