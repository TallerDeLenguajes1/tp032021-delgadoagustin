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
            string consultaSQL = "SELECT * FROM Cadetes";
            using (var conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();
                SQLiteCommand command = new(consultaSQL,conexion);
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

            return listado;
        }
    }
}
