using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Domain.AgregadoProduto;

namespace ECommerce.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            this._produtoService = produtoService;
        }

        //
        // GET: /Produto/
        public ActionResult Index()
        {
            var listaProdutos = this._produtoService.ObterTodosProdutos().ToList();

            return View(listaProdutos);
        }
    }
}
