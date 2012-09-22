using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerce.Domain.AgregadoPedido;
using FluentAssertions;

namespace ECommerce.Domain.Testes.AgregadoPedido
{
    [TestClass]
    public class FormaPagamentoTestes
    {
        [TestMethod]
        public void DeveSerCapazDeRetornarTiposDePagamentoPorId()
        {
            var tiposPagamento = new Dictionary<string, FormaPagamento>()
                                     {
                                         {"1", FormaPagamento.CartaoCreditoVisa},
                                         {"2", FormaPagamento.CartaoCreditoMaster},
                                         {"3", FormaPagamento.Boleto}
                                     };

            foreach (var formaPagamento in tiposPagamento)
            {
                FormaPagamento.ObterPorId(formaPagamento.Key).Should().BeSameAs(formaPagamento.Value);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveLancarExcecaoSeTentarObterUmaFormaDePagamentoInexistente()
        {
            FormaPagamento.ObterPorId("forma de pagamento inexistente");
        }
    }
}
