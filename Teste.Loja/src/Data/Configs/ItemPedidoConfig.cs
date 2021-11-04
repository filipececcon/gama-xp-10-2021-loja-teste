using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Loja.Domain.Core.Entities;

namespace Teste.Loja.Infra.Data.Configs
{
    public class ItemPedidoConfig : EntidadeConfig<ItemPedido>
    {
        public override void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_ORDER_ITEM");

            builder
                .Property(x => x.ProdutoId)
                .HasColumnName("ID_PRODUCT")
                ;

            builder
                .Property(x => x.Quantidade)
                .HasColumnName("NR_QUANTITY")
                ;

            builder
                .Property(x => x.Subtotal)
                .HasColumnName("VL_SUBTOTAL")
                ;

            builder
                .Property(x => x.PedidoId)
                .HasColumnName("ID_ORDER")
                ;

            builder
                .HasOne(x => x.Produto)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.ProdutoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Pedido)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.PedidoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
