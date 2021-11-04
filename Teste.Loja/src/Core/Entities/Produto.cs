using System;
using System.Collections.Generic;
using Teste.Loja.Domain.Shared.Entities;

namespace Teste.Loja.Domain.Core.Entities
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }

        public List<ItemPedido> Itens { get; set; }
        //public IReadOnlyCollection<ItemPedido> Itens => _itens.AsReadOnly();

    }
}
