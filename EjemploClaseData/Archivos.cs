using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EjemploClaseData
{
    public static class Archivos
    {
        public static Usuario GuardarEnArchivoJson(Usuario data)
        {
            var listado = LeerDesdeArchivoJson();

            if (data.Id != 0)
            {
                listado.RemoveAll(x => x.Id == data.Id);
            }
            else
            {
                data.Id = listado.Count + 1;
                data.FechaRegistro = DateTime.Now;
            }

            listado.Add(data);

            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            string json = JsonConvert.SerializeObject(listado, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);

            return data;
        }

        public static List<Usuario> LeerDesdeArchivoJson()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                return JsonConvert.DeserializeObject<List<Usuario>>(json);
            }
            else
            {
                return new List<Usuario>();
            }
        }
    }
}
