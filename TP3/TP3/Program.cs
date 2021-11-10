using System;
using System.Collections.Generic;

namespace TP3
{
    class Program
    {
        static void Main(string[] args)
        {

            string cadena = "Data Source=Cadeteria.db;Cache=Shared";
            RepositorioCadete repo = new(cadena);
            List<Cadete> lista = repo.ListaCadetes();
            foreach(Cadete x in lista) 
            {
                Console.WriteLine(x.Id);
            }
            
        }
    }
}
