using System;
using FluentValidation;
using Teste.Loja.Domain.Core.Requests;

namespace Teste.Loja.Domain.Core.Validators
{
    public class UpdateProdutoRequestValidator : AbstractValidator<UpdateProdutoRequest>
    {
        public UpdateProdutoRequestValidator()
        {
            RuleFor(x => x.GetId()).NotNull().NotEmpty();
            RuleFor(x => x.Nome).NotEmpty().NotNull();
            RuleFor(x => x.ValorUnitario).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
