using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Infraestrutura.Entidades
{
    public class Cor
    {
        public Cor()
        {

        }

        public Cor(Cor cor)
        {
            this.Id = cor.Id;
            this.Nome = cor.Nome;
            this.Codigo = cor.Codigo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
