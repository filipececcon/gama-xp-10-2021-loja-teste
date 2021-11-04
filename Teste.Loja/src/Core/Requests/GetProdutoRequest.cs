using System;
namespace Teste.Loja.Domain.Core.Requests
{
    public class GetProdutoRequest
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }

        public decimal? OuValorIgual { get; set; }
    }
}
