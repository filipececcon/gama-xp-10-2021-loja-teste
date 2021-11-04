using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Infra.Data.Configs;

namespace Teste.Loja.Infra.Data.Config
{
    public class ProdutoConfig : EntidadeConfig<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_PRODUCT");

            builder
                .HasIndex(x => x.Nome,"IX_NOME")
                .IsUnique()
                ;

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_PRODUCT")
                
                ;

            builder
                .Property(x => x.ValorUnitario)
                .HasColumnName("VL_PRICE")
                ;

        }
    }
}
