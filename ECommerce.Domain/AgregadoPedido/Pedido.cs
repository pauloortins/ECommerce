using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.AgregadoPedido
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public virtual List<ItemPedido> ItensPedido { get; set; }
        public DateTime DataDoPedido { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        public Pedido()
        {
            ItensPedido = new List<ItemPedido>();
        }
    }
}
