using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Domain.AgregadoProduto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerce.Domain.AgregadoPedido;
using FluentAssertions;

namespace ECommerce.Domain.Testes.AgregadoPedido
{
    [TestClass]
    public class CarroDeComprasTestes
    {
        [TestMethod]
        public void InserirItemPedidoEmUmCarroDeComprasVazio()
        {
            var produto = new Produto();
            var quantidade = 1;

            var carroDeCompras = new CarroDeCompras();

            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade });
            carroDeCompras.ItensPedido[0].Produto.Should().Be(produto);
            carroDeCompras.ItensPedido[0].Quantidade.Should().Be(quantidade);
        }

        [TestMethod]
        public void InserirItemPedidoDeUmProdutoJaExistente()
        {
            var produto = new Produto();
            var quantidade = 1;

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade});
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade });

            carroDeCompras.ItensPedido.Count.Should().Be(1);
            carroDeCompras.ItensPedido[0].Quantidade.Should().Be(2);
        }

        [TestMethod]
        public void AoFinalizarCompraDeveSerGeradoUmPedido()
        {
            var produto = new Produto();
            var quantidade = 1;

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade});

            var pedido = carroDeCompras.FinalizarCompra(FormaPagamento.CartaoCreditoVisa);

            pedido.ItensPedido[0].Produto.Should().Be(produto);
            pedido.ItensPedido[0].Quantidade.Should().Be(quantidade);
            pedido.FormaPagamento.Id.Should().Be(FormaPagamento.CartaoCreditoVisa.Id);
        }

        [TestMethod]
        public void AoFinalizarCompraCarrinhoDeveSerEsvaziado()
        {
            var produto = new Produto();
            var quantidade = 1;

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade });

            carroDeCompras.FinalizarCompra(FormaPagamento.CartaoCreditoVisa);

            carroDeCompras.ItensPedido.Should().BeEmpty();
        }

        [TestMethod]
        public void AoFinalizarCompraDeveSerAtualizadoEstoque()
        {
            var produto = new Produto() { QuantidadeEmEstoque = 1};
            var quantidade = produto.QuantidadeEmEstoque;

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade });

            var pedido = carroDeCompras.FinalizarCompra(FormaPagamento.CartaoCreditoVisa);

            pedido.ItensPedido[0].Produto.QuantidadeEmEstoque.Should().Be(0);
        }

        [TestMethod]
        public void DeveSerCapazDeCalcularPrecoTotal()
        {
            var produto = new Produto() { Preco = 7.5};
            var quantidade = 2;

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade });

            var result = carroDeCompras.CalcularPreco();
            result.Should().BeInRange(14.9, 15.1);
        }

        [TestMethod]
        public void CarroDeComprasPodeSerFinalizadoSeTodosOsItensDoPedidosExistemNoEstoque()
        {
            var produto = new Produto() {QuantidadeEmEstoque = 1};
            var quantidade = produto.QuantidadeEmEstoque;

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade });

            var result = carroDeCompras.CompraPodeSerFinalizada();

            result.Should().BeTrue();
        }

        [TestMethod]
        public void CarroDeComprasNaoPodeSerFinalizadoSeTodosOsItensDoPedidosNaoExistemNoEstoque()
        {
            var produto = new Produto() { QuantidadeEmEstoque = 0 };
            var quantidade = produto.QuantidadeEmEstoque + 1;

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = quantidade });

            var result = carroDeCompras.CompraPodeSerFinalizada();

            result.Should().BeFalse();
        }

        [TestMethod]
        public void DeveSerCapazDeItensDePedidoPeloIdDoProduto()
        {
            var produto = new Produto() { Id = 1 };

            var carroDeCompras = new CarroDeCompras();
            carroDeCompras.AdicionarItemPedido(new ItemPedido() { Produto = produto, Quantidade = 0 });

            carroDeCompras.RemoverProduto(produto.Id.ToString());

            carroDeCompras.ItensPedido.Should().BeEmpty();
        }
    }
}
