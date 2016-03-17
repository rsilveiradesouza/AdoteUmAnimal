using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Aplicacao.DTOs;
using AdoteUmCao.Aplicacao.DTOs.Resposta;
using AdoteUmCao.Infraestrutura.Entidades;
using AdoteUmCao.Infraestrutura.Repositorios;

namespace AdoteUmCao.Aplicacao.Servicos
{
    public class OcorrenciaServico : BaseServico
    {
        private OcorrenciaRepositorio OcorrenciaRepositorio;

        public OcorrenciaServico()
        {
            OcorrenciaRepositorio = new OcorrenciaRepositorio();
        }

        public OcorrenciasResposta ObterOcorrenciasMapa(double SwLat, double SwLng, double NeLat, double NeLng)
        {
            OcorrenciasResposta retorno = new OcorrenciasResposta();
            List<OcorrenciaDTO> ocorrencias = new List<OcorrenciaDTO>();
            List<Ocorrencia> entidades = new List<Ocorrencia>();

            entidades = OcorrenciaRepositorio.GetList(o => o.Ativo, "TipoOcorrencia", "Animal", "Animal.Cor", "Animal.TipoAnimal", "Animal.TipoAnimal.Tipo", "Animal.TipoAnimal.Raca", "Animal.TipoAnimal.Raca.Tipo", "Usuario", "Usuario.UsuarioAnimaisPreferencias", "Localizacao");

            entidades = entidades.Where(c => (SwLat < NeLat && (double)c.Localizacao.Latitude >= SwLat && (double)c.Localizacao.Latitude <= NeLat) || (NeLat < SwLat && (double)c.Localizacao.Latitude >= NeLat && (double)c.Localizacao.Latitude <= SwLat)).ToList();

            entidades = entidades.Where(c => (SwLng < NeLng && (double)c.Localizacao.Longitude >= SwLng && (double)c.Localizacao.Longitude <= NeLng) || (NeLng < SwLng && (double)c.Localizacao.Longitude >= NeLng && (double)c.Localizacao.Longitude <= SwLng)).ToList();

            foreach (var entidade in entidades)
            {
                ocorrencias.Add(new OcorrenciaDTO(entidade));
            }

            retorno.Ocorrencias = ocorrencias;

            retorno.Mensagens = this.resposta.Mensagens;
            retorno.Sucesso = this.resposta.Sucesso;

            return retorno;
        }

        public OcorrenciasResposta ObterOcorrenciasUltimas()
        {
            OcorrenciasResposta retorno = new OcorrenciasResposta();
            List<OcorrenciaDTO> ocorrencias = new List<OcorrenciaDTO>();
            List<Ocorrencia> entidades = new List<Ocorrencia>();

            entidades = OcorrenciaRepositorio.GetList(o => o.Ativo, "TipoOcorrencia", "Animal", "Animal.Cor", "Animal.TipoAnimal", "Animal.TipoAnimal.Tipo", "Animal.TipoAnimal.Raca", "Animal.TipoAnimal.Raca.Tipo", "Usuario", "Usuario.UsuarioAnimaisPreferencias", "Localizacao");

            foreach (var entidade in entidades)
            {
                ocorrencias.Add(new OcorrenciaDTO(entidade));
            }

            retorno.Ocorrencias = ocorrencias;

            retorno.Mensagens = this.resposta.Mensagens;
            retorno.Sucesso = this.resposta.Sucesso;

            return retorno;
        }
    }
}
