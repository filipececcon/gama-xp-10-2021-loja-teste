using System;
namespace Teste.Loja.Domain.Core.Requests
{
    public class UpdateProdutoRequest
    {
        private Guid _id;
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }

        public Guid GetId() => _id;

        public void SetId(Guid id) => _id = id;
        
    }
}
