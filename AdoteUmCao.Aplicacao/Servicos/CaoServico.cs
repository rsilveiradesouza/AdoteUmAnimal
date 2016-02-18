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

        public CaesResposta ObterCaes(double SwLat, double SwLng, double NeLat, double NeLng)
        {
            CaesResposta retorno = new CaesResposta();
            List<CaoDTO> caes = new List<CaoDTO>();

            caes.Add(new CaoDTO() { Nome = "Negona", Localizacao = new LocalizacaoDTO() { Lat = -22.9057162, Lng = -43.17620840000001, Endereco = "Rua são josé, 70, Centro - Rio de Janeiro" } });
            caes.Add(new CaoDTO() { Nome = "Pretinha", Localizacao = new LocalizacaoDTO() { Lat = -22.90364, Lng = -43.17294909999998, Endereco = "Rua são josé, 1, Centro - Rio de Janeiro" } });

            caes = caes.Where(c => (SwLat < NeLat && c.Localizacao.Lat >= SwLat && c.Localizacao.Lat <= NeLat) || (NeLat < SwLat && c.Localizacao.Lat >= NeLat && c.Localizacao.Lat <= SwLat)).ToList();

            caes = caes.Where(c => (SwLng < NeLng && c.Localizacao.Lng >= SwLng && c.Localizacao.Lng <= NeLng) || (NeLng < SwLng && c.Localizacao.Lng >= NeLng && c.Localizacao.Lng <= SwLng)).ToList();

            retorno.Caes = caes;

            retorno.Mensagens = this.resposta.Mensagens;
            retorno.Sucesso = this.resposta.Sucesso;

            return retorno;
        }
    }
}
