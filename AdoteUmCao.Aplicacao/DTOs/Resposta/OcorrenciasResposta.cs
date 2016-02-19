using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.DTOs.Resposta
{
    public class OcorrenciasResposta : BaseResposta
    {
        public List<OcorrenciaDTO> Ocorrencias { get; set; }
    }
}
