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
    public class AnimalMapeamento: EntityTypeConfiguration<Animal>
    {
        public AnimalMapeamento()
        {
            ToTable("ANIMAIS");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.FotoUrl).HasColumnName("Foto_Url");
            Property(e => e.Nome).HasColumnName("Nome");
            Property(e => e.Ativo).HasColumnName("Ativo");
            Property(e => e.TipoAnimalId).HasColumnName("Tipo_Animal_Id");
            Property(e => e.CorId).HasColumnName("CorId");
            Property(e => e.Idade).HasColumnName("Idade");

            HasRequired(e => e.TipoAnimal).WithMany().HasForeignKey(e => e.TipoAnimalId);
            HasOptional(e => e.Cor).WithMany().HasForeignKey(e => e.CorId);
        }
    }
}
