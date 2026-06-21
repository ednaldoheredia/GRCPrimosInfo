using GRC.Dominio.Interfaces;
using GRC.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Dominio.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }
        public async Task<bool> Adicionar(Cliente cliente)
        {
            return await _clienteRepository.Adicionar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
