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
    public class UsuarioAnimalPreferenciaMapeamento: EntityTypeConfiguration<UsuarioAnimalPreferencia>
    {
        public UsuarioAnimalPreferenciaMapeamento()
        {
            ToTable("USUARIOS_ANIMAIS_PREFERENCIAS");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.AnimalId).HasColumnName("AnimalId");
            Property(e => e.UsuarioId).HasColumnName("UsuarioId");
            Property(e => e.Ativo).HasColumnName("Ativo");

            HasRequired(e => e.Animal).WithMany().HasForeignKey(e => e.AnimalId);
            //HasRequired(e => e.Usuario).WithMany().HasForeignKey(e => e.UsuarioId);
        }
    }
}
