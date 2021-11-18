using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EmpresaCadetes.Entidades;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;

namespace EmpresaCadetes.DataBase
{

    public interface IRepositorioCadetesDB
    {
        void DeleteCadetes(int id);
        Cadete GetCadeteById(int id);
        List<Cadete> ReadCadetes();
        void SaveCadete(Cadete cadete);
        void UpdateCadete(Cadete unCadete);
    }
    public class RepositorioCadetesJson : IRepositorioCadetesDB
    {

        string path = "Cadetes.json";
       //string path3 = "PagosRealizados.json";

        public RepositorioCadetesJson()
        {
            if (!File.Exists(path))
            {
                using (FileStream miArchivo = new FileStream(path, FileMode.Create))
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
        public List<Cadete> ReadCadetes()
        {
            List<Cadete> Cadetejson = null;
            try
            {
                using (FileStream miArchivo = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(miArchivo))
                    {
                        string StrCadetes = reader.ReadToEnd();
                        reader.Close();
                        reader.Dispose();
                        if (StrCadetes != "")
                        {
                            Cadetejson = JsonSerializer.Deserialize<List<Cadete>>(StrCadetes);

                        }
                        else
                        {
                            Cadetejson = new List<Cadete>();
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
            return Cadetejson;
        }

        //GuardarCadete en el archivo json;
        public void SaveCadete(Cadete cadete)
        {
            try
            {
                List<Cadete> cadetes = ReadCadetes();
                cadetes.Add(cadete);
                string CadeteJson = JsonSerializer.Serialize(cadetes);
                using (FileStream miArchivo = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(miArchivo))
                    {
                        writer.Write(CadeteJson);
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
        //modificar cadete
        public void UpdateCadete(Cadete unCadete)
        {

            try
            {
                List<Cadete> cadetes = ReadCadetes();

                foreach (var item in cadetes)
                {
                    if (item.Id == unCadete.Id)
                    {
                        item.Nombre = unCadete.Nombre;
                        item.Direcion = unCadete.Direcion;
                        item.Telefono = unCadete.Telefono;
                        item.Listapedidos = unCadete.Listapedidos;
                    }
                }
                string cadetesjson = JsonSerializer.Serialize(cadetes);
                using (FileStream miArchivo = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(miArchivo))
                    {
                        writer.Write(cadetesjson);
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

        //BORRAR CADETE
        public void DeleteCadetes(int id)
        {
            try
            {
                //Leer cadetes
                List<Cadete> listaCadetes = ReadCadetes();
                ////Elimino  de la lista el cadete buscado
                listaCadetes.RemoveAll(x => x.Id == id);
                List<Cadete> nuevo = listaCadetes.ToList();
                //3- guardar lista en el arhivo
                string CadeteJson1 = JsonSerializer.Serialize(nuevo);
                using (FileStream miArchivo = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writter = new StreamWriter(miArchivo))
                    {
                        writter.Write(CadeteJson1);
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
        //get cadete by id
        public Cadete GetCadeteById(int id)
        {
            // seleccionar un alumno por id
            List<Cadete> cadetes = null;
            Cadete uncadete = null;
            try
            {
                cadetes = ReadCadetes();
                uncadete = cadetes.Where(a => a.Id == id).First();

            }
            catch (Exception ex)
            {

                string error = ex.ToString();

            }
            return uncadete;
        }
    }





    public class RepositorioCadetesSQLite : IRepositorioCadetesDB
    {
        
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;
        public RepositorioCadetesSQLite(string connectionString){
            this.connectionString = connectionString;
            this.conexion= new SQLiteConnection(connectionString);
        }

        public List<Cadete> ReadCadetes()
        {
            List<Cadete> listCadete = new List<Cadete>(); //creo una lista
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString)) //creo un nuevo objeto conexion
            {
                conexion.Open(); //abro la conexion con el servidor
                string SQLQuery = "SELECT * FROM Cadetes"; //hago la consulta con los datos que quiero traer
                SQLiteCommand command = new SQLiteCommand(SQLQuery, conexion); //mando la consulta con la conexion

                SQLiteDataReader dataReader = command.ExecuteReader(); // leo los datos
                while (dataReader.Read()) // leo los datos uno a uno y los voy guardando en la lista
                {
                    Cadete cadete = new Cadete(); //creo un nuevo objeto cadete
                    cadete.Id = Convert.ToInt32(dataReader["cadeteId"]);
                    cadete.Nombre = Convert.ToString(dataReader["cadeteNombre"]);
                    cadete.Direcion = Convert.ToString(dataReader["cadeteDireccion"]);
                    cadete.Telefono = Convert.ToString(dataReader["cadeteTelefono"]);

                    listCadete.Add(cadete); //guardo el cadete en la lista
                }

                conexion.Close(); //cierro la conexion
            }

            return listCadete; //retorno la lista de todos los cadetes
        }
        public void DeleteCadetes(int id)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string Query = "DELETE FROM Cadetes WHERE cadeteID='" + Convert.ToString(id) + "';";
                using (SQLiteCommand command = new SQLiteCommand(Query,conexion))
                {
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

       

        public Cadete GetCadeteById(int id)
        {
            Cadete uncadete= null;
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT FROM Cadetes where id='"+Convert.ToString(id)+"'";
                SQLiteCommand command = new SQLiteCommand(query, conexion);
                using (SQLiteDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            uncadete.Id = Convert.ToInt32(dataReader["cadeteID"]);
                            uncadete.Nombre =Convert.ToString(dataReader["cadeteNombre"]);
                            uncadete.Direcion = Convert.ToString(dataReader["cadeteDireccion"]);
                            uncadete.Telefono = Convert.ToString(dataReader["cadeteTelefono"]);


                        }

                    }
                }

            }
            return uncadete;


        }

       

        public void SaveCadete(Cadete cadete)
        {
            string sqlquery = "INSERT INTO Cadetes SET (cadeteNombre, cadeteDirecion,cadeteTelefo) VALUES (@nombre,@direccion,@telefono);";
            using (SQLiteConnection conexion= new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command= new SQLiteCommand(sqlquery,conexion))
                 {
                    conexion.Open();
                    command.Parameters.AddWithValue("@nombre",cadete.Nombre);
                    command.Parameters.AddWithValue("@direccion", cadete.Direcion);
                    command.Parameters.AddWithValue("@telefono",cadete.Telefono);
                }
            }
        }

        public void UpdateCadete(Cadete unCadete)
        {
            string SQLQuery= "UPDATE Cadetes SET cadeteNombre=@nombre, cadeteDireccion=@direccion," +
                "cadeteTelefono=@telefono WHERE cadeteID=@id_cad";
            using(SQLiteConnection conexion= new SQLiteConnection(connectionString))
            {
                using(SQLiteCommand command= new SQLiteCommand(SQLQuery,conexion))
                {
                    conexion.Open();
                    command.Parameters.AddWithValue("@id_cad", unCadete.Id);
                    command.Parameters.AddWithValue("@nombre", unCadete.Nombre);
                    command.Parameters.AddWithValue("@direccion", unCadete.Direcion);
                    command.Parameters.AddWithValue("@telefono", unCadete.Telefono);
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
    }
}