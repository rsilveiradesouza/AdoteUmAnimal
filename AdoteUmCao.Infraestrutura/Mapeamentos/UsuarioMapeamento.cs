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
    public class UsuarioMapeamento : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapeamento()
        {
            ToTable("USUARIOS");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Nome).HasColumnName("Nome");
            Property(e => e.Sobrenome).HasColumnName("Sobrenome");
            Property(e => e.Telefone).HasColumnName("Telefone");
            Property(e => e.Celular).HasColumnName("Celular");
            Property(e => e.Token).HasColumnName("Token");
            Property(e => e.TokenEmail).HasColumnName("Token_Email");
            Property(e => e.DataRegistro).HasColumnName("Data_Registro");
            Property(e => e.Email).HasColumnName("Email");
            Property(e => e.FotoUrl).HasColumnName("Foto_Url");
            Property(e => e.TokenFacebook).HasColumnName("Token_Facebook");
            Property(e => e.TokenTwitter).HasColumnName("Token_Twitter");
            Property(e => e.TokenGoogle).HasColumnName("Token_Google");
            Property(e => e.Ativo).HasColumnName("Ativo");
        }
    }
}
