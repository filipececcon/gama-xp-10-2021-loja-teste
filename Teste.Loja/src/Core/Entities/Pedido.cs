using System;
using System.Collections.Generic;
using Teste.Loja.Domain.Shared.Entities;

namespace Teste.Loja.Domain.Core.Entities
{
    public class Pedido : Entidade
    {
        public decimal PrecoFinal { get; set; }
        public List<ItemPedido> Itens { get; private set; }

        public Pedido()
        {
            Itens = new List<ItemPedido>();           
        }
    }
}
