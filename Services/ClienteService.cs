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

        public ClienteService(ClienteRepository repository)
        {
            this.repository = repository;
        }

        public List<Cliente> ObtenerClientes()
        {
            return repository.GetAll();
        }

        public void CrearCliente(Cliente cliente)
        {
            repository.Add(cliente);
        }

        public void EliminarCliente(string dni)
        {
            repository.Delete(dni);
        }
    }
}