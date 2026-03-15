using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clientes.Shared.Models;
using Clientes.Shared.Repositories;
using Newtonsoft.Json;

namespace Clientes_DESKTOP.Repositories
{
    public class JsonClienteRepository: ClienteRepository
    {
        private readonly string filePath = "Data/clientes_store.json";

        public List<Cliente> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<Cliente>();

            var json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
        }

        public Cliente GetByDni(string dni)
        {
            return GetAll().FirstOrDefault(c => c.DNI == dni);
        }

        public void Add(Cliente cliente)
        {
            var clientes = GetAll();
            clientes.Add(cliente);
            SaveAll(clientes);
        }

        public void Delete(string dni)
        {
            var clientes = GetAll();
            var cliente = clientes.FirstOrDefault(c => c.DNI == dni);

            if (cliente != null)
            {
                clientes.Remove(cliente);
                SaveAll(clientes);
            }
        }

        public void SaveAll(List<Cliente> clientes)
        {
            var json = JsonConvert.SerializeObject(clientes, Formatting.Indented);

            Directory.CreateDirectory("Data");
            File.WriteAllText(filePath, json);
        }
    }
}
