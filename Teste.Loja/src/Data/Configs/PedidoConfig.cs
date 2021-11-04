using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Loja.Domain.Core.Entities;

namespace Teste.Loja.Infra.Data.Configs
{
    public class PedidoConfig : EntidadeConfig<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_ORDER");

            builder
                .Property(x => x.PrecoFinal)
                .HasColumnName("VL_FINAL");

        }
    }
}
