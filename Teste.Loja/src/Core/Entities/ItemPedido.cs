using System;
using Teste.Loja.Domain.Shared.Entities;

namespace Teste.Loja.Domain.Core.Entities
{
    public class ItemPedido : Entidade
    {   
        public decimal Subtotal { get; set; }
        public int Quantidade { get; set; }
 
        public Produto Produto { get; set; }
        public Guid ProdutoId { get; set; }

        public Pedido Pedido { get; set; }
        public Guid PedidoId { get; set; }
    }
}
