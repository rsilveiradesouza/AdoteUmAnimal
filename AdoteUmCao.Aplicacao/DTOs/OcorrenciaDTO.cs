using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Infraestrutura.Entidades;

namespace AdoteUmCao.Aplicacao.DTOs
{
    public class OcorrenciaDTO
    {
        public OcorrenciaDTO()
        {

        }

        public OcorrenciaDTO(Ocorrencia ocorrencia)
        {
            this.Id = ocorrencia.Id;
            this.AnimalId = ocorrencia.AnimalId;
            this.UsuarioId = ocorrencia.UsuarioId;
            this.TipoOcorrenciaId = ocorrencia.TipoOcorrenciaId;
            this.LocalizacaoId = ocorrencia.LocalizacaoId;
            this.Descricao = ocorrencia.Descricao;
            this.DataCadastro = ocorrencia.DataCadastro;
            this.DataOcorrido = ocorrencia.DataOcorrido;
            this.Ativo = ocorrencia.Ativo;

            if (ocorrencia.TipoOcorrencia != null)
            {
                this.TipoOcorrencia = new TipoOcorrenciaDTO();
                this.TipoOcorrencia.Id = ocorrencia.TipoOcorrencia.Id;
                this.TipoOcorrencia.Nome = ocorrencia.TipoOcorrencia.Nome;
                this.TipoOcorrencia.Sigla = ocorrencia.TipoOcorrencia.Sigla;
            }

            if (ocorrencia.Localizacao != null)
            {
                this.Localizacao = new LocalizacaoDTO();
                this.Localizacao.Id = ocorrencia.Localizacao.Id;
                this.Localizacao.DscEndereco = ocorrencia.Localizacao.DscEndereco;
                this.Localizacao.Latitude = (double)ocorrencia.Localizacao.Latitude;
                this.Localizacao.Longitude = (double)ocorrencia.Localizacao.Longitude;
                this.Localizacao.GeoLocalizacao = ocorrencia.Localizacao.GeoLocalizacao;
            }

            if (ocorrencia.Usuario != null)
            {
                this.Usuario = new UsuarioDTO();
                this.Usuario.Id = ocorrencia.Usuario.Id;
                this.Usuario.Nome = ocorrencia.Usuario.Nome;
                this.Usuario.Sobrenome = ocorrencia.Usuario.Sobrenome;
                this.Usuario.DataRegistro = ocorrencia.Usuario.DataRegistro;
                this.Usuario.Token = ocorrencia.Usuario.Token;
                this.Usuario.TokenEmail = ocorrencia.Usuario.TokenEmail;
                this.Usuario.Telefone = ocorrencia.Usuario.Telefone;
                this.Usuario.Celular = ocorrencia.Usuario.Celular;
                this.Usuario.FotoUrl = ocorrencia.Usuario.FotoUrl;
                this.Usuario.Ativo = ocorrencia.Usuario.Ativo;
            }

            if (ocorrencia.Animal != null)
            {
                this.Animal = new AnimalDTO();
                this.Animal.Id = ocorrencia.Animal.Id;
                this.Animal.Nome = ocorrencia.Animal.Nome;
                this.Animal.FotoUrl = ocorrencia.Animal.FotoUrl;
                this.Animal.CorId = ocorrencia.Animal.CorId.HasValue ? (int)ocorrencia.Animal.CorId : 0;
                this.Animal.TipoAnimalId = ocorrencia.Animal.TipoAnimalId;
                this.Animal.Idade = ocorrencia.Animal.Idade.HasValue ? (int)ocorrencia.Animal.Idade : 0;
                this.Animal.Ativo = ocorrencia.Animal.Ativo;

                if (ocorrencia.Animal.Cor != null)
                {
                    this.Animal.Cor = new CorDTO();
                    this.Animal.Cor.Id = ocorrencia.Animal.Cor.Id;
                    this.Animal.Cor.Nome = ocorrencia.Animal.Cor.Nome;
                    this.Animal.Cor.Codigo = ocorrencia.Animal.Cor.Codigo;
                }

                if (ocorrencia.Animal.TipoAnimal != null)
                {
                    this.Animal.TipoAnimal = new TipoAnimalDTO();
                    this.Animal.TipoAnimal.Id = ocorrencia.Animal.TipoAnimal.Id;
                    this.Animal.TipoAnimal.TipoId = ocorrencia.Animal.TipoAnimal.TipoId;
                    this.Animal.TipoAnimal.RacaId = ocorrencia.Animal.TipoAnimal.RacaId.HasValue ? (int)ocorrencia.Animal.TipoAnimal.RacaId : 0;

                    if (ocorrencia.Animal.TipoAnimal.Tipo != null)
                    {
                        this.Animal.TipoAnimal.Tipo = new TipoDTO();
                        this.Animal.TipoAnimal.Tipo.Ativo = ocorrencia.Animal.TipoAnimal.Tipo.Ativo;
                        this.Animal.TipoAnimal.Tipo.FotoUrl = ocorrencia.Animal.TipoAnimal.Tipo.FotoUrl;
                        this.Animal.TipoAnimal.Tipo.Id = ocorrencia.Animal.TipoAnimal.Tipo.Id;
                        this.Animal.TipoAnimal.Tipo.Nome = ocorrencia.Animal.TipoAnimal.Tipo.Nome;
                    }

                    if (ocorrencia.Animal.TipoAnimal.Raca != null)
                    {
                        this.Animal.TipoAnimal.Raca = new RacaDTO();
                        this.Animal.TipoAnimal.Raca.Ativo = ocorrencia.Animal.TipoAnimal.Raca.Ativo;
                        this.Animal.TipoAnimal.Raca.FotoUrl = ocorrencia.Animal.TipoAnimal.Raca.FotoUrl;
                        this.Animal.TipoAnimal.Raca.Id = ocorrencia.Animal.TipoAnimal.Raca.Id;
                        this.Animal.TipoAnimal.Raca.Nome = ocorrencia.Animal.TipoAnimal.Raca.Nome;
                        this.Animal.TipoAnimal.Raca.TipoId = ocorrencia.Animal.TipoAnimal.Raca.TipoId;

                        if (ocorrencia.Animal.TipoAnimal.Raca.Tipo != null)
                        {
                            this.Animal.TipoAnimal.Raca.Tipo = new TipoDTO();
                            this.Animal.TipoAnimal.Raca.Tipo.Ativo = ocorrencia.Animal.TipoAnimal.Raca.Tipo.Ativo;
                            this.Animal.TipoAnimal.Raca.Tipo.FotoUrl = ocorrencia.Animal.TipoAnimal.Raca.Tipo.FotoUrl;
                            this.Animal.TipoAnimal.Raca.Tipo.Id = ocorrencia.Animal.TipoAnimal.Raca.Tipo.Id;
                            this.Animal.TipoAnimal.Raca.Tipo.Nome = ocorrencia.Animal.TipoAnimal.Raca.Tipo.Nome;
                        }
                    }
                }
            }
        }

        public int Id { get; set; }
        public int TipoOcorrenciaId { get; set; }
        public TipoOcorrenciaDTO TipoOcorrencia { get; set; }
        public int AnimalId { get; set; }
        public AnimalDTO Animal { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int LocalizacaoId { get; set; }
        public LocalizacaoDTO Localizacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataOcorrido { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
