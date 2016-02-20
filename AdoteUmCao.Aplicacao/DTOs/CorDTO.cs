using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.DTOs
{
    public class CorDTO
    {  
        public CorDTO()
        {

        }

        public CorDTO(CorDTO cor)
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
