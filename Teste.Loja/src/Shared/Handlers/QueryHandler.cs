using System;
using Teste.Loja.Domain.Shared.Entities;
using Teste.Loja.Domain.Shared.Interfaces;

namespace Teste.Loja.Domain.Shared.Handlers
{
    public abstract class QueryHandler<TEntidade, TRequest, TResponse>
        where TEntidade : Entidade
    {
        protected readonly IQueryRepository<TEntidade> _repository;

        public QueryHandler(IQueryRepository<TEntidade> repository)
        {
            _repository = repository;
        }

        public abstract TResponse Handle(TRequest request);
    }
}
