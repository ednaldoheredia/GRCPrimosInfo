using GRC.Dominio.Model;
using Microsoft.EntityFrameworkCore;


namespace GRC.Data.Context
{
    public class GRCDbContext: DbContext
    {
        public GRCDbContext(DbContextOptions<GRCDbContext> dbContextOptions) : base(dbContextOptions) { }
        
        public DbSet<Cliente> Clientes { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GRCDbContext).Assembly);
        }

    }
}
