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
using System.Web;

namespace AdoteUmCao.WebApi.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("entrarViaFacebook", Name = "entrarViaFacebook")]
        public UsuarioResposta EntrarViaFacebook(LoginFacebookRequisicao login)
        {
            UsuarioResposta retorno = new UsuarioResposta();

            using (LoginServico LoginServico = new LoginServico())
            {
                retorno = LoginServico.EntrarViaFacebook(login);
            }

            return retorno;
        }

        [HttpPost]
        [Route("finalizarCadastro")]
        public UsuarioResposta FinalizarCadastro(FinalizarCadastroFacebookRequisicao usuario)
        {
            usuario.Token = Request.Headers.Authorization != null ? Request.Headers.Authorization.ToString() : "";
            UsuarioResposta retorno = new UsuarioResposta();

            using (LoginServico LoginServico = new LoginServico())
            {
                retorno = LoginServico.FinalizarCadastro(usuario);
            }

            return retorno;
        }


        [HttpPost]
        [Route("cadastrarUsuario")]
        public UsuarioResposta CadastrarUsuario(CadastroUsuarioRequisicao usuario)
        {
            UsuarioResposta retorno = new UsuarioResposta();

            using (LoginServico LoginServico = new LoginServico())
            {
                retorno = LoginServico.CadastrarUsuario(usuario);
            }

            return retorno;
        }

        [HttpGet]
        [Route("verificarLogin")]
        public UsuarioResposta VerificarLogin()
        {
            string token = Request.Headers.Authorization != null ? Request.Headers.Authorization.ToString() : "";

            UsuarioResposta retorno = new UsuarioResposta();

            using (LoginServico LoginServico = new LoginServico())
            {
                retorno = LoginServico.VerificarLogin(token);
            }

            return retorno;
        }

        [HttpGet]
        [Route("logar")]
        public UsuarioResposta Logar(string usuario, string senha)
        {
            UsuarioResposta retorno = new UsuarioResposta();

            using (LoginServico LoginServico = new LoginServico())
            {
                retorno = LoginServico.Logar(usuario, senha);
            }

            return retorno;
        }
    }
}