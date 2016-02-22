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
    public class BaseController : ApiController
    {
        public UsuarioResposta ObterUsuarioAuth()
        {
            return (UsuarioResposta)Request.Properties.Where(c => c.Key == "usuario").Select(c => c.Value).FirstOrDefault();
        }
    }
}