using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.Mapeamentos
{
    class RecursosTypeConfiguration : ZombieResourcesEntityAbstractConfiguration<Recursos>
    {
        protected override void ConfigurarCampoTabela()
        {
            Property(P => P.Id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                   .HasColumnName("REC_ID");

            Property(P => P.Descricao)
                   .IsRequired()
                  .HasColumnName("REC_DESC")
                  .HasMaxLength(100);

            Property(P => P.Observacao)
                   .IsOptional()
                  .HasColumnName("REC_OBS")
                  .HasMaxLength(100);

            Property(P => P.Quantidade)
                  .IsRequired()
                 .HasColumnName("REC_QTD");

        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(p => p.Sobrevivente)
                 .WithMany(p => p.Recursos)
                 .HasForeignKey(fk => fk.IdSobrevivente);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("REC_RECURSOS");
        }
    }
}