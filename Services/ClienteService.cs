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
        // Repositorio encargado de manejar la persistencia de los datos
        private readonly ClienteRepository repository;
        // Lista en memoria que contiene los clientes cargados desde el repositorio
        private List<Cliente> clients;

        // Constructor del servicio.
        // Recibe el repositorio mediante inyección de dependencias
        // y carga todos los clientes existentes.
        public ClienteService(ClienteRepository repo)
        {
            repository = repo;
            clients = repository.GetAll();
        }
        // Devuelve la lista completa de clientes almacenados en memoria
        public List<Cliente> GetClients()
        {
            return clients;
        }
        // Crea un nuevo cliente y lo agrega a la lista
        public void CreateClient(Cliente client)
        {
            clients.Add(client);
        }
        // Elimina un cliente existente de la lista
        public void DeleteClient(Cliente client)
        {
            clients.Remove(client);
        }
        // Guarda todos los cambios realizados en la lista de clientes
        // utilizando el repositorio (persistencia en archivo)
        public void Save()
        {
            repository.SaveAll(clients);
        }
        // Actualiza los datos de un cliente existente
        public void UpdateClient(Cliente clientUpdate)
        {
            // Busca el cliente por su DNI
            var client = clients.FirstOrDefault(c => c.DNI == clientUpdate.DNI);

            // Si el cliente existe, se actualizan sus propiedades
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