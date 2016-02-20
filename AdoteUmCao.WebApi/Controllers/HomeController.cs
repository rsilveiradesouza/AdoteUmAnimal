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
        [Route("obterOcorrencias")]
        [Auth]
        public OcorrenciasResposta ObterOcorrencias(double swLat, double swLng, double neLat, double neLng)
        {
            using (OcorrenciaServico OcorrenciaServico = new OcorrenciaServico())
            {
                OcorrenciasResposta retorno = new OcorrenciasResposta();
                retorno = OcorrenciaServico.ObterOcorrenciasMapa(swLat, swLng, neLat, neLng);

                return retorno;
            }
        }
    }
}