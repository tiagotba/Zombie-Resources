using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.Mapeamentos
{
    class SobreviventesTypeConfiguration : ZombieResourcesEntityAbstractConfiguration<Sobrevivente>
    {
        protected override void ConfigurarCampoTabela()
        {
            Property(P => P.Id)
                   .IsRequired()
                   .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                  .HasColumnName("SOBR_ID");

            Property(P => P.Nome)
                   .IsRequired()
                  .HasColumnName("SOBR_NOME")
                  .HasMaxLength(100);

            Property(P => P.Idade)
                   .IsRequired()
                  .HasColumnName("SOBR_IDADE");

            Property(P => P.Genero)
                 .IsOptional()
                 .HasColumnName("SOBR_GENERO")
                 .HasMaxLength(2);
        }

        protected override void ConfigurarChaveEstrangeira()
        {
          
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("SOBR_SOBREVIVENTES");
        }
    }
}