﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EmpresaCadetes.Entidades;


namespace EmpresaCadetes.Entidades
{
    public class DBCadeteria
    {
        private Cadeteria cadeteria;
        public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }
        string path = "c:\\temp\\Cadetes.json";
        string path2 = "c:\\temp\\Pedidos.json";

        
        public DBCadeteria()
        //creo el constructor de la base datos con el archivo vacio apuntando a la direcion de path
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
        //LEER CADETES
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
        //Leer pedidos
      public List<Pedidos> ReadPedidos()
        {
            List<Pedidos> Pedidojson = null;
            try
            {
                using (FileStream miArchivo2= new FileStream(path2,FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(miArchivo2))
                    {
                        string strPedidos = reader.ReadToEnd();
                        reader.Close();
                        reader.Dispose();
                        if (strPedidos !="")
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

        public void DeletePedidos(int id)
        {
            try
            {
                   //Leo la lista de pedidos
                List<Pedidos> listaPedidos = ReadPedidos();
                listaPedidos.RemoveAll(x => x.Numero == id);
                string Pedidosjson = JsonSerializer.Serialize(listaPedidos);
                using (FileStream miArchivo = new FileStream(path2,FileMode.Create))
                {
                    using (StreamWriter writer= new StreamWriter(miArchivo))
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
}
