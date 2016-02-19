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
    public class TipoAnimalMapeamento: EntityTypeConfiguration<TipoAnimal>
    {
        public TipoAnimalMapeamento()
        {
            ToTable("TIPOS_ANIMAIS");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.RacaId).HasColumnName("RacaId");
            Property(e => e.TipoId).HasColumnName("TipoId");

            HasRequired(e => e.Tipo).WithMany().HasForeignKey(e => e.TipoId);
            HasOptional(e => e.Raca).WithMany().HasForeignKey(e => e.RacaId);
        }
    }
}
