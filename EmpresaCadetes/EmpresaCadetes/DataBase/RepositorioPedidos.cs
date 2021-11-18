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

        public List<Cliente> ReadClientes()
        {
            List<Cliente> ListadoDeCliente = new List<Cliente>();
            string SQLQuery = "SELECT * FROM  Clientes;";
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                using (SQLiteDataReader DataReader = command.ExecuteReader())
                {
                    while (DataReader.Read())
                    {
                        Cliente cliente = new Cliente();

                        cliente.Id = Convert.ToInt32(DataReader["clienteId"]);
                        cliente.Nombre = DataReader["clienteNombre"].ToString();
                        cliente.Direccion = DataReader["clienteDireccion"].ToString();
                        cliente.Telefono = DataReader["clienteTelefono"].ToString();
                        ListadoDeCliente.Add(cliente);
                    }
                }

                conexion.Close();
                return ListadoDeCliente;
            }
        }


        //Inserto datos a la tabla de los Clientes
        public void InsertClientes(Cliente cliente)
        {
            List<Cliente> ListCliente = ReadClientes();
            try
            {

                if (ListCliente.Find(x => x.Nombre == cliente.Nombre && x.Direccion == cliente.Direccion && x.Telefono == cliente.Telefono) == null)
                {
                    string SQLQuery = "INSERT INTO Clientes (clienteNombre, clienteDireccion, clienteTelefono)" +
                    "VALUES (@nombre, @direccion, @telefono);";

                    using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                    {

                        using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                        {
                            conexion.Open();
                            command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                            command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                            command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                            command.ExecuteNonQuery();
                            conexion.Close();
                        }
                    }
                   // _logger.Info("SE INSERTARON LOS DATOS DEL CLIENTE DE FORMA EXITOSA");
                }
                else
                {
                    cliente = ListCliente.Where(x => x.Nombre == cliente.Nombre && x.Direccion == cliente.Direccion && x.Telefono == cliente.Telefono).Single();
                    //_logger.Info("EL CLIENTE " + cliente.Id + " YA SE ENCUENTRA REGISTRADO");

                }
            }
            catch (Exception ex)
            {
                
                string error = ex.ToString();
            }
           
        }
        //obetener los pedidos de la bd en una lista
        public List<Pedidos> ReadPedidos()
        {
            List<Pedidos> listPedidos = new List<Pedidos>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "SELECT * FROM Pedidos INNER JOIN Clientes ON Pedidos.clienteId=Clientes.clienteID;";
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Pedidos pedido = new Pedidos();
                    pedido.Estado = Convert.ToString(dataReader["pedidoEstado"]);
                    pedido.Observacion = Convert.ToString(dataReader["pedidoObs"]);
                    pedido.Numero = Convert.ToInt32(dataReader["pedidoID"]);
                    pedido.NewCliente.Id = Convert.ToInt32(dataReader["clienteId"]);
                    pedido.NewCliente.Nombre = Convert.ToString(dataReader["clienteNombre"]);
                    pedido.NewCliente.Direccion = Convert.ToString(dataReader["clienteDireccion"]);
                    pedido.NewCliente.Telefono = Convert.ToString(dataReader["clienteTelefono"]);

                    listPedidos.Add(pedido);
                }
                dataReader.Close();
                conexion.Close();

            }
            return listPedidos;

        }

        public void DeletePedidos(int id)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string sqlquery = "DELETE FROM Pedidos WHERE pedidoID='" + id.ToString() + "';";
                using (SQLiteCommand command = new SQLiteCommand(sqlquery,conexion))
                {
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
;
            }
        }

        

        public void ModificarEstadoPedido(List<Pedidos> miListap)
        {
            throw new NotImplementedException();
        }

        public int getClientebyID(Cliente uncliente)
        {
            int id = 0;
            

            using (SQLiteConnection conexion= new SQLiteConnection(connectionString))
            {
                string query = "SELECT clienteID FROM Clientes WHERE clienteNombre=@nombre;";
                
                conexion.Open();
                SQLiteCommand command = new SQLiteCommand(query, conexion);
                command.Parameters.AddWithValue("@nombre",uncliente.Nombre);
                using (SQLiteDataReader Datareader= command.ExecuteReader())
                {
                    
                    Datareader.Read();
                    id = Convert.ToInt32(Datareader["clienteID"]);
                    
                    Datareader.Close();
                }

                conexion.Close();
            }
            return id;
        }
       

        public void SavePedidos(Pedidos pedido)
        {
            //insertoCliente en la Base de datos
            InsertClientes(pedido.NewCliente);
            int id = getClientebyID(pedido.NewCliente);
            string QueryClientes = "(SELECT clienteID FROM Clientes WHERE clienteID = @id_cliente)";
            //string QueryCadetes = "(SELECT cadeteID FROM Cadetes WHERE cadeteID = @id_cadete)";

            string SQLQuery = "INSERT INTO Pedidos (pedidoObs, clienteId,cadeteId, pedidoEstado)" +
            "VALUES (@obs, " + QueryClientes + ",@idcadete"+" , @estado);";

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {

                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    conexion.Open();
                    command.Parameters.AddWithValue("@id_cliente", id.ToString());
                    command.Parameters.AddWithValue("@obs", pedido.Observacion);
                    command.Parameters.AddWithValue("@estado", pedido.Estado);
                    command.Parameters.AddWithValue("@idcadete",-1);
                    command.ExecuteNonQuery();
                    conexion.Close();
                }

            }
        }
    }
}