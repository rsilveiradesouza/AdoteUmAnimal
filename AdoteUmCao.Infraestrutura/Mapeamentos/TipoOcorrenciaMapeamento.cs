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
    public class TipoOcorrenciaMapeamento : EntityTypeConfiguration<TipoOcorrencia>
    {
        public TipoOcorrenciaMapeamento()
        {
            ToTable("TIPOS_OCORRENCIAS");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Nome).HasColumnName("Nome");
            Property(e => e.Sigla).HasColumnName("Sigla");
        }
    }
}
