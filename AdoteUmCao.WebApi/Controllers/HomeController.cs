using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdoteUmCao.Aplicacao.Servicos;
using AdoteUmCao.Aplicacao.DTOs.Resposta;
using AdoteUmCao.WebApi.Autorizacao;

namespace AdoteUmCao.WebApi.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("obterCaes")]
        [Auth]
        public CaesResposta ObterCaes(double swLat, double swLng, double neLat, double neLng)
        {
            using (CaoServico CaoServico = new CaoServico())
            {
                CaesResposta retorno = new CaesResposta();
                retorno = CaoServico.ObterCaes(swLat, swLng, neLat, neLng);

                return retorno;
            }
        }
    }
}