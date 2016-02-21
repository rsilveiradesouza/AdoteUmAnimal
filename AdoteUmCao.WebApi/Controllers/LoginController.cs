using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdoteUmCao.Aplicacao.Servicos;
using AdoteUmCao.Aplicacao.DTOs.Resposta;
using AdoteUmCao.WebApi.Autorizacao;
using AdoteUmCao.Aplicacao.DTOs;
using AdoteUmCao.Aplicacao.DTOs.Requisicao;

namespace AdoteUmCao.WebApi.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("entrarViaFacebook")]
        public UsuarioResposta EntrarViaFacebook(LoginFacebookRequisicao login)
        {
            UsuarioResposta retorno = new UsuarioResposta();

            using (LoginServico LoginServico = new LoginServico())
            {
                retorno = LoginServico.EntrarViaFacebook(login);
            }

            return retorno;
        }
    }
}