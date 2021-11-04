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
    public class UpdateProdutoCommandHandler : CommandHandler<Produto, UpdateProdutoRequest, UpdateProdutoResponse>
    {
        public UpdateProdutoCommandHandler(ICommandRepository<Produto> repository) : base(repository)
        {
        }
                
        public override IValidator<UpdateProdutoRequest> Validator => new UpdateProdutoRequestValidator();
                
        protected override void BeforeChanges(UpdateProdutoRequest request)
        {
            var existe = _repository.Exists(x => x.Id == request.GetId());

            if (!existe) _response.Errors.Add("produto não existe");
        }

        protected override Produto Changes(UpdateProdutoRequest request)
        {
            var produto = _repository.GetById(request.GetId());

            produto.Nome = request.Nome;
            produto.ValorUnitario = request.ValorUnitario;

            _repository.Update(produto);

            return produto;
        }

        protected override UpdateProdutoResponse AfterChanges(UpdateProdutoRequest request, Produto entidade)
        {
            return new UpdateProdutoResponse
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                ValorUnitario = entidade.ValorUnitario,
                DataAtualizacao = entidade.DataAtualizacao
            };
        }
    }
}
