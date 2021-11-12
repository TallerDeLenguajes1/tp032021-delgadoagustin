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

        public void modificarCadete(Cadete cad)
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
        public void borrarCadete(int id)
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

        //Clientes

        public Cliente clientePorId(int id){
            Cliente cliente = null;
            string consultaSQL = "SELECT * FROM Clientes WHERE clienteID=@id;";
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
                                cliente = new Cliente(
                                    Convert.ToInt32(dataReader["clienteID"]),
                                    dataReader["clienteNombre"].ToString(),
                                    dataReader["clienteDireccion"].ToString(),
                                    dataReader["clienteTelefono"].ToString()
                                );
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
            return cliente;

        }

        //PEDIDOS

        public List<Pedido> ListarPedidoCadete(int idcad)
        {
           List<Pedido> listado = new();
           try
           {
               string consultaSQL = "SELECT * FROM Pedidos " +
                   "INNER JOIN Cadetes ON Pedidos.cadeteId = Cadetes.cadeteID " +
                   "WHERE Cadetes.cadeteID = @id; ";
               using (var conexion = new SQLiteConnection(cadenaConexion))
               {

                   using (SQLiteCommand command = new(consultaSQL, conexion))
                   {
                       command.Parameters.AddWithValue("@id", idcad);
                       conexion.Open();
                       using (SQLiteDataReader dataReader = command.ExecuteReader())
                       {
                           while (dataReader.Read())
                           {
                               Pedido pedido = new Pedido()
                               {
                                   Numero = Convert.ToInt32(dataReader["pedidoID"]),
                                   Cliente = clientePorId(Convert.ToInt32(dataReader["clienteId"])),
                                   Estado = dataReader["pedidoEstado"].ToString(),
                                   Obs = dataReader["pedidoObs"].ToString()
                               };
                               listado.Add(pedido);
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

        //USUARIO

        public bool existeUsuario(string usuario, string pass)
        {
            bool b = false;
            string consultaSQL = "SELECT count() FROM Usuarios "
            + "WHERE usuarioNombre = @usuario AND usuarioPass = @pass;";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@pass", pass);
                        conexion.Open();
                        if(Convert.ToInt32(command.ExecuteScalar())>0){
                            b = true;
                        }
                        conexion.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return b;

        }

    }
}
