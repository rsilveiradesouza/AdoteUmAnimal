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
using System.IO;

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

                if (retorno.Sucesso)
                {
                    try
                    {
                        DownloadRemoteImageFile(login.UsuarioId, HttpRuntime.AppDomainAppPath + "\\imagens\\perfil\\" + retorno.Usuario.Id + "\\perfil.jpg");
                    }
                    catch
                    {
                        retorno.Mensagens.Add("Problema ao tentar obter sua foto do facebook, tente novamente.");
                    }
                }
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

        private void DownloadRemoteImageFile(string id, string fileName)
        {
            string uri = "http://graph.facebook.com/" + id + "/picture?type=large";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {
                string diretorio = Path.GetDirectoryName(fileName);

                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }
    }
}