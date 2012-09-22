using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.AgregadoProduto
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            this._repository = repository;
        }

        public IQueryable<Produto> ObterTodosProdutos()
        {
            return this._repository.ObterTodosProdutos();
        }
    }
}
