using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.Mapeamentos
{
    class InventarioTypeConfiguration : ZombieResourcesEntityAbstractConfiguration<Inventario>
    {
        protected override void ConfigurarCampoTabela()
        {
            Property(P => P.Id)
                   .IsRequired()
                   .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                  .HasColumnName("INVENTARIO_ID");

            Property(P => P.RecursoId)
                   .IsRequired()
                  .HasColumnName("REC_ID");


            Property(P => P.SobreviventeId)
                   .IsRequired()
                  .HasColumnName("SOBR_ID");
                  
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
            ToTable("INV_INVENTARIO");
        }
    }
}