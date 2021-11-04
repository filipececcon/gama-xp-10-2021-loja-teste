using System;
using Teste.Loja.Domain.Shared.Responses;

namespace Teste.Loja.Domain.Core.Responses
{
    public class AddProdutoResponse : Response
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
