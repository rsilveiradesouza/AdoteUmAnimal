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
    public class LocalizacaoMapeamento : EntityTypeConfiguration<Localizacao>
    {
        public LocalizacaoMapeamento()
        {
            ToTable("LOCALIZACOES");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.DscEndereco).HasColumnName("Dsc_Endereco");
            Property(e => e.Latitude).HasColumnName("Latitude");
            Property(e => e.Longitude).HasColumnName("Longitude");
            Property(e => e.GeoLocalizacao).HasColumnName("GeoLocalizacao");
        }
    }
}
