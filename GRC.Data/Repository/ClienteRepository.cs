using GRC.Data.Context;
using GRC.Dominio.Interfaces;
using GRC.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Data.Repository
{
    public class ClienteRepository :Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(GRCDbContext gRCDbContext) : base(gRCDbContext) { }

        public virtual async Task<bool> Adicionar(Cliente cliente)
        {
            _gRCDbContext.Clientes.Add(cliente);

            return await _gRCDbContext.SaveChangesAsync() > 0;
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
