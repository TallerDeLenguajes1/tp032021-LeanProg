using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EmpresaCadetes.Entidades;
using System.Data.SqlClient;

namespace EmpresaCadetes.Entidades
{
    public class RepositorioCadetes
    {
        
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;
        public RepositorioCadetes(string connectionString){
            this.connectionString = connectionString;
            conexion= new SQLiteConnection(connectionString);
        }
        public List<Cadete> getAll(){
            List<Cadete> listCadete= new List<Cadete>();
            using (SQLiteConnection conexion= new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery =  "SELECT * FROM Cadetes";
                SQLiteCommand command= new SQLiteCommand(SQLQuery,conexion);

                SQLiteDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read()){
                                 Cadete cadete = new Cadete();
                                cadete.Id = Convert.ToInt32(dataReader["cadeteId"]);
                                 cadete.Nombre = Convert.ToString(dataReader["cadeteNombre"]);
                                 cadete.Direcion = Convert.ToString(dataReader["cadeteDireccion"]);
                                 cadete.Telefono = Convert.ToString(dataReader["cadeteTelefono"]);
   
                    listCadete.Add(cadete);
                }

                conexion.Close();
            }

            return listCadete;
        }
    }
}