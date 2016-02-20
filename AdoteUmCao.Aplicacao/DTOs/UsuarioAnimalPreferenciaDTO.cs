using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.DTOs
{
    public class UsuarioAnimalPreferenciaDTO
    {
        public UsuarioAnimalPreferenciaDTO()
        {

        }

        public UsuarioAnimalPreferenciaDTO(UsuarioAnimalPreferenciaDTO usuariosAnimaisPreferencias)
        {
            this.Id = usuariosAnimaisPreferencias.Id;
            this.AnimalId = usuariosAnimaisPreferencias.AnimalId;
            this.UsuarioId = usuariosAnimaisPreferencias.UsuarioId;
            this.Ativo = usuariosAnimaisPreferencias.Ativo;

            if (usuariosAnimaisPreferencias.Animal != null)
            {
                this.Animal = new AnimalDTO();
                this.Animal.Id = usuariosAnimaisPreferencias.Animal.Id;
                this.Animal.Nome = usuariosAnimaisPreferencias.Animal.Nome;
                this.Animal.FotoUrl = usuariosAnimaisPreferencias.Animal.FotoUrl;
                this.Animal.CorId = usuariosAnimaisPreferencias.Animal.CorId;
                this.Animal.TipoAnimalId = usuariosAnimaisPreferencias.Animal.TipoAnimalId;
                this.Animal.Idade = usuariosAnimaisPreferencias.Animal.Idade;
                this.Animal.Ativo = usuariosAnimaisPreferencias.Animal.Ativo;

                if (usuariosAnimaisPreferencias.Animal.Cor != null)
                {
                    this.Animal.Cor = new CorDTO();
                    this.Animal.Cor.Id = usuariosAnimaisPreferencias.Animal.Cor.Id;
                    this.Animal.Cor.Nome = usuariosAnimaisPreferencias.Animal.Cor.Nome;
                    this.Animal.Cor.Codigo = usuariosAnimaisPreferencias.Animal.Cor.Codigo;
                }

                if (usuariosAnimaisPreferencias.Animal.TipoAnimal != null)
                {
                    this.Animal.TipoAnimal = new TipoAnimalDTO();
                    this.Animal.TipoAnimal.Id = usuariosAnimaisPreferencias.Animal.TipoAnimal.Id;
                    this.Animal.TipoAnimal.TipoId = usuariosAnimaisPreferencias.Animal.TipoAnimal.TipoId;
                    this.Animal.TipoAnimal.RacaId = usuariosAnimaisPreferencias.Animal.TipoAnimal.RacaId;

                    if (usuariosAnimaisPreferencias.Animal.TipoAnimal.Tipo != null)
                    {
                        this.Animal.TipoAnimal.Tipo = new TipoDTO();
                        this.Animal.TipoAnimal.Tipo.Ativo = usuariosAnimaisPreferencias.Animal.TipoAnimal.Tipo.Ativo;
                        this.Animal.TipoAnimal.Tipo.FotoUrl = usuariosAnimaisPreferencias.Animal.TipoAnimal.Tipo.FotoUrl;
                        this.Animal.TipoAnimal.Tipo.Id = usuariosAnimaisPreferencias.Animal.TipoAnimal.Tipo.Id;
                        this.Animal.TipoAnimal.Tipo.Nome = usuariosAnimaisPreferencias.Animal.TipoAnimal.Tipo.Nome;
                    }

                    if (usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca != null)
                    {
                        this.Animal.TipoAnimal.Raca = new RacaDTO();
                        this.Animal.TipoAnimal.Raca.Ativo = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Ativo;
                        this.Animal.TipoAnimal.Raca.FotoUrl = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.FotoUrl;
                        this.Animal.TipoAnimal.Raca.Id = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Id;
                        this.Animal.TipoAnimal.Raca.Nome = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Nome;

                        if (usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Tipo != null)
                        {
                            this.Animal.TipoAnimal.Raca.Tipo = new TipoDTO();
                            this.Animal.TipoAnimal.Raca.Tipo.Ativo = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Tipo.Ativo;
                            this.Animal.TipoAnimal.Raca.Tipo.FotoUrl = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Tipo.FotoUrl;
                            this.Animal.TipoAnimal.Raca.Tipo.Id = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Tipo.Id;
                            this.Animal.TipoAnimal.Raca.Tipo.Nome = usuariosAnimaisPreferencias.Animal.TipoAnimal.Raca.Tipo.Nome;
                        }
                    }
                }
            }
        }

        public int Id { get; set; }
        public int AnimalId { get; set; }
        public AnimalDTO Animal { get; set; }
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; }
    }
}
