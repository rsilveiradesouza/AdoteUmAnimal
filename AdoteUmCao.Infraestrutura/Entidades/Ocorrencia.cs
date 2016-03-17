using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Infraestrutura.Entidades
{
    public class Ocorrencia
    {
        public Ocorrencia()
        {

        }

        public Ocorrencia(Ocorrencia ocorrencia)
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
            this.Visualizacoes = ocorrencia.Visualizacoes;

            if (ocorrencia.TipoOcorrencia != null)
            {
                this.TipoOcorrencia = new TipoOcorrencia();
                this.TipoOcorrencia.Id = ocorrencia.TipoOcorrencia.Id;
                this.TipoOcorrencia.Nome = ocorrencia.TipoOcorrencia.Nome;
                this.TipoOcorrencia.Sigla = ocorrencia.TipoOcorrencia.Sigla;
            }

            if (ocorrencia.Localizacao != null)
            {
                this.Localizacao = new Localizacao();
                this.Localizacao.Id = ocorrencia.Localizacao.Id;
                this.Localizacao.DscEndereco = ocorrencia.Localizacao.DscEndereco;
                this.Localizacao.Latitude = ocorrencia.Localizacao.Latitude;
                this.Localizacao.Longitude = ocorrencia.Localizacao.Longitude;
                this.Localizacao.GeoLocalizacao = ocorrencia.Localizacao.GeoLocalizacao;
            }

            if (ocorrencia.Usuario != null)
            {
                this.Usuario = new Usuario();
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

                if (ocorrencia.Usuario.UsuarioAnimaisPreferencias != null)
                {
                    this.Usuario.UsuarioAnimaisPreferencias = new List<UsuarioAnimalPreferencia>();

                    for (int i = 0; i < ocorrencia.Usuario.UsuarioAnimaisPreferencias.Count; i++)
                    {
                        UsuarioAnimalPreferencia uap = new UsuarioAnimalPreferencia();
                        uap.AnimalId = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].AnimalId;
                        uap.Ativo = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Ativo;
                        uap.Id = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Id;
                        uap.UsuarioId = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].UsuarioId;

                        if (ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal != null)
                        {
                            uap.Animal = new Animal();
                            uap.Animal.Id = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Id;
                            uap.Animal.Nome = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Nome;
                            uap.Animal.FotoUrl = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.FotoUrl;
                            uap.Animal.CorId = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.CorId.HasValue ? (int)ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.CorId : 0;
                            uap.Animal.TipoAnimalId = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimalId;
                            uap.Animal.Idade = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Idade.HasValue ? (int)ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Idade : 0;
                            uap.Animal.Ativo = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Ativo;

                            if (ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Cor != null)
                            {
                                uap.Animal.Cor = new Cor();
                                uap.Animal.Cor.Id = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Cor.Id;
                                uap.Animal.Cor.Nome = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Cor.Nome;
                                uap.Animal.Cor.Codigo = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.Cor.Codigo;
                            }

                            if (ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal != null)
                            {
                                uap.Animal.TipoAnimal.Id = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Id;
                                uap.Animal.TipoAnimal.TipoId = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.TipoId;
                                uap.Animal.TipoAnimal.RacaId = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.RacaId.HasValue ? (int)ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.RacaId : 0;

                                if (ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo != null)
                                {
                                    uap.Animal.TipoAnimal.Tipo = new Tipo();
                                    uap.Animal.TipoAnimal.Tipo.Ativo = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.Ativo;
                                    uap.Animal.TipoAnimal.Tipo.FotoUrl = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.FotoUrl;
                                    uap.Animal.TipoAnimal.Tipo.Id = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.Id;
                                    uap.Animal.TipoAnimal.Tipo.Nome = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.Nome;
                                }

                                if (ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca != null)
                                {
                                    uap.Animal.TipoAnimal.Raca = new Raca();
                                    uap.Animal.TipoAnimal.Raca.Ativo = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Ativo;
                                    uap.Animal.TipoAnimal.Raca.FotoUrl = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.FotoUrl;
                                    uap.Animal.TipoAnimal.Raca.Id = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Id;
                                    uap.Animal.TipoAnimal.Raca.Nome = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Nome;

                                    if (ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo != null)
                                    {
                                        uap.Animal.TipoAnimal.Raca.Tipo = new Tipo();
                                        uap.Animal.TipoAnimal.Raca.Tipo.Ativo = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.Ativo;
                                        uap.Animal.TipoAnimal.Raca.Tipo.FotoUrl = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.FotoUrl;
                                        uap.Animal.TipoAnimal.Raca.Tipo.Id = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.Id;
                                        uap.Animal.TipoAnimal.Raca.Tipo.Nome = ocorrencia.Usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.Nome;
                                    }
                                }
                            }
                        }

                        this.Usuario.UsuarioAnimaisPreferencias.Add(uap);
                    }
                }

                if (ocorrencia.Animal != null)
                {
                    this.Animal = new Animal();
                    this.Animal.Id = ocorrencia.Animal.Id;
                    this.Animal.Nome = ocorrencia.Animal.Nome;
                    this.Animal.FotoUrl = ocorrencia.Animal.FotoUrl;
                    this.Animal.CorId = ocorrencia.Animal.CorId;
                    this.Animal.TipoAnimalId = ocorrencia.Animal.TipoAnimalId;
                    this.Animal.Idade = ocorrencia.Animal.Idade;
                    this.Animal.Ativo = ocorrencia.Animal.Ativo;

                    if (ocorrencia.Animal.Cor != null)
                    {
                        this.Animal.Cor = new Cor();
                        this.Animal.Cor.Id = ocorrencia.Animal.Cor.Id;
                        this.Animal.Cor.Nome = ocorrencia.Animal.Cor.Nome;
                        this.Animal.Cor.Codigo = ocorrencia.Animal.Cor.Codigo;
                    }

                    if (ocorrencia.Animal.TipoAnimal != null)
                    {
                        this.Animal.TipoAnimal.Id = ocorrencia.Animal.TipoAnimal.Id;
                        this.Animal.TipoAnimal.TipoId = ocorrencia.Animal.TipoAnimal.TipoId;
                        this.Animal.TipoAnimal.RacaId = ocorrencia.Animal.TipoAnimal.RacaId;

                        if (ocorrencia.Animal.TipoAnimal.Tipo != null)
                        {
                            this.Animal.TipoAnimal.Tipo = new Tipo();
                            this.Animal.TipoAnimal.Tipo.Ativo = ocorrencia.Animal.TipoAnimal.Tipo.Ativo;
                            this.Animal.TipoAnimal.Tipo.FotoUrl = ocorrencia.Animal.TipoAnimal.Tipo.FotoUrl;
                            this.Animal.TipoAnimal.Tipo.Id = ocorrencia.Animal.TipoAnimal.Tipo.Id;
                            this.Animal.TipoAnimal.Tipo.Nome = ocorrencia.Animal.TipoAnimal.Tipo.Nome;
                        }

                        if (ocorrencia.Animal.TipoAnimal.Raca != null)
                        {
                            this.Animal.TipoAnimal.Raca = new Raca();
                            this.Animal.TipoAnimal.Raca.Ativo = ocorrencia.Animal.TipoAnimal.Raca.Ativo;
                            this.Animal.TipoAnimal.Raca.FotoUrl = ocorrencia.Animal.TipoAnimal.Raca.FotoUrl;
                            this.Animal.TipoAnimal.Raca.Id = ocorrencia.Animal.TipoAnimal.Raca.Id;
                            this.Animal.TipoAnimal.Raca.Nome = ocorrencia.Animal.TipoAnimal.Raca.Nome;
                            this.Animal.TipoAnimal.Raca.TipoId = ocorrencia.Animal.TipoAnimal.Raca.TipoId;

                            if (ocorrencia.Animal.TipoAnimal.Raca.Tipo != null)
                            {
                                this.Animal.TipoAnimal.Raca.Tipo = new Tipo();
                                this.Animal.TipoAnimal.Raca.Tipo.Ativo = ocorrencia.Animal.TipoAnimal.Raca.Tipo.Ativo;
                                this.Animal.TipoAnimal.Raca.Tipo.FotoUrl = ocorrencia.Animal.TipoAnimal.Raca.Tipo.FotoUrl;
                                this.Animal.TipoAnimal.Raca.Tipo.Id = ocorrencia.Animal.TipoAnimal.Raca.Tipo.Id;
                                this.Animal.TipoAnimal.Raca.Tipo.Nome = ocorrencia.Animal.TipoAnimal.Raca.Tipo.Nome;
                            }
                        }
                    }
                }
            }
        }

        public int Id { get; set; }
        public int TipoOcorrenciaId { get; set; }
        public virtual TipoOcorrencia TipoOcorrencia { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int Visualizacoes { get; set; }
        public int LocalizacaoId { get; set; }
        public virtual Localizacao Localizacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataOcorrido { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
