using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using EmpresaCadetes.Entidades;
using System.IO;
using System.Text.Json;

namespace EmpresaCadetes.DataBase
{
    public interface IRepositorioPedidosDB
    {
        void DeletePedidos(int id);
        void ModificarEstadoPedido(List<Pedidos> miListap);
        List<Pedidos> ReadPedidos();
        void SavePedidos(Pedidos pedido1);
    }

    public class RepositorioPedidosJson : IRepositorioPedidosDB
    {
        string path2 = "Pedidos.json";
        public RepositorioPedidosJson()
        {
            if (!File.Exists(path2))
            {
                using (FileStream miArchivo = new FileStream(path2, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(miArchivo))
                    {
                        writer.Write("");
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
        }

        public List<Pedidos> ReadPedidos()
        {
            List<Pedidos> Pedidojson = null;
            try
            {
                using (FileStream miArchivo2 = new FileStream(path2, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(miArchivo2))
                    {
                        string strPedidos = reader.ReadToEnd();
                        reader.Close();
                        reader.Dispose();
                        if (strPedidos != "")
                        {
                            //Problema con serilzer cuando cargo el segundo pedido me manda todo null y me salta la excepcion
                            Pedidojson = JsonSerializer.Deserialize<List<Pedidos>>(strPedidos);

                        }
                        else
                        {
                            Pedidojson = new List<Pedidos>();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }

            return Pedidojson;
        }

        public void SavePedidos(Pedidos pedido1)
        {
            try
            {
                List<Pedidos> pedidos = ReadPedidos();
                pedidos.Add(pedido1);
                string PedidosJson = JsonSerializer.Serialize(pedidos);
                using (FileStream miArchivo = new FileStream(path2, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(miArchivo))
                    {
                        writer.Write(PedidosJson);
                        writer.Close();
                        writer.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
        }
        //FUNCION MODIFICAR PEDIDO EN DB
        public void ModificarEstadoPedido(List<Pedidos> miListap)
        {
            try
            {
                string pejson = JsonSerializer.Serialize(miListap);
                using (FileStream miarchivo = new FileStream(path2, FileMode.Create))
                {
                    using (StreamWriter writter = new StreamWriter(miarchivo))
                    {
                        writter.Write(pejson);
                        writter.Close();
                        writter.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
        }
        public void DeletePedidos(int id)
        {
            try
            {
                //Leo la lista de pedidos
                List<Pedidos> listaPedidos = ReadPedidos();
                listaPedidos.RemoveAll(x => x.Numero == id);
                string Pedidosjson = JsonSerializer.Serialize(listaPedidos);
                using (FileStream miArchivo = new FileStream(path2, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(miArchivo))
                    {
                        writer.Write(Pedidosjson);
                        writer.Close();
                        writer.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
        }
    }



    public class RepositorioPedidosSQLite : IRepositorioPedidosDB
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
        public List<Pedidos> ReadPedidos()
        {
            List<Pedidos> listPedidos = new List<Pedidos>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "SELECT * FROM PEDIDOS";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Pedidos pedido = new Pedidos();
                    pedido.Estado = Convert.ToString(dataReader["pedidoEstado"]);
                    pedido.Observacion = Convert.ToString(dataReader["pedidoObs"]);
                    pedido.Numero = Convert.ToInt32(dataReader["pedidoID"]);
                    listPedidos.Add(pedido);
                }
                conexion.Close();

            }
            return listPedidos;

        }

        public void DeletePedidos(int id)
        {
            throw new NotImplementedException();
        }

        

        public void ModificarEstadoPedido(List<Pedidos> miListap)
        {
            throw new NotImplementedException();
        }

       

        public void SavePedidos(Pedidos pedido1)
        {
            throw new NotImplementedException();
        }
    }
}