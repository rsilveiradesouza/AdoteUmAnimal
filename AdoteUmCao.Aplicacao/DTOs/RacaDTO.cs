using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Infraestrutura.Entidades;

namespace AdoteUmCao.Aplicacao.DTOs
{
    public class RacaDTO
    {
        public RacaDTO()
        {

        }

        public RacaDTO(Raca raca)
        {
            this.Id = raca.Id;
            this.TipoId = raca.TipoId;
            this.Nome = raca.Nome;
            this.FotoUrl = raca.FotoUrl;
            this.Ativo = raca.Ativo;

            if (raca.Tipo != null)
            {
                this.Tipo = new TipoDTO();
                this.Tipo.Ativo = raca.Tipo.Ativo;
                this.Tipo.FotoUrl = raca.Tipo.FotoUrl;
                this.Tipo.Id = raca.Tipo.Id;
                this.Tipo.Nome = raca.Tipo.Nome;
            }
        }

        public int Id { get; set; }
        public int TipoId { get; set; }
        public TipoDTO Tipo { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public bool Ativo { get; set; }
    }
}
