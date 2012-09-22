using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ECommerce.Domain.AgregadoPedido;
using ECommerce.Domain;
using ECommerce.Domain.AgregadoProduto;

namespace ECommerce.Repository.Entity
{
    public class EntityContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; } 
    }
}
