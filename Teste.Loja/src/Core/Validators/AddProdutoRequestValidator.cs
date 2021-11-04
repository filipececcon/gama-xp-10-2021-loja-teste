using System;
using FluentValidation;
using Teste.Loja.Domain.Core.Requests;

namespace Teste.Loja.Domain.Core.Validators
{
    public class AddProdutoRequestValidator : AbstractValidator<AddProdutoRequest>
    {
        public AddProdutoRequestValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull();
            RuleFor(x => x.ValorUnitario).NotNull().NotEmpty().GreaterThan(0);           
        }
    }
}
