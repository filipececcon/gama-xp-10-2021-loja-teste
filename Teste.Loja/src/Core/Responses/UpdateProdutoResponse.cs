using System;
namespace Teste.Loja.Domain.Core.Responses
{
    public class UpdateProdutoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
