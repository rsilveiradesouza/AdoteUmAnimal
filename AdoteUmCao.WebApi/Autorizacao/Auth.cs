using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using AdoteUmCao.Aplicacao.DTOs.Resposta;
using AdoteUmCao.Aplicacao.Servicos;

namespace AdoteUmCao.WebApi.Autorizacao
{
    public class Auth : AuthorizeAttribute
    {
        public int Prioridades { get; set; }

        public Auth()
        {
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string token = actionContext.Request.Headers.Authorization != null ? actionContext.Request.Headers.Authorization.ToString() : "";

            UsuarioResposta retorno = new UsuarioResposta();

            if (!string.IsNullOrEmpty(token))
            {
                //TODO: Verificar se esse token é valido, caso não seja retornar erro.
                using (LoginServico LoginServico = new LoginServico())
                {
                    retorno = LoginServico.VerificarLogin(token);

                    if (!retorno.Sucesso)
                    {
                        retorno.Autorizado = false;
                        retorno.RetornoUrl = actionContext.Request.RequestUri.AbsolutePath;
                    }

                    actionContext.Request.Properties.Add("usuario", retorno);
                }
            }
            else
            {
                retorno.Sucesso = false;
                retorno.Mensagens = new List<string>();
                retorno.Mensagens.Add("Usuário não encontrado.");
                retorno.Autorizado = false;
                retorno.RetornoUrl = actionContext.Request.RequestUri.AbsolutePath;

                actionContext.Request.Properties.Add("usuario", retorno);
            }

            return true;
        }
    }
}