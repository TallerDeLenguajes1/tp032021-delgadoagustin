using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    public class Base
    {
        string path = @"cadeteria.json";
        public Cadeteria cadeteria { get; set; }


        public Base()
        {
            cadeteria = new();
        }
        public void CargarCadeteria()
        {
            string cadeteriaFromJson = "";
            if (File.Exists(path))
            {
                using(var reader = new StreamReader(path))
                {
                    cadeteriaFromJson = reader.ReadToEnd();
                    cadeteria = JsonConvert.DeserializeObject<Cadeteria>(cadeteriaFromJson);
                }
            }
            else {
                var file = File.Create(path);
                file.Close();
            }
        }
        public void GuardarCadeteria()
        {
            string cadeteriaJson = JsonConvert.SerializeObject(cadeteria,Formatting.Indented);
            File.WriteAllText(path, cadeteriaJson);
        }
    }
}
