using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.AgregadoPedido
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void IncluirPedido(Pedido pedido)
        {
            _pedidoRepository.IncluirPedido(pedido);
        }
    }
}
