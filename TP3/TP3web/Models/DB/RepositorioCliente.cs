using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace DB
{
    public interface IRepositorioCliente
    {
        Cliente clientePorId(int id);
    }

    public class SQLiteRepositorioCliente : IRepositorioCliente
    {

        public readonly string cadenaConexion;

        public SQLiteRepositorioCliente(string cadena)
        {
            cadenaConexion = cadena;
        }

        public Cliente clientePorId(int id)
        {
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
    }
}
