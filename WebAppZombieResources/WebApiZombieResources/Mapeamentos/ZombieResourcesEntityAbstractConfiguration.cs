using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiZombieResources.Mapeamentos
{
   public abstract class ZombieResourcesEntityAbstractConfiguration<TEntidade> : EntityTypeConfiguration<TEntidade>
         where TEntidade : class
    {
        public ZombieResourcesEntityAbstractConfiguration()
        {
            ConfigurarNomeTabela();
            ConfigurarCampoTabela();
            ConfigurarChavePrimaria();
            ConfigurarChaveEstrangeira();
        }
        protected abstract void ConfigurarChaveEstrangeira();


        protected abstract void ConfigurarChavePrimaria();


        protected abstract void ConfigurarCampoTabela();


        protected abstract void ConfigurarNomeTabela();
    }
}
