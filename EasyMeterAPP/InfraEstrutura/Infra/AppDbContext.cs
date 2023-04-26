using EasyMeterAPP.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace EasyMeterAPP.InfraEstrutura.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Condominio> CONDOMINIO { get; set; }
        public DbSet<Bloco> BLOCO { get; set; }
        public DbSet<Unidade> UNIDADE { get; set; }
        public DbSet<Medicao> MEDICAO { get; set; }


    }
}
