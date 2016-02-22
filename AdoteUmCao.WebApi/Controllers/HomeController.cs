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
            UsuarioResposta usuario = this.ObterUsuarioAuth();
            OcorrenciasResposta retorno = new OcorrenciasResposta();

            if (!usuario.Sucesso)
            {
                retorno.Sucesso = usuario.Sucesso;
                retorno.RetornoUrl = usuario.RetornoUrl;
                retorno.Mensagens = usuario.Mensagens;
                retorno.Autorizado = usuario.Autorizado;
            }
            else
            {
                using (OcorrenciaServico OcorrenciaServico = new OcorrenciaServico())
                {
                    retorno = OcorrenciaServico.ObterOcorrenciasMapa(swLat, swLng, neLat, neLng);
                }
            }

            return retorno;
        }

        public UsuarioResposta ObterUsuarioAuth()
        {
            return (UsuarioResposta)Request.Properties.Where(c => c.Key == "usuario").Select(c => c.Value).FirstOrDefault();
        }
    }
}