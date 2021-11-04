using System;
using System.Linq;
using FluentValidation;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Domain.Core.Requests;
using Teste.Loja.Domain.Core.Responses;
using Teste.Loja.Domain.Core.Validators;
using Teste.Loja.Domain.Shared.Handlers;
using Teste.Loja.Domain.Shared.Interfaces;

namespace Teste.Loja.Domain.Core.Commands
{
    public class AddProdutoCommandHandler : CommandHandler<Produto, AddProdutoRequest, AddProdutoResponse>
    {
        public AddProdutoCommandHandler(ICommandRepository<Produto> repository) : base(repository)
        {
        }

        public override IValidator<AddProdutoRequest> Validator => new AddProdutoRequestValidator();

        protected override void BeforeChanges(AddProdutoRequest request)
        {
            var existe = _repository.Exists(x => x.Nome == request.Nome);

            if (existe) _response.Errors.Add($"o produto com o nome {request.Nome} já existe");    
        }

        protected override Produto Changes(AddProdutoRequest request)
        {
            var novoProduto = new Produto()
            {
                Nome = request.Nome,
                ValorUnitario =request.ValorUnitario
            };

            _repository.Add(novoProduto);

            return novoProduto;
        }

        protected override AddProdutoResponse AfterChanges(AddProdutoRequest request, Produto entidade)
        {
            return new AddProdutoResponse
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                ValorUnitario = entidade.ValorUnitario
            };
        }
    }
}
