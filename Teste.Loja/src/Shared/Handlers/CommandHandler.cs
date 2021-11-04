using System;
using Teste.Loja.Domain.Shared.Entities;
using Teste.Loja.Domain.Shared.Interfaces;

namespace Teste.Loja.Domain.Shared.Handlers
{
    public abstract class CommandHandler<TEntidade, TRequest, TResponse>
        where TEntidade : Entidade
    {
        protected readonly ICommandRepository<TEntidade> _repository;

        public CommandHandler(ICommandRepository<TEntidade> repository)
        {
            _repository = repository;
        }

        public abstract TResponse Handle(TRequest request);
    }
}
