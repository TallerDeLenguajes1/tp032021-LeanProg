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
    public interface IRepositorioUsuariosDB
    {
        void InsertUsuarios(Usuario usuario);
        bool IsUserRegister(string user, string pass);
        Usuario LoginUser(string usuarioNombre);
        List<Usuario> ReadUsuarios();
    }

    public class RepositorioUsuariosSQLite : IRepositorioUsuariosDB
    {
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioUsuariosSQLite(string connectionString)
        {
            this.connectionString = connectionString;
            this.conexion = new SQLiteConnection(connectionString);
        }


        //leo todos los usuarios
        public List<Usuario> ReadUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();
            try
            {
                string Query = "SELECT * FROM Usuarios ;";
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    SQLiteCommand command = new SQLiteCommand(Query, conexion);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Nombreusuario = Convert.ToString(reader["usuarioNombre"]);
                                usuario.Clave = Convert.ToString(reader["usuarioPass"]);
                                misUsuarios.Add(usuario);
                            }
                            reader.Close();

                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
            return misUsuarios;
        }

        //inserto un usuario en la base de datos
        public void InsertUsuarios(Usuario usuario)
        {
            string query = "INSERT INTO Usuarios (usuarioNombre,usuarioPass) VALUES (@usu,@pass):";
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, conexion))
                    {
                        conexion.Open();
                        command.Parameters.AddWithValue("@usu", usuario.Nombreusuario);
                        command.Parameters.AddWithValue("@pass", usuario.Clave);
                        command.ExecuteNonQuery();
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }



        }
        //veo si el usuario existe o no
        public bool IsUserRegister(string user, string pass)
        {
            bool resultado = false;
            Usuario logeoUsuaro = new Usuario();
            string query = "SELECT * FROM Usuarios WHERE usuarioNombre=@usa AND usuarioPass=@clave;";
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@usa", user);
                        command.Parameters.AddWithValue("@clave", pass);
                        command.ExecuteNonQuery();
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    logeoUsuaro.Nombreusuario = Convert.ToString(dataReader["usuarioNombre"]);
                                    logeoUsuaro.Clave = Convert.ToString(dataReader["usuarioPass"]);
                                    resultado = true;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
            }
            return resultado;
        }
        public Usuario LoginUser(string usuarioNombre)
        {

            Usuario usuariologueado = new Usuario();
            string query = "SELECT * FROM  Usuarios Where nombreUsuario=@user;";
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    SQLiteCommand command = new SQLiteCommand(query, conexion);
                    conexion.Open();
                    command.Parameters.AddWithValue("@user", usuarioNombre);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                usuariologueado.Nombreusuario = Convert.ToString(reader["usuarioNombre"]);
                                usuariologueado.Clave = Convert.ToString(reader["usuarioClave"]);
                            }
                            reader.Close();

                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {

                string message = ex.ToString();
            }

            return usuariologueado;
        }
    }
}
