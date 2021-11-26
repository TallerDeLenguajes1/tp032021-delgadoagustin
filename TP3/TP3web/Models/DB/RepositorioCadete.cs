using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public interface IRepositorioCadete
    {
        void AgregarCadete(Cadete cad);
        void BorrarCadete(int id);
        Cadete CadetePorID(int id);
        List<Cadete> ListaCadetes();
        int ObtenerMaxID();
        void ModificarCadete(Cadete cad);
    }

    public class SQLiteRepositorioCadete : IRepositorioCadete
    {
        public readonly string cadenaConexion;

        public SQLiteRepositorioCadete(string cadena)
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

        public void AgregarCadete(Cadete cad)
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
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        public void ModificarCadete(Cadete cad)
        {
            string consultaSQL = "UPDATE Cadetes" +
                " SET cadeteNombre = @nombre, cadeteTelefono = @telefono, cadeteDireccion = @direccion" +
                " WHERE cadeteID = @id";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", cad.Nombre);
                        command.Parameters.AddWithValue("@telefono", cad.Telefono);
                        command.Parameters.AddWithValue("@direccion", cad.Direccion);
                        command.Parameters.AddWithValue("@id", cad.Id);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void BorrarCadete(int id)
        {
            string consultaSQL = "DELETE FROM Cadetes WHERE cadeteID = @id;";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public Cadete CadetePorID(int id)
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

        public int ObtenerMaxID()
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
