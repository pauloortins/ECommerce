using ECommerce.Domain.AgregadoProduto;

namespace ECommerce.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerce.Repository.Entity.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerce.Repository.Entity.EntityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Produtos.Add(new Produto() {Id = 1, Nome = "Produto 1", QuantidadeEmEstoque = 10, Preco = 7.50});
            context.Produtos.Add(new Produto() {Id = 2, Nome = "Produto 2", QuantidadeEmEstoque = 20, Preco = 12});
            context.Produtos.Add(new Produto() {Id = 3, Nome = "Produto 3", QuantidadeEmEstoque = 30, Preco = 25});
            context.SaveChanges();
        }
    }
}
