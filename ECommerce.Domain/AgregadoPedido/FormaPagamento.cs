using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.AgregadoPedido
{
    public class FormaPagamento
    {
        public static FormaPagamento CartaoCreditoVisa = new FormaPagamento(1,"Cartão de Crédito Visa");
        public static FormaPagamento CartaoCreditoMaster = new FormaPagamento(2, "Cartão de Crédito Master");
        public static FormaPagamento Boleto = new FormaPagamento(3, "Boleto Bancário");

        public int Id { get; private set; }
        public String Nome { get; private set; }

        private FormaPagamento(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public static FormaPagamento ObterPorId(string idFormaPagamento)
        {
            if (CartaoCreditoVisa.Id.ToString().Equals(idFormaPagamento))
                return CartaoCreditoVisa;

            if (CartaoCreditoMaster.Id.ToString().Equals(idFormaPagamento))
                return CartaoCreditoMaster;

            if (Boleto.Id.ToString().Equals(idFormaPagamento))
                return Boleto;

            throw new ArgumentException("Não existe forma de pagamento com esse id.");
        }
    }
}
