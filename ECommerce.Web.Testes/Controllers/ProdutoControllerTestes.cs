using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerce.Web.Controllers;
using Moq;
using ECommerce.Domain.AgregadoProduto;
using System.Web.Mvc;
using FluentAssertions;

namespace ECommerce.Web.Testes.Controllers
{
    [TestClass]
    public class ProdutoControllerTestes
    {
        [TestMethod]
        public void AoRequisitarActionIndexDeveSerExibidaTelaComMesmoNome()
        {
            var mockService = new Mock<IProdutoService>();
            var controller = new ProdutoController(mockService.Object);

            var result = controller.Index();

            ((ViewResult) result).ViewName.Should().BeEmpty();
        }

        [TestMethod]
        public void AoRequisitarActionIndexDeveSerGeradoModelComDadosDeProdutos()
        {
            var listaProdutos = new List<Produto>()
                                    {
                                        new Produto(){Id = 1, Nome = "Produto 1", QuantidadeEmEstoque = 10},
                                        new Produto(){Id = 2, Nome = "Produto 2", QuantidadeEmEstoque = 20}
                                    }.AsQueryable();

            var mockService = new Mock<IProdutoService>();
            mockService.Setup(x => x.ObterTodosProdutos()).Returns(listaProdutos);

            var controller = new ProdutoController(mockService.Object);

            var result = controller.Index();

            var model = (List<Produto>)  ((ViewResult) result).Model;

            model.Should().BeEquivalentTo(listaProdutos);
        }
    }
}
