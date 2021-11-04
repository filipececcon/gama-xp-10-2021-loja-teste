using System;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Domain.Core.Requests;
using Teste.Loja.Domain.Core.Responses;
using Teste.Loja.Domain.Shared.Handlers;
using Teste.Loja.Domain.Shared.Interfaces;

namespace Teste.Loja.Domain.Core.Commands
{
    public class UpdateProdutoCommandHandler : CommandHandler<Produto, UpdateProdutoRequest, UpdateProdutoResponse>
    {
        public UpdateProdutoCommandHandler(ICommandRepository<Produto> repository) : base(repository)
        {
        }

        public override UpdateProdutoResponse Handle(UpdateProdutoRequest request)
        {
            var produto = _repository.GetById(request.Id);

            if (produto == null) throw new Exception("produto não existe");

            produto.Nome = request.Nome;
            produto.ValorUnitario = request.ValorUnitario;

            _repository.Update(produto);

            _repository.Save();

            return new UpdateProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                ValorUnitario = produto.ValorUnitario,
                DataAtualizacao = produto.DataAtualizacao
            };
        }
    }
}
