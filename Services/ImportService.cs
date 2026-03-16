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
        public List<Cliente> ImportCsv(string path)
        {
            var lines = File.ReadAllLines(path).Skip(1);
            var clients = new List<Cliente>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');

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

            return clients;
        }

        public List<Cliente> ImportJson(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
        }
    }
}
