using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Domain.AgregadoProduto;
using ECommerce.Repository.Entity;

namespace ECommerce.Repository.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private EntityContext _context;

        public ProdutoRepository(EntityContext context)
        {
            this._context = context;
        }

        public IQueryable<Produto> ObterTodosProdutos()
        {
            return _context.Produtos.AsQueryable();
        }
    }
}
