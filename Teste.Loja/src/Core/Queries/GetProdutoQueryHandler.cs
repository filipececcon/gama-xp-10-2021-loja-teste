using System;
using System.Linq;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Domain.Core.Requests;
using Teste.Loja.Domain.Core.Responses;
using Teste.Loja.Domain.Shared.Handlers;
using Teste.Loja.Domain.Shared.Interfaces;
using Teste.Loja.Domain.Shared.Util;

namespace Teste.Loja.Domain.Core.Queries
{
    public class GetProdutoQueryHandler : QueryHandler<Produto, GetProdutoRequest, IQueryable<GetProdutoResponse>>
    {
        public GetProdutoQueryHandler(IQueryRepository<Produto> repository) : base(repository)
        {
        }

        public override IQueryable<GetProdutoResponse> Handle(GetProdutoRequest request)
        {
            var predicate = PredicateBuilder.New<Produto>();

            if (request.Nome != null) predicate = predicate.And(x => x.Nome.Contains(request.Nome));

            if (request.OuValorIgual != null) predicate = predicate.And(x => x.ValorUnitario == request.OuValorIgual);

            //se passado o Id deconsidere todo o resto e considere somente o id
            if (request.Id != null) predicate = PredicateBuilder.New<Produto>().And(x => x.Id == request.Id);

            return _repository
                .Get(predicate)
                .Select(x => new GetProdutoResponse
                    {
                        Id=x.Id,
                        Nome = x.Nome,
                        DataCriacao = x.DataCriacao,
                        ValorUnitario = x.ValorUnitario
                    }
                );
        }
    }
}
