using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
    }
}