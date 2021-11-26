using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace DB
{
    public interface IRepositorioPedido
    {
        List<Pedido> ListarPedidoCadete(int idcad);
    }

    public class SQLiteRepositorioPedido : IRepositorioPedido
    {
        public readonly string cadenaConexion;

        public SQLiteRepositorioPedido(string cadena)
        {
            cadenaConexion = cadena;
        }

        public List<Pedido> ListarPedidoCadete(int idcad)
        {
            List<Pedido> listado = new();
            try
            {
                string consultaSQL = "SELECT * FROM Pedidos " +
                    "INNER JOIN Cadetes ON Pedidos.cadeteId = Cadetes.cadeteID " +
                    "INNER JOIN Clientes ON Pedidos.clienteId=Clientes.clienteID " +
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
                                    Cliente = new Cliente(
                                        Convert.ToInt32(dataReader["clienteId"]),
                                        dataReader["clienteNombre"].ToString(),
                                        dataReader["clienteDireccion"].ToString(),
                                        dataReader["clienteTelefono"].ToString()
                                        ),
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
    }
}
