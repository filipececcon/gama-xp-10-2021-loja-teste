using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Teste.Loja.Domain.Shared.Entities;
using Teste.Loja.Domain.Shared.Interfaces;

namespace Teste.Loja.Infra.Data.Repositories
{
    public class CommandRepository<TEntidade> : ICommandRepository<TEntidade> where TEntidade : Entidade
    {
        private readonly MercadoContext _context;

        public CommandRepository(MercadoContext context)
        {
            _context = context;
        }
            
        public void Add(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);    
        }

        public IEnumerable<TEntidade> Get(Expression<Func<TEntidade, bool>> predicate)
        {
            return _context.Set<TEntidade>().Where(predicate);         
        }

        public TEntidade GetById(Guid id)
        {
            return _context.Set<TEntidade>().Find(id);
        }

        public void Remove(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public TEntidade Update(TEntidade entidade)
        {
            entidade.DataAtualizacao = DateTime.Now;

            _context.Set<TEntidade>().Update(entidade);

            return entidade;
        }
    }
}
