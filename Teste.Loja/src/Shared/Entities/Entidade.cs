using System;
namespace Teste.Loja.Domain.Shared.Entities
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
            var agora = DateTime.Now;
            DataCriacao = agora;
            DataAtualizacao = agora;
            Ativo = true;
        }
    }    
}
