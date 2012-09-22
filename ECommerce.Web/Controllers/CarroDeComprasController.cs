using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Domain.AgregadoPedido;
using ECommerce.Domain.AgregadoProduto;

namespace ECommerce.Web.Controllers
{
    public class CarroDeComprasController : Controller
    {
        private IProdutoService _produtoService;
        private IPedidoService _pedidoService;

        public CarroDeComprasController(IProdutoService produtoService, IPedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
            this._produtoService = produtoService;
        }

        public ActionResult AdicionarItem(CarroDeCompras carroDeCompras, int idProduto, int quantidade)
        {
            var produto = _produtoService.ObterTodosProdutos().First(x => x.Id == idProduto);
            carroDeCompras.AdicionarItemPedido(new ItemPedido() {Produto = produto, Quantidade = quantidade});
            TempData["Mensagem"] = "Produto adicionado com sucesso.";

            return RedirectToAction("Index", "Produto");
        }

        public ActionResult Index(CarroDeCompras carroDeCompras)
        {
            return View(carroDeCompras);
        }

        public ActionResult FinalizarCompra(CarroDeCompras carroDeCompras, string idFormaPagamento)
        {
            if (carroDeCompras.CompraPodeSerFinalizada())
            {
                var pedido = carroDeCompras.FinalizarCompra(FormaPagamento.ObterPorId(idFormaPagamento));
                _pedidoService.IncluirPedido(pedido);
                TempData["Mensagem"] = "Pedido realizado com sucesso.";
            } else
            {
                TempData["Mensagem"] = "Estoque insuficiente para sua compra.";
            }
            
            return RedirectToAction("Index");
        }


        public ActionResult RemoverProduto(CarroDeCompras carroDeCompras, string idProduto)
        {
            carroDeCompras.RemoverProduto(idProduto);
            TempData["Mensagem"] = "Produto removido com sucesso.";
            return View("Index", carroDeCompras);
        }
    }
}
