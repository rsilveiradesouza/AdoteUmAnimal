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
            this.Id = usuario.Id;
            this.Nome = usuario.Nome;
            this.Sobrenome = usuario.Sobrenome;
            this.DataRegistro = usuario.DataRegistro;
            this.Token = usuario.Token;
            this.TokenEmail = usuario.TokenEmail;
            this.Telefone = usuario.Telefone;
            this.Celular = usuario.Celular;
            this.FotoUrl = usuario.FotoUrl;
            this.Email = usuario.Email;
            this.Ativo = usuario.Ativo;
            this.TokenFacebook = usuario.TokenFacebook;
            this.TokenGoogle = usuario.TokenGoogle;
            this.TokenTwitter = usuario.TokenTwitter;

            if (usuario.UsuarioAnimaisPreferencias != null)
            {
                this.UsuarioAnimaisPreferencias = new List<UsuarioAnimalPreferencia>();

                for (int i = 0; i < usuario.UsuarioAnimaisPreferencias.Count; i++)
                {
                    UsuarioAnimalPreferencia uap = new UsuarioAnimalPreferencia();
                    uap.AnimalId = usuario.UsuarioAnimaisPreferencias[i].AnimalId;
                    uap.Ativo = usuario.UsuarioAnimaisPreferencias[i].Ativo;
                    uap.Id = usuario.UsuarioAnimaisPreferencias[i].Id;
                    uap.UsuarioId = usuario.UsuarioAnimaisPreferencias[i].UsuarioId;

                    if (usuario.UsuarioAnimaisPreferencias[i].Animal != null)
                    {
                        uap.Animal = new Animal();
                        uap.Animal.Id = usuario.UsuarioAnimaisPreferencias[i].Animal.Id;
                        uap.Animal.Nome = usuario.UsuarioAnimaisPreferencias[i].Animal.Nome;
                        uap.Animal.FotoUrl = usuario.UsuarioAnimaisPreferencias[i].Animal.FotoUrl;
                        uap.Animal.CorId = usuario.UsuarioAnimaisPreferencias[i].Animal.CorId;
                        uap.Animal.TipoAnimalId = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimalId;
                        uap.Animal.Idade = usuario.UsuarioAnimaisPreferencias[i].Animal.Idade;
                        uap.Animal.Ativo = usuario.UsuarioAnimaisPreferencias[i].Animal.Ativo;

                        if (usuario.UsuarioAnimaisPreferencias[i].Animal.Cor != null)
                        {
                            uap.Animal.Cor = new Cor();
                            uap.Animal.Cor.Id = usuario.UsuarioAnimaisPreferencias[i].Animal.Cor.Id;
                            uap.Animal.Cor.Nome = usuario.UsuarioAnimaisPreferencias[i].Animal.Cor.Nome;
                            uap.Animal.Cor.Codigo = usuario.UsuarioAnimaisPreferencias[i].Animal.Cor.Codigo;
                        }

                        if (usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal != null)
                        {
                            uap.Animal.TipoAnimal.Id = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Id;
                            uap.Animal.TipoAnimal.TipoId = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.TipoId;
                            uap.Animal.TipoAnimal.RacaId = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.RacaId;

                            if (usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo != null)
                            {
                                uap.Animal.TipoAnimal.Tipo = new Tipo();
                                uap.Animal.TipoAnimal.Tipo.Ativo = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.Ativo;
                                uap.Animal.TipoAnimal.Tipo.FotoUrl = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.FotoUrl;
                                uap.Animal.TipoAnimal.Tipo.Id = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.Id;
                                uap.Animal.TipoAnimal.Tipo.Nome = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Tipo.Nome;
                            }

                            if (usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca != null)
                            {
                                uap.Animal.TipoAnimal.Raca = new Raca();
                                uap.Animal.TipoAnimal.Raca.Ativo = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Ativo;
                                uap.Animal.TipoAnimal.Raca.FotoUrl = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.FotoUrl;
                                uap.Animal.TipoAnimal.Raca.Id = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Id;
                                uap.Animal.TipoAnimal.Raca.Nome = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Nome;

                                if (usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo != null)
                                {
                                    uap.Animal.TipoAnimal.Raca.Tipo = new Tipo();
                                    uap.Animal.TipoAnimal.Raca.Tipo.Ativo = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.Ativo;
                                    uap.Animal.TipoAnimal.Raca.Tipo.FotoUrl = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.FotoUrl;
                                    uap.Animal.TipoAnimal.Raca.Tipo.Id = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.Id;
                                    uap.Animal.TipoAnimal.Raca.Tipo.Nome = usuario.UsuarioAnimaisPreferencias[i].Animal.TipoAnimal.Raca.Tipo.Nome;
                                }
                            }
                        }
                    }

                    this.UsuarioAnimaisPreferencias.Add(uap);
                }
            }
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Token { get; set; }
        public string TokenEmail { get; set; }
        public string TokenFacebook { get; set; }
        public string TokenGoogle { get; set; }
        public string TokenTwitter { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string FotoUrl { get; set; }
        public virtual List<UsuarioAnimalPreferencia> UsuarioAnimaisPreferencias { get; set; }
        public bool Ativo { get; set; }
    }
}
