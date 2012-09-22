using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.AgregadoProduto
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public double Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}
