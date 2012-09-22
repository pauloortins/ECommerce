using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.AgregadoProduto
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> ObterTodosProdutos();
    }
}
