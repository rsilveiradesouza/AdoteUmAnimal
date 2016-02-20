using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Web;
using System.Configuration;
using AdoteUmCao.Infraestrutura.Entidades;
using AdoteUmCao.Infraestrutura.Mapeamentos;

namespace Duloren.Infraestrutura
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("Contexto")
        {
            this.Database.Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdoteUmAnimal;Trusted_Connection=false;User Id=tobrasil; Password=duloren2;";
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Raca> Racas { get; set; }
        public DbSet<TipoAnimal> TiposAnimais { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioAnimalPreferencia> UsuariosAnimaisPreferencias { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<TipoOcorrencia> TiposOcorrencias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AnimalMapeamento());
            modelBuilder.Configurations.Add(new TipoMapeamento());
            modelBuilder.Configurations.Add(new RacaMapeamento());
            modelBuilder.Configurations.Add(new TipoAnimalMapeamento());
            modelBuilder.Configurations.Add(new CorMapeamento());
            modelBuilder.Configurations.Add(new UsuarioMapeamento());
            modelBuilder.Configurations.Add(new UsuarioAnimalPreferenciaMapeamento());
            modelBuilder.Configurations.Add(new OcorrenciaMapeamento());
            modelBuilder.Configurations.Add(new LocalizacaoMapeamento());
            modelBuilder.Configurations.Add(new TipoOcorrenciaMapeamento());
        }
    }
}
