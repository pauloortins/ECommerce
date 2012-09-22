using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.AgregadoPedido
{
    public class CarroDeCompras
    {
        public List<ItemPedido> ItensPedido { get; set; }

        public CarroDeCompras()
        {
            ItensPedido = new List<ItemPedido>();
        }

        public void AdicionarItemPedido(ItemPedido itemPedido)
        {
            if (ItensPedido.Exists(x => x.Produto.Id == itemPedido.Produto.Id))
            {
                ItensPedido.Find(x => x.Produto.Id == itemPedido.Produto.Id).Quantidade += itemPedido.Quantidade;
            }
            else
            {
                ItensPedido.Add(itemPedido);
            }
        }

        public Pedido FinalizarCompra(FormaPagamento formaPagamento)
        {
            var pedido = CriarPedido(formaPagamento);

            DarBaixaNoEstoque();            
            EsvaziarCarrinho();

            return pedido;
        }

        private Pedido CriarPedido(FormaPagamento formaPagamento)
        {
            var pedido = new Pedido
                             {
                                 FormaPagamento = formaPagamento,
                                 DataDoPedido = DateTime.Now
                             };

            pedido.ItensPedido.AddRange(this.ItensPedido);
            return pedido;
        }

        private void DarBaixaNoEstoque()
        {
            this.ItensPedido.ForEach(x => x.DarBaixaNoEstoque());
        }

        public double CalcularPreco()
        {
            return ItensPedido.Sum(x => x.CalcularPreco());
        }

        private void EsvaziarCarrinho()
        {
            ItensPedido.Clear();
        }

        public bool CompraPodeSerFinalizada()
        {
            return ItensPedido.TrueForAll(x => x.ExisteNoEstoque());
        }

        public void RemoverProduto(string idProduto)
        {
            ItensPedido.RemoveAll(x => x.Produto.Id.ToString().Equals(idProduto));
        }
    }
}
