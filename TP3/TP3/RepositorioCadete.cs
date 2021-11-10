using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    public class RepositorioCadete
    {
        public readonly string cadenaConexion;

        public RepositorioCadete(string cadena)
        {
            cadenaConexion = cadena;
        }

        public List<Cadete> ListaCadetes()
        {
            List<Cadete> listado = new();
            try
            {
                string consultaSQL = "SELECT * FROM Cadetes";
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        conexion.Open();
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Cadete cadete = new Cadete()
                                {
                                    Id = Convert.ToInt32(dataReader["cadeteID"]),
                                    Nombre = dataReader["cadeteNombre"].ToString(),
                                    Direccion = dataReader["cadeteDireccion"].ToString(),
                                    Telefono = dataReader["cadeteTelefono"].ToString()
                                };
                                listado.Add(cadete);
                            }
                        }
                        conexion.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return listado;
        }

        public void añadirCadete(Cadete cad)
        {
            string consultaSQL = "INSERT INTO Cadetes(cadeteNombre, cadeteTelefono, cadeteDireccion)" +
                "VALUES (@nombre, @telefono, @direccion);";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", cad.Nombre);
                        command.Parameters.AddWithValue("@telefono", cad.Telefono);
                        command.Parameters.AddWithValue("@direccion", cad.Direccion);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            
        }

        public Cadete cadetePorID(int id)
        {
            Cadete cad = new();
            string consultaSQL = "SELECT * FROM Cadetes WHERE cadeteID=@id;";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                cad = new Cadete()
                                {
                                    Id = Convert.ToInt32(dataReader["cadeteID"]),
                                    Nombre = dataReader["cadeteNombre"].ToString(),
                                    Direccion = dataReader["cadeteDireccion"].ToString(),
                                    Telefono = dataReader["cadeteTelefono"].ToString()
                                };
                            }
                        }
                        conexion.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return cad;
        }

        public int maxID()
        {
            int ID = 0;
            string consultaSQL = "SELECT max(id) FROM Cadetes;";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        
                        conexion.Open();
                        ID = Convert.ToInt32(command.ExecuteScalar());
                        conexion.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ID;
        }

    }
}
