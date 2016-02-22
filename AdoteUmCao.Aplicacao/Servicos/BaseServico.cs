using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Aplicacao.DTOs;
using AdoteUmCao.Aplicacao.DTOs.Requisicao;
using AdoteUmCao.Aplicacao.DTOs.Resposta;

namespace AdoteUmCao.Aplicacao.Servicos
{

    public class BaseServico: IDisposable
    {
        protected BaseResposta resposta;
        public UsuarioDTO UsuarioLogado;

        /// <summary>
        /// Inicia as dependencias do BaseServico
        /// </summary>
        public BaseServico()
        {
            this.resposta = new BaseResposta();
            this.resposta.Mensagens = new List<string>();
            this.resposta.Sucesso = true;
            this.resposta.Autorizado = true;
        }

        public void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
