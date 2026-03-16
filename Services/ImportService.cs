using Clientes.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Clientes_DESKTOP.Services
{
    public class ImportService
    {
        // Método para importar clientes desde un archivo CSV
        public List<Cliente> ImportCsv(string path)
        {
            // Lee todas las líneas del archivo y omite la primera (cabecera del CSV)
            var lines = File.ReadAllLines(path).Skip(1);
            // Lista donde se almacenarán los clientes importados
            var clients = new List<Cliente>();

            foreach (var line in lines) // Recorre cada línea del archivo
            {
                var parts = line.Split(','); // Divide la línea usando la coma como separador
                
                // Crea un nuevo objeto Cliente con los datos del CSV
                clients.Add(new Cliente
                {
                    DNI = parts[0],
                    Nombre = parts[1],
                    Apellidos = parts[2],
                    FechaNacimiento = DateTime.Parse(parts[3]),
                    Telefono = parts[4],
                    Email = parts[5]
                });
            }
            // Devuelve la lista de clientes importados
            return clients;
        }

        // Método para importar clientes desde un archivo JSON
        public List<Cliente> ImportJson(string path)
        {
            var json = File.ReadAllText(path); // Lee todo el contenido del archivo JSON
            
            // Deserializa el JSON a una lista de objetos Cliente
            // Si el resultado es null, devuelve una lista vacía
            return JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
        }
    }
}
