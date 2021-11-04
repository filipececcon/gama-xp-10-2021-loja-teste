using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Teste.Loja.Domain.Shared.Entities;

namespace Teste.Loja.Domain.Shared.Interfaces
{
    public interface ICommandRepository<TEntidade> where TEntidade : Entidade
    {
        TEntidade GetById(Guid id);

        IEnumerable<TEntidade> Get(Expression<Func<TEntidade, bool>> predicate);

        void Add(TEntidade entidade);

        TEntidade Update(TEntidade entidade);

        void Remove(TEntidade entidade);

        void Save();
    }
}
