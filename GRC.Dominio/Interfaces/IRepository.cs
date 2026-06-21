using Clientes.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Dominio.Interfaces
{
    public  interface IRepository<TEntity>: IDisposable where TEntity : class
    {
        Task<bool> Adicionar(TEntity entity);
        Task<IList<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(Guid id);

    }
}
