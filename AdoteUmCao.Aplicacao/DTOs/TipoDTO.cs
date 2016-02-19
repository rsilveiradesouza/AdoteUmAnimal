using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Infraestrutura.Entidades;

namespace AdoteUmCao.Aplicacao.DTOs
{
    public class TipoDTO
    {
        public TipoDTO()
        {

        }

        public TipoDTO(Tipo tipo)
        {
            this.Id = tipo.Id;
            this.Nome = tipo.Nome;
            this.FotoUrl = tipo.FotoUrl;
            this.Ativo = tipo.Ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public bool Ativo { get; set; }
    }
}
