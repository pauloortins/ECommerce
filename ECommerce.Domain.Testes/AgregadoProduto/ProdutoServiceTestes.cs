using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ECommerce.Domain.AgregadoProduto;
using FluentAssertions;

namespace ECommerce.Domain.Testes.AgregadoProduto
{
    [TestClass]
    public class ProdutoServiceTestes
    {
        [TestMethod]
        public void ObterTodosProdutos()
        {
            var listaProdutos = new List<Produto>()
                                    {
                                        new Produto(){Id = 1, Nome = "Produto 1"},
                                        new Produto(){Id = 2, Nome = "Produto 2"}
                                    }.AsQueryable();

            var produtoRepository = new Mock<IProdutoRepository>();
            produtoRepository.Setup(x => x.ObterTodosProdutos()).Returns(listaProdutos);

            var produtoService = new ProdutoService(produtoRepository.Object);

            var result = produtoService.ObterTodosProdutos();
            result.Should().BeEquivalentTo(listaProdutos);
        }
    }
}
