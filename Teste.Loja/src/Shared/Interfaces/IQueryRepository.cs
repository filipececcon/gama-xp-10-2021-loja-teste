using System;
using System.Linq;
using System.Linq.Expressions;
using Teste.Loja.Domain.Shared.Entities;

namespace Teste.Loja.Domain.Shared.Interfaces
{
    public interface IQueryRepository<TEntidade> where TEntidade : Entidade
    {
        TEntidade GetById(Guid id);

        IQueryable<TEntidade> Get();

        IQueryable<TEntidade> Get(Expression<Func<TEntidade,bool>> predicate);
    }
}
