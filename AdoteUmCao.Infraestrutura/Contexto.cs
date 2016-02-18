using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Web;
using System.Configuration;

namespace Duloren.Infraestrutura
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("Contexto")
        {
            this.Database.Connection.ConnectionString = @"Data Source=PCPE01K920\SQLEXPRESS;Initial Catalog=DulorenNovo;Trusted_Connection=false;User Id=tobrasil; Password=duloren2;";
        }

        //public DbSet<Logo> Logos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new LogoMapeamento());
        }
    }
}
