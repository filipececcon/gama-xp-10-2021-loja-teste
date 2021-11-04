using System;
namespace Teste.Loja.Domain.Core.Requests
{
    public class UpdateProdutoRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
