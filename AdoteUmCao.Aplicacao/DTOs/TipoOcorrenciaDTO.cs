using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Infraestrutura.Entidades;

namespace AdoteUmCao.Aplicacao.DTOs
{
    public class TipoOcorrenciaDTO
    {
        public TipoOcorrenciaDTO()
        {

        }

        public TipoOcorrenciaDTO(TipoOcorrencia tipoOcorrencia)
        {
            this.Id = tipoOcorrencia.Id;
            this.Nome = tipoOcorrencia.Nome;
            this.Sigla = tipoOcorrencia.Sigla;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
