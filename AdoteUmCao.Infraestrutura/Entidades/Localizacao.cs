using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Infraestrutura.Entidades
{
    public class Localizacao
    {
        public Localizacao()
        {

        }

        public Localizacao(Localizacao localizacao)
        {
            this.Id = localizacao.Id;
            this.DscEndereco = localizacao.DscEndereco;
            this.Latitude = localizacao.Latitude;
            this.Longitude = localizacao.Longitude;
            this.GeoLocalizacao = localizacao.GeoLocalizacao;
        }

        public int Id { get; set; }
        public string DscEndereco { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string GeoLocalizacao { get; set; }
    }
}
