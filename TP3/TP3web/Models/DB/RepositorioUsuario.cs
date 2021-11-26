using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace DB
{
    public interface IRepositorioUsuario
    {
        bool existeUsuario(string usuario, string pass);
    }

    public class SQLiteRepositorioUsuario : IRepositorioUsuario
    {
        public readonly string cadenaConexion;

        public SQLiteRepositorioUsuario(string cadena)
        {
            cadenaConexion = cadena;
        }

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
                        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                        {
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
