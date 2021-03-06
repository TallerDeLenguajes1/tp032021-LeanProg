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
        int getClientebyID(Cliente uncliente);
        Pedidos GetPedidobyId(int id_pedido);
        void InsertClientes(Cliente cliente);
        void UpdatePedido(Pedidos pedido);
        void UpdateCLiente(Cliente cliente);
        List<Cliente> ReadClientes();
        List<Pedidos> ReadPedidos();
        void SavePedidos(Pedidos pedido);
        void AsignarPedidoAcadete(int idpedido,int idcadete);
    }


    //public class RepositorioPedidosJson : IRepositorioPedidosDB
    //{
    //    string path2 = "Pedidos.json";
    //    public RepositorioPedidosJson()
    //    {
    //        if (!File.Exists(path2))
    //        {
    //            using (FileStream miArchivo = new FileStream(path2, FileMode.Create))
    //            {
    //                using (StreamWriter writer = new StreamWriter(miArchivo))
    //                {
    //                    writer.Write("");
    //                    writer.Close();
    //                    writer.Dispose();
    //                }
    //            }
    //        }
    //    }

    //    public List<Pedidos> ReadPedidos()
    //    {
    //        List<Pedidos> Pedidojson = null;
    //        try
    //        {
    //            using (FileStream miArchivo2 = new FileStream(path2, FileMode.Open))
    //            {
    //                using (StreamReader reader = new StreamReader(miArchivo2))
    //                {
    //                    string strPedidos = reader.ReadToEnd();
    //                    reader.Close();
    //                    reader.Dispose();
    //                    if (strPedidos != "")
    //                    {
    //                        //Problema con serilzer cuando cargo el segundo pedido me manda todo null y me salta la excepcion
    //                        Pedidojson = JsonSerializer.Deserialize<List<Pedidos>>(strPedidos);

    //                    }
    //                    else
    //                    {
    //                        Pedidojson = new List<Pedidos>();
    //                    }

    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //            string error = ex.ToString();
    //        }

    //        return Pedidojson;
    //    }

    //    public void SavePedidos(Pedidos pedido1)
    //    {
    //        try
    //        {
    //            List<Pedidos> pedidos = ReadPedidos();
    //            pedidos.Add(pedido1);
    //            string PedidosJson = JsonSerializer.Serialize(pedidos);
    //            using (FileStream miArchivo = new FileStream(path2, FileMode.Create))
    //            {
    //                using (StreamWriter writer = new StreamWriter(miArchivo))
    //                {
    //                    writer.Write(PedidosJson);
    //                    writer.Close();
    //                    writer.Dispose();
    //                }
    //            }

    //        }
    //        catch (Exception ex)
    //        {

    //            string error = ex.ToString();
    //        }
    //    }
    //    //FUNCION MODIFICAR PEDIDO EN DB
    //    public void ModificarEstadoPedido(List<Pedidos> miListap)
    //    {
    //        try
    //        {
    //            string pejson = JsonSerializer.Serialize(miListap);
    //            using (FileStream miarchivo = new FileStream(path2, FileMode.Create))
    //            {
    //                using (StreamWriter writter = new StreamWriter(miarchivo))
    //                {
    //                    writter.Write(pejson);
    //                    writter.Close();
    //                    writter.Dispose();
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //            string error = ex.ToString();
    //        }
    //    }
    //    public void DeletePedidos(int id)
    //    {
    //        try
    //        {
    //            //Leo la lista de pedidos
    //            List<Pedidos> listaPedidos = ReadPedidos();
    //            listaPedidos.RemoveAll(x => x.Numero == id);
    //            string Pedidosjson = JsonSerializer.Serialize(listaPedidos);
    //            using (FileStream miArchivo = new FileStream(path2, FileMode.Create))
    //            {
    //                using (StreamWriter writer = new StreamWriter(miArchivo))
    //                {
    //                    writer.Write(Pedidosjson);
    //                    writer.Close();
    //                    writer.Dispose();
    //                }
    //            }

    //        }
    //        catch (Exception ex)
    //        {

    //            string error = ex.ToString();
    //        }
    //    }
    //}



    public class RepositorioPedidosSQLite : IRepositorioPedidosDB
    {
        //Constructor + variables para la conexion
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;


        public RepositorioPedidosSQLite(string connectionString)
        {
            this.connectionString = connectionString;
            this.conexion = new SQLiteConnection(connectionString);
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
                    DataReader.Close();
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
                   
                }
                else
                {
                    cliente = ListCliente.Where(x => x.Nombre == cliente.Nombre && x.Direccion == cliente.Direccion && x.Telefono == cliente.Telefono).Single();
                 

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
                using (SQLiteCommand command = new SQLiteCommand(sqlquery, conexion))
                {
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
;
            }
        }


        public int getClientebyID(Cliente uncliente)
        {
            

            List<Cliente> listaClientes= ReadClientes();
            Cliente cliente = listaClientes.Find(a => a.Direccion == uncliente.Direccion && a.Nombre == uncliente.Nombre && a.Telefono == uncliente.Telefono);
            
            return cliente.Id;
        }


        public void SavePedidos(Pedidos pedido)
        {
            //insertoCliente en la Base de datos
            InsertClientes(pedido.NewCliente);
            int idcliente = getClientebyID(pedido.NewCliente);
            
            string QueryClientes = "(SELECT clienteID FROM Clientes WHERE clienteID = @id_cliente)";
            //string QueryCadetes = "(SELECT cadeteID FROM Cadetes WHERE cadeteID = @id_cadete)";

            string SQLQuery = "INSERT INTO Pedidos (pedidoObs, clienteId,cadeteId, pedidoEstado)" +
            "VALUES (@obs, " + QueryClientes + ",@idcadete" + " , @estado);";

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {

                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion))
                {
                    conexion.Open();
                    command.Parameters.AddWithValue("@id_cliente", idcliente);
                    command.Parameters.AddWithValue("@obs", pedido.Observacion);
                    command.Parameters.AddWithValue("@estado", pedido.Estado);
                    command.Parameters.AddWithValue("@idcadete", null);
                    command.ExecuteNonQuery();
                    conexion.Close();
                }

            }
        }

        public Pedidos GetPedidobyId(int id_pedido)
        {
            Pedidos pedido = new Pedidos();
            string SQLQuery = "SELECT * FROM Pedidos INNER JOIN Clientes ON Pedidos.clienteId=Clientes.clienteID WHERE pedidoID=@idpedido ";
            
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion);
                    command.Parameters.AddWithValue("idpedido", id_pedido.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                pedido.Numero = Convert.ToInt32(reader["pedidoID"]);
                                pedido.Observacion = Convert.ToString(reader["pedidoObs"]);
                                pedido.Estado = Convert.ToString(reader["pedidoEstado"]);
                                pedido.NewCliente.Id = Convert.ToInt32(reader["clienteID"]);
                                pedido.NewCliente.Direccion = Convert.ToString(reader["clienteDireccion"]);
                                pedido.NewCliente.Nombre = Convert.ToString(reader["clienteNombre"]);
                                pedido.NewCliente.Telefono = Convert.ToString(reader["clienteTelefono"]);


                            }
                            
                            reader.Close();
                            conexion.Close();   
                        }


                    }
                }
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
            return pedido;
        }

        public void UpdatePedido(Pedidos pedido)
        {
            
            string query = "UPDATE Pedidos SET pedidoObs=@obs,pedidoEstado=@estado,clienteId=@id_cliente WHERE pedidoID=@id_pedido;";
            try
            {
                UpdateCLiente(pedido.NewCliente);
                //pedido.NewCliente.Id = getClientebyID(pedido.NewCliente);
             
                
                
                using (SQLiteConnection conexion= new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command= new SQLiteCommand(query,conexion))
                    {   
                        
                        conexion.Open();
                        command.Parameters.AddWithValue("id_pedido",pedido.Numero);
                        command.Parameters.AddWithValue("@obs",pedido.Observacion);
                        command.Parameters.AddWithValue("@estado",pedido.Estado);
                        command.Parameters.AddWithValue("@id_cliente",pedido.NewCliente.Id);
                        command.ExecuteNonQuery();
                       
                        conexion.Close();

                    }
                    
                }

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                
            }


        }

        public void UpdateCLiente(Cliente cliente)
        {
            string query = "UPDATE Clientes SET clienteNombre=@nombre,clienteTelefono=@telefono,clienteDireccion=@direccion WHERE clienteID = @id_cli;";
            //int idcliente = getClientebyID(cliente);
            using (SQLiteConnection comexion= new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command= new SQLiteCommand(query,conexion))
                {
                    conexion.Open();
                    command.Parameters.AddWithValue("@id_cli",cliente.Id);
                    command.Parameters.AddWithValue("@nombre",cliente.Nombre);
                    command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        public void AsignarPedidoAcadete(int idpedido, int idcadete)
        {
            string query ="UPDATE Pedidos SET cadeteId=@cadete_id WHERE Pedidos.pedidoID=@id_pedido;";
            using (SQLiteConnection conexion= new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command= new SQLiteCommand(query,conexion))
                {
                    conexion.Open();
                    command.Parameters.AddWithValue("cadete_id",idcadete);
                    command.Parameters.AddWithValue("id_pedido",idpedido);
                    command.ExecuteNonQuery();
                    conexion.Close();


                }

            }
        }

        
    }
}