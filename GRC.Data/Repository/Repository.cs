using Clientes.Dominio.Interfaces;
using Clientes.Dominio.Model;
using GRC.Data.Context;
using GRC.Dominio.Interfaces;
using GRC.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity,new()
    {
        protected readonly GRCDbContext _gRCDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(GRCDbContext gRCDbContext)
        {
            this._gRCDbContext = gRCDbContext;
            this._dbSet = _gRCDbContext.Set<TEntity>();
        }
       
        public virtual async Task<bool> Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            return await Task.FromResult(_gRCDbContext.SaveChanges() > 0);
        }

        public void Dispose()
        {
            _gRCDbContext.Dispose();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IList<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }
    }
}