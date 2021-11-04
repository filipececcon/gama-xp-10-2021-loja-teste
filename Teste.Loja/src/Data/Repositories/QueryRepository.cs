using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Teste.Loja.Domain.Shared.Entities;
using Teste.Loja.Domain.Shared.Interfaces;

namespace Teste.Loja.Infra.Data.Repositories
{
    public class QueryRepository<TEntidade> : IQueryRepository<TEntidade> where TEntidade : Entidade
    {
        private readonly MercadoContext _context;

        public QueryRepository(MercadoContext context)
        {
            _context = context;
        }

        public IQueryable<TEntidade> Get(Expression<Func<TEntidade, bool>> predicate)
        {
            return _context.Set<TEntidade>().AsNoTracking().Where(predicate);
        }

        public IQueryable<TEntidade> Get()
        {
            return _context.Set<TEntidade>().AsNoTracking().AsQueryable();            
        }

        public TEntidade GetById(Guid id)
        {
            return _context.Set<TEntidade>().AsNoTracking().Single(x => x.Id == id); ;
        }
    }
}
