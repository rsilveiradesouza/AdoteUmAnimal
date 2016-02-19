using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Infraestrutura.Entidades;

namespace AdoteUmCao.Infraestrutura.Repositorios
{
    public class RacaRepositorio : BaseRepositorio<Raca>
    {
        public int TotalBusca(string busca)
        {
            return this.GetList(l => l.Nome.IndexOf(busca, StringComparison.InvariantCultureIgnoreCase) >= 0).Count;
        }
    }
}
