using Microsoft.EntityFrameworkCore;
using Vagas.API.Entities;

namespace Vagas.API.Data
{
    public class VagasDbContext : DbContext
    {
        public VagasDbContext(DbContextOptions<VagasDbContext> opts) : base(opts)
        { }

        public DbSet<Vaga> Vagas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaga>(o =>
            {
                o.HasKey(x => x.IdVaga);
            });
        }
    }
}
