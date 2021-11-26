using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DB
{
    public interface IDB
    {
        IRepositorioCadete RepositorioCadete { get; set; }
        IRepositorioCliente RepositorioCliente { get; set; }
        IRepositorioPedido RepositorioPedido { get; set; }
        IRepositorioUsuario RepositorioUsuario { get; set; }
    }

    public class SQLiteDB : IDB
    {
        public IRepositorioCadete RepositorioCadete { get; set; }
        public IRepositorioCliente RepositorioCliente { get; set; }
        public IRepositorioPedido RepositorioPedido { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public SQLiteDB(string cadena)
        {
            RepositorioCadete = new SQLiteRepositorioCadete(cadena);
            RepositorioPedido = new SQLiteRepositorioPedido(cadena);
            RepositorioCliente = new SQLiteRepositorioCliente(cadena);
            RepositorioUsuario = new SQLiteRepositorioUsuario(cadena);
        }
    }
}
