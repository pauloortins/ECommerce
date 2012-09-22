using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Domain.AgregadoPedido;
using ECommerce.Repository.Entity;

namespace ECommerce.Repository.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private EntityContext _context;

        public PedidoRepository(EntityContext context)
        {
            this._context = context;
        }

        public void IncluirPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }
    }
}
