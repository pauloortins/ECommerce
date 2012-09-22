using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerce.Domain.AgregadoProduto;
using ECommerce.Domain.AgregadoPedido;
using FluentAssertions;

namespace ECommerce.Domain.Testes.AgregadoPedido
{
    [TestClass]
    public class ItemPedidoTestes
    {
        [TestMethod]
        public void DeveSerCapazDeCalcularPrecoDoItemDoPedido()
        {
            var produto = new Produto() {Preco = 6.40};
            var itemPedido = new ItemPedido() { Produto = produto, Quantidade = 3};

            var result = itemPedido.CalcularPreco();
            result.Should().BeInRange(19.1, 19.3);
        }

        [TestMethod]
        public void DeveSerCapazDeDarBaixaNoEstoque()
        {
            var produto = new Produto() { Preco = 6.40, QuantidadeEmEstoque = 4};
            var itemPedido = new ItemPedido() { Produto = produto, Quantidade = 3 };

            itemPedido.DarBaixaNoEstoque();
            produto.QuantidadeEmEstoque.Should().Be(1);
        }

        [TestMethod]
        public void DeveExistirNoEstoqueSeQuantidadeMenorQueQuantidadeDoProdutoNoEstoque()
        {
            var produto = new Produto() { Preco = 6.40, QuantidadeEmEstoque = 4 };
            var itemPedido = new ItemPedido() { Produto = produto, Quantidade = 3 };

            itemPedido.ExisteNoEstoque().Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveExistirNoEstoqueSeQuantidadeMaiorQueQuantidadeDoProdutoNoEstoque()
        {
            var produto = new Produto() { Preco = 6.40, QuantidadeEmEstoque = 2 };
            var itemPedido = new ItemPedido() { Produto = produto, Quantidade = 3 };

            itemPedido.ExisteNoEstoque().Should().BeFalse();
        }
    }
}