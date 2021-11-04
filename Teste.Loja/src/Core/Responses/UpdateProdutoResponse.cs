using System;
using System.Collections.Generic;
using Teste.Loja.Domain.Shared.Responses;

namespace Teste.Loja.Domain.Core.Responses
{
    public class UpdateProdutoResponse : Response
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
