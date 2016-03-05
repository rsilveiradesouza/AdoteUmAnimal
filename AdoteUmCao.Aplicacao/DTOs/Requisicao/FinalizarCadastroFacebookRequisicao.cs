using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.DTOs.Requisicao
{
    public class FinalizarCadastroFacebookRequisicao : BaseRequisicao
    {
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Token { get; set; }
    }
}
