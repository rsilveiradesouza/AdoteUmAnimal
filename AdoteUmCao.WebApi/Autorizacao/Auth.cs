using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

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

            if (!string.IsNullOrEmpty(token))
            {
                //TODO: Verificar se esse token é valido, caso não seja retornar erro.

                return true;
            }
            else
            {
                return true;

                //HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                //message.Content = new StringContent("Você não está autorizado a fazer isso!");
                //throw new HttpResponseException(message);
            }
        }
    }
}