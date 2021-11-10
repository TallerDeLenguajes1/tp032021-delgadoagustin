using System;
using System.Collections.Generic;

namespace TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioCadete repo = new("Data Source=Cadeteria.db;Cache=Shared;");
            Cadete cad = repo.cadetePorID(2);
            Console.WriteLine(cad.Nombre);
        }
    }
}
