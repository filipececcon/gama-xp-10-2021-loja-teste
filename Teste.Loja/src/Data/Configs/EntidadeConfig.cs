using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Loja.Domain.Shared.Entities;

namespace Teste.Loja.Infra.Data.Configs
{
    public abstract class EntidadeConfig<TEntidade> : IEntityTypeConfiguration<TEntidade> where TEntidade : Entidade
    {
        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("ID")
                ;

            builder
                .Property(x => x.DataAtualizacao)
                .HasColumnName("DT_UPDATED")
                ;

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("DT_CREATED")
                ;

            builder
                .Property(x => x.Ativo)
                .HasColumnName("ST_ACTIVE")
                ;
        }
    }
}
