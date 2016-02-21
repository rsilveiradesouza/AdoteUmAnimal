using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.DTOs.Requisicao
{
    public class LoginFacebookRequisicao : BaseRequisicao
    {
        public string Token { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
    }
}
