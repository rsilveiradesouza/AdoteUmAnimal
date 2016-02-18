using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.DTOs.Resposta
{
    public class CaesResposta : BaseResposta
    {
        public List<CaoDTO> Caes { get; set; }
    }
}
