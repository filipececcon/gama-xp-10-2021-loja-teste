using System;
using System.Linq;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Domain.Core.Requests;
using Teste.Loja.Domain.Core.Responses;
using Teste.Loja.Domain.Shared.Handlers;
using Teste.Loja.Domain.Shared.Interfaces;

namespace Teste.Loja.Domain.Core.Commands
{
    public class AddProdutoCommandHandler : CommandHandler<Produto, AddProdutoRequest, AddProdutoResponse>
    {
        public AddProdutoCommandHandler(ICommandRepository<Produto> repository) : base(repository)
        {
        }
                
        public override AddProdutoResponse Handle(AddProdutoRequest request)
        {
            var existe = _repository.Get(x => x.Nome == request.Nome).ToList().Any();

            if (existe) throw new Exception($"o produto com o nome {request.Nome} já existe"); 

            var novoProduto = new Produto() { Nome = request.Nome, ValorUnitario = request.ValorUnitario };

            _repository.Add(novoProduto);

            _repository.Save();

            return new AddProdutoResponse
            {
                Id = novoProduto.Id,
                Nome = novoProduto.Nome,
                ValorUnitario = novoProduto.ValorUnitario
            };
        }
    }
}
