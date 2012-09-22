using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.AgregadoPedido
{
    public interface IPedidoService
    {
        void IncluirPedido(Pedido pedido);
    }
}
