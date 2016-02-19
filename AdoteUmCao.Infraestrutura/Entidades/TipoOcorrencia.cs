using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Infraestrutura.Entidades
{
    public class TipoOcorrencia
    {
        public TipoOcorrencia()
        {

        }

        public TipoOcorrencia(TipoOcorrencia tipoOcorrencia)
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
