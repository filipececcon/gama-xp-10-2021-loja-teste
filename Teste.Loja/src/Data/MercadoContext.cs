using System;
using Microsoft.EntityFrameworkCore;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Infra.Data.Config;
using Teste.Loja.Infra.Data.Configs;

namespace Teste.Loja.Infra.Data
{
    public class MercadoContext : DbContext
    {
        public MercadoContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProdutoConfig().Configure(modelBuilder.Entity<Produto>());
            new PedidoConfig().Configure(modelBuilder.Entity<Pedido>());
            new ItemPedidoConfig().Configure(modelBuilder.Entity<ItemPedido>());
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
