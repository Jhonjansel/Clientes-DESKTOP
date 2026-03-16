using Clientes.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clientes.Shared.Models;


namespace Clientes_DESKTOP.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository repository;
        private List<Cliente> clients;
        public ClienteService(ClienteRepository repo)
        {
            repository = repo;
            clients = repository.GetAll();
        }

        public List<Cliente> GetClients()
        {
            return clients;
        }

        public void CreateClient(Cliente client)
        {
            clients.Add(client);
        }

        public void DeleteClient(Cliente client)
        {
            clients.Remove(client);
        }
        public void Save()
        {
            repository.SaveAll(clients);
        }
        public void UpdateClient(Cliente clientUpdate)
        {
            var client = clients.FirstOrDefault(c => c.DNI == clientUpdate.DNI);

            if (client != null)
            {
                client.Nombre = clientUpdate.Nombre;
                client.Apellidos = clientUpdate.Apellidos;
                client.FechaNacimiento = clientUpdate.FechaNacimiento;
                client.Telefono = clientUpdate.Telefono;
                client.Email = clientUpdate.Email;
            }
        }
    }
}