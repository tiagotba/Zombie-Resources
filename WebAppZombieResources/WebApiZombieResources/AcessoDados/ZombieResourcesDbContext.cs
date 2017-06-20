using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiZombieResources.Mapeamentos;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.AcessoDados
{
    public class ZombieResourcesDbContext : DbContext
    {
        public ZombieResourcesDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Recursos> Recursos { get; set; }
        public DbSet<Sobrevivente> Sobreviventes { get; set; }
        public DbSet<Inventario> Inventario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recursos>()
                .HasMany(r => r.Sobreviventes)
                .WithMany(s => s.Recursos)
                .Map(x =>
                {
                    x.MapLeftKey("REC_ID");
                    x.MapRightKey("SOBR_ID");
                    x.ToTable("INV_INVENTARIO");
                }

              );

            modelBuilder.Configurations.Add(new RecursosTypeConfiguration());
            modelBuilder.Configurations.Add(new SobreviventesTypeConfiguration());
            modelBuilder.Configurations.Add(new InventarioTypeConfiguration());
        }
    }
}