using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerce.Domain.AgregadoPedido;
using Moq;
using ECommerce.Domain.AgregadoProduto;
using ECommerce.Web.Controllers;
using FluentAssertions;
using System.Web.Mvc;

namespace ECommerce.Web.Testes.Controllers
{
    [TestClass]
    public class CarroDeComprasControllerTestes
    {
        private Mock<IPedidoService> mockPedidoService;
        private Mock<IProdutoService> mockProdutoService;
        private CarroDeComprasController carroDeComprasController;

        [TestInitialize]
        public void TestInitialize()
        {
            mockPedidoService = new Mock<IPedidoService>();
            
            mockProdutoService = new Mock<IProdutoService>();
            mockProdutoService.Setup(x => x.ObterTodosProdutos())
                .Returns(new List<Produto>()
                             {
                                 new Produto() { Id = 1}
                             }.AsQueryable());

            carroDeComprasController = new CarroDeComprasController(mockProdutoService.Object, mockPedidoService.Object);
        }

        [TestMethod]
        public void AoAcessarActionIndexDeveSerExibidoOCarroDeCompras()
        {
            var carroDeCompras = new CarroDeCompras();
            var result = carroDeComprasController.Index(carroDeCompras);
            result.As<ViewResult>().Model.Should().BeSameAs(carroDeCompras);
        }

        [TestMethod]
        public void AoAcessarActionIndexDeveSerExibidaViewComMesmoNome()
        {
            var carroDeCompras = new CarroDeCompras();
            var result = carroDeComprasController.Index(carroDeCompras);
            result.As<ViewResult>().ViewName.Should().BeEmpty();
        }

        [TestMethod]
        public void AoAdicionarItemItemDeveSerAdicionadoNoCarrinho()
        {
            var carroDeCompras = new CarroDeCompras();
            carroDeComprasController.AdicionarItem(carroDeCompras, 1, 10);

            carroDeCompras.ItensPedido[0].Produto.Id.Should().Be(1);
            carroDeCompras.ItensPedido[0].Quantidade.Should().Be(10);
        }

        [TestMethod]
        public void AoAdicionarDeveSerRedirecionadoParaTelaDeProduto()
        {
            var carroDeCompras = new CarroDeCompras();
            var result = carroDeComprasController.AdicionarItem(carroDeCompras, 1, 10);
            result.As<RedirectToRouteResult>().RouteValues["action"].Should().Be("Index");
            result.As<RedirectToRouteResult>().RouteValues["controller"].Should().Be("Produto");
        }

        [TestMethod]
        public void AoRemoverItemDevePermanecerNaPaginaIndex()
        {
            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.ItensPedido.Add(new ItemPedido() { Produto = new Produto(){ Id = 1}});

            var result = carroDeComprasController.RemoverProduto(carroDeCompras, "1");
            result.As<ViewResult>().ViewName.Should().Be("Index");
        }

        [TestMethod]
        public void AoRemoverItemItemDeveSerRemovidoDoCarrinho()
        {
            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.ItensPedido.Add(new ItemPedido() { Produto = new Produto() { Id = 1 } });

            carroDeComprasController.RemoverProduto(carroDeCompras, "1");
            carroDeCompras.ItensPedido.Should().BeEmpty();
        }

        [TestMethod]
        public void AoFinalizarACompraDevePermanacerNaTelaIndex()
        {
            var carroDeCompras = new CarroDeCompras();

            var result = carroDeComprasController.FinalizarCompra(carroDeCompras, "1");
            result.As<RedirectToRouteResult>().RouteValues["action"].Should().Be("Index");
        }

        [TestMethod]
        public void AoFinalizarACompraComItensEmEstoqueDeveSerChamadoMetodoIncluir()
        {
            var carroDeCompras = new CarroDeCompras();

            var result = carroDeComprasController.FinalizarCompra(carroDeCompras, "1");

            mockPedidoService.Verify(x => x.IncluirPedido(It.IsAny<Pedido>()), Times.Once());
        }

        [TestMethod]
        public void AoFinalizarACompraComItensNaoExistentesNoEstoqueNaoDeveSerChamadoMetodoIncluir()
        {
            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = new Produto() {Id = 1, QuantidadeEmEstoque = 0}, Quantidade = int.MaxValue});

            var result = carroDeComprasController.FinalizarCompra(carroDeCompras, "1");

            mockPedidoService.Verify(x => x.IncluirPedido(It.IsAny<Pedido>()), Times.Never());
        }

    }
}
