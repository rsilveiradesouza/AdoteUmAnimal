using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.DTOs.Resposta
{
    public class BaseResposta
    {
        /// <summary>
        /// Lista de mensagens de erro
        /// </summary>
        public List<string> Mensagens { get; set; }

        /// <summary>
        /// Informa se a operação foi realizada com sucesso
        /// </summary>
        /// 
        private bool _sucesso;
        public bool Sucesso
        {
            get
            {
                if (this.Mensagens != null && this.Mensagens.Any())
                {
                    this._sucesso = false;
                    return false;
                }
                _sucesso = true;
                return true;
            }
            set { this._sucesso = value; }
        }
    }
}
