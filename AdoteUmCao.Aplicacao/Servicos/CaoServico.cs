using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Aplicacao.DTOs;
using AdoteUmCao.Aplicacao.DTOs.Resposta;

namespace AdoteUmCao.Aplicacao.Servicos
{
    public class CaoServico : BaseServico
    {
        public CaoServico()
        {

        }

        public CaesResposta ObterCaes()
        {
            CaesResposta retorno = new CaesResposta();
            List<CaoDTO> caes = new List<CaoDTO>();

            caes.Add(new CaoDTO() { Nome = "Cãozinho - 1" });
            caes.Add(new CaoDTO() { Nome = "Cãozinho - 2" });

            retorno.Caes = caes;

            return retorno;
        }
    }
}
