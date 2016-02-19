using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Infraestrutura.Entidades
{
    public class Animal
    {
        public Animal()
        {

        }

        public Animal(Animal animal)
        {
            this.Id = animal.Id;
            this.Nome = animal.Nome;
            this.FotoUrl = animal.FotoUrl;
            this.CorId = animal.CorId;
            this.TipoAnimalId = animal.TipoAnimalId;
            this.Idade = animal.Idade;
            this.Ativo = animal.Ativo;

            if (animal.Cor != null)
            {
                this.Cor = new Cor();
                this.Cor.Id = animal.Cor.Id;
                this.Cor.Nome = animal.Cor.Nome;
                this.Cor.Codigo = animal.Cor.Codigo;
            }

            if (animal.TipoAnimal != null)
            {
                this.TipoAnimal.Id = animal.TipoAnimal.Id;
                this.TipoAnimal.TipoId = animal.TipoAnimal.TipoId;
                this.TipoAnimal.RacaId = animal.TipoAnimal.RacaId;

                if (animal.TipoAnimal.Tipo != null)
                {
                    this.TipoAnimal.Tipo = new Tipo();
                    this.TipoAnimal.Tipo.Ativo = animal.TipoAnimal.Tipo.Ativo;
                    this.TipoAnimal.Tipo.FotoUrl = animal.TipoAnimal.Tipo.FotoUrl;
                    this.TipoAnimal.Tipo.Id = animal.TipoAnimal.Tipo.Id;
                    this.TipoAnimal.Tipo.Nome = animal.TipoAnimal.Tipo.Nome;
                }

                if (animal.TipoAnimal.Raca != null)
                {
                    this.TipoAnimal.Raca = new Raca();
                    this.TipoAnimal.Raca.Ativo = animal.TipoAnimal.Raca.Ativo;
                    this.TipoAnimal.Raca.FotoUrl = animal.TipoAnimal.Raca.FotoUrl;
                    this.TipoAnimal.Raca.Id = animal.TipoAnimal.Raca.Id;
                    this.TipoAnimal.Raca.Nome = animal.TipoAnimal.Raca.Nome;

                    if (animal.TipoAnimal.Raca.Tipo != null)
                    {
                        this.TipoAnimal.Raca.Tipo = new Tipo();
                        this.TipoAnimal.Raca.Tipo.Ativo = animal.TipoAnimal.Raca.Tipo.Ativo;
                        this.TipoAnimal.Raca.Tipo.FotoUrl = animal.TipoAnimal.Raca.Tipo.FotoUrl;
                        this.TipoAnimal.Raca.Tipo.Id = animal.TipoAnimal.Raca.Tipo.Id;
                        this.TipoAnimal.Raca.Tipo.Nome = animal.TipoAnimal.Raca.Tipo.Nome;
                    }
                }
            }
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public int? CorId { get; set; }
        public virtual Cor Cor { get; set; }
        public int TipoAnimalId { get; set; }
        public virtual TipoAnimal TipoAnimal { get; set; }
        public int? Idade { get; set; }
        public bool Ativo { get; set; }
    }
}
