using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ECommerce.Domain.AgregadoProduto;

namespace ECommerce.Domain.AgregadoPedido
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public double CalcularPreco()
        {
            return Quantidade*Produto.Preco;
        }

        public void DarBaixaNoEstoque()
        {
            Produto.QuantidadeEmEstoque -= this.Quantidade;
        }

        public bool ExisteNoEstoque()
        {
            return Produto.QuantidadeEmEstoque >= this.Quantidade;
        }
    }
}
