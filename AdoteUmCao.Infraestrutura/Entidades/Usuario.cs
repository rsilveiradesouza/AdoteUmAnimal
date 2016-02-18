using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Infraestrutura.Entidades
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(Usuario usuario)
        {
            this.Nome = usuario.Nome;
        }

        public string Nome { get; set; }
    }
}
