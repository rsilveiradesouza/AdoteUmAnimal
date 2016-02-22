using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Aplicacao.DTOs;
using AdoteUmCao.Aplicacao.DTOs.Requisicao;
using AdoteUmCao.Aplicacao.DTOs.Resposta;
using AdoteUmCao.Infraestrutura.Entidades;
using AdoteUmCao.Infraestrutura.Repositorios;

namespace AdoteUmCao.Aplicacao.Servicos
{
    public class LoginServico : BaseServico
    {
        private UsuarioRepositorio UsuarioRepositorio;

        public LoginServico()
        {
            UsuarioRepositorio = new UsuarioRepositorio();
        }

        public UsuarioResposta EntrarViaFacebook(LoginFacebookRequisicao login)
        {
            UsuarioResposta retorno = new UsuarioResposta();

            //validar se o objeto login esta preenchido

            #region validar

            if (login == null)
            {
                this.resposta.Mensagens.Add("Dados de login não encontrado, tente novamente.");
            }
            else
            {
                if (string.IsNullOrEmpty(login.Token))
                {
                    this.resposta.Mensagens.Add("Dados de login não encontrado, tente novamente.");
                }
            }

            #endregion

            if (this.resposta.Sucesso)
            {
                Usuario entidade = new Usuario();

                //verificar se já existe algum usuario com esse usuarioId do facebook
                entidade = UsuarioRepositorio.GetSingle(u => u.UsuarioFacebookId == login.UsuarioId, "UsuarioAnimaisPreferencias");

                if (entidade == null)
                {
                    if (!string.IsNullOrEmpty(login.Email))
                    {
                        //verificar se já existe algum usuario com esse email que veio do facebook
                        entidade = UsuarioRepositorio.GetSingle(u => u.Email.ToUpper().Trim() == login.Email.ToUpper().Trim(), "UsuarioAnimaisPreferencias");
                    }

                    if (entidade == null)
                    {
                        //caso não tenho nenhum token e nenhum usuario com o email, cadastrar esse usuario na base e redirecionar ele para concluir o cadastramento
                        entidade = new Usuario();
                        entidade.TokenFacebook = login.Token;
                        entidade.UsuarioFacebookId = login.UsuarioId;
                        entidade.Nome = login.Nome;
                        entidade.Sobrenome = login.Sobrenome;
                        entidade.DataRegistro = DateTime.Now;
                        entidade.Ativo = true;
                        entidade.Token = GerarToken(entidade.Nome, entidade.DataRegistro.ToShortTimeString());

                        if (!string.IsNullOrEmpty(login.Email))
                        {
                            entidade.Email = login.Email;
                        }

                        UsuarioRepositorio.Add(entidade);
                        retorno.Usuario = new UsuarioDTO(entidade);
                    }
                    else
                    {
                        //caso tenha inserir/atualizar o token do facebook no usuario
                        entidade.TokenFacebook = login.Token;
                        entidade.UsuarioFacebookId = login.UsuarioId;
                        entidade.Token = GerarToken(entidade.Nome, entidade.DataRegistro.ToShortTimeString());

                        UsuarioRepositorio.Update(entidade);
                        retorno.Usuario = new UsuarioDTO(entidade);
                    }
                }
                else
                {
                    //caso já exista usuario na base com esse token do facebook, só é necessário atualizar o token dele
                    entidade.Token = GerarToken(entidade.Nome, entidade.DataRegistro.ToShortTimeString());
                    entidade.TokenFacebook = login.Token;

                    UsuarioRepositorio.Update(entidade);
                    retorno.Usuario = new UsuarioDTO(entidade);
                }
            }

            retorno.Mensagens = this.resposta.Mensagens;
            retorno.Sucesso = this.resposta.Sucesso;

            return retorno;
        }

        public UsuarioResposta VerificarLogin(string token)
        {
            UsuarioResposta retorno = new UsuarioResposta();

            #region validar

            if (string.IsNullOrEmpty(token))
            {
                this.resposta.Mensagens.Add("Usuário não encontrado.");
            }

            #endregion

            if (this.resposta.Sucesso)
            {
                Usuario entidade = new Usuario();

                entidade = UsuarioRepositorio.GetSingle(u => u.Token == token);

                if (entidade != null)
                {
                    retorno.Usuario = new UsuarioDTO(entidade);
                }
                else
                {
                    this.resposta.Mensagens.Add("Usuário não encontrado.");
                }
            }

            retorno.Mensagens = this.resposta.Mensagens;
            retorno.Sucesso = this.resposta.Sucesso;

            return retorno;
        }

        private string GerarToken(string nome, string dataRegistro)
        {
            string token = nome + ";" + dataRegistro + ";" + DateTime.Now.ToShortTimeString();

            var data = Encoding.ASCII.GetBytes(token);
            var hashData = new SHA1Managed().ComputeHash(data);
            var hash = string.Empty;
            foreach (var b in hashData)
                hash += b.ToString("X2");

            return hash;
        }
    }
}
