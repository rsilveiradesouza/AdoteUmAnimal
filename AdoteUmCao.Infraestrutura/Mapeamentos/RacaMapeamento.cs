using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Infraestrutura.Entidades;

namespace AdoteUmCao.Infraestrutura.Mapeamentos
{
    public class RacaMapeamento: EntityTypeConfiguration<Raca>
    {
        public RacaMapeamento()
        {
            ToTable("RACAS");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.FotoUrl).HasColumnName("Foto_Url");
            Property(e => e.Nome).HasColumnName("Nome");
            Property(e => e.Ativo).HasColumnName("Ativo");
            Property(e => e.TipoId).HasColumnName("TipoId");

            HasRequired(e => e.Tipo).WithMany().HasForeignKey(e => e.TipoId);
        }
    }
}
