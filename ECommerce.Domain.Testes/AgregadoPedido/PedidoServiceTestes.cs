using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerce.Domain.AgregadoPedido;
using Moq;

namespace ECommerce.Domain.Testes.AgregadoPedido
{
    [TestClass]
    public class PedidoServiceTestes
    {
        [TestMethod]
        public void DeveSerCapazDeIncluirPedido()
        {
            var mock = new Mock<IPedidoRepository>();
            var pedidoService = new PedidoService(mock.Object);

            pedidoService.IncluirPedido(new Pedido());
            
            mock.Verify(x => x.IncluirPedido(It.IsAny<Pedido>()), Times.Once());
        }
    }
}
