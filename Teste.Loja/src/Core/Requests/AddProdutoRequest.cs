using System;
namespace Teste.Loja.Domain.Core.Requests
{
    public class AddProdutoRequest
    {
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
