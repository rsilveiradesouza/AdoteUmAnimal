﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoteUmCao.Infraestrutura.Entidades;

namespace AdoteUmCao.Aplicacao.DTOs
{
    public class TipoAnimalDTO
    {
        public TipoAnimalDTO()
        {

        }

        public TipoAnimalDTO(TipoAnimal tipoAnimal)
        {
            this.Id = tipoAnimal.Id;
            this.TipoId = tipoAnimal.TipoId;
            this.RacaId = tipoAnimal.RacaId.HasValue ? (int)tipoAnimal.RacaId : 0;

            if (tipoAnimal.Tipo != null)
            {
                this.Tipo = new TipoDTO();
                this.Tipo.Ativo = tipoAnimal.Tipo.Ativo;
                this.Tipo.FotoUrl = tipoAnimal.Tipo.FotoUrl;
                this.Tipo.Id = tipoAnimal.Tipo.Id;
                this.Tipo.Nome = tipoAnimal.Tipo.Nome;
            }

            if (tipoAnimal.Raca != null)
            {
                this.Raca = new RacaDTO();
                this.Raca.Ativo = tipoAnimal.Raca.Ativo;
                this.Raca.FotoUrl = tipoAnimal.Raca.FotoUrl;
                this.Raca.Id = tipoAnimal.Raca.Id;
                this.Raca.Nome = tipoAnimal.Raca.Nome;

                if (tipoAnimal.Raca.Tipo != null)
                {
                    this.Raca.Tipo = new TipoDTO();
                    this.Raca.Tipo.Ativo = tipoAnimal.Raca.Tipo.Ativo;
                    this.Raca.Tipo.FotoUrl = tipoAnimal.Raca.Tipo.FotoUrl;
                    this.Raca.Tipo.Id = tipoAnimal.Raca.Tipo.Id;
                    this.Raca.Tipo.Nome = tipoAnimal.Raca.Tipo.Nome;
                }
            }
        }

        public int Id { get; set; }
        public int TipoId { get; set; }
        public TipoDTO Tipo { get; set; }
        public int RacaId { get; set; }
        public RacaDTO Raca { get; set; }
    }
}
