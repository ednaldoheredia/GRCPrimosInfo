using Clientes.Dominio.Interfaces;
using Clientes.Dominio.Model;
using GRC.Dominio.Model;

namespace GRC.Dominio.Interfaces
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Remover(Guid id);
       
       

    }
}
