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
    public class OcorrenciaMapeamento : EntityTypeConfiguration<Ocorrencia>
    {
        public OcorrenciaMapeamento()
        {
            ToTable("OCORRENCIAS");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.AnimalId).HasColumnName("AnimalId");
            Property(e => e.UsuarioId).HasColumnName("UsuarioId");
            Property(e => e.TipoOcorrenciaId).HasColumnName("Tipo_Ocorrencia_Id");
            Property(e => e.LocalizacaoId).HasColumnName("LocalizacaoId");
            Property(e => e.DataCadastro).HasColumnName("Data_Cadastro");
            Property(e => e.DataOcorrido).HasColumnName("Data_Ocorrido");
            Property(e => e.Descricao).HasColumnName("Descricao");
            Property(e => e.Ativo).HasColumnName("Ativo");

            HasRequired(e => e.Animal).WithMany().HasForeignKey(e => e.AnimalId);
            HasRequired(e => e.Usuario).WithMany().HasForeignKey(e => e.UsuarioId);
            HasRequired(e => e.Localizacao).WithMany().HasForeignKey(e => e.LocalizacaoId);
            HasRequired(e => e.TipoOcorrencia).WithMany().HasForeignKey(e => e.TipoOcorrenciaId);
        }
    }
}
