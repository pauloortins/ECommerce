namespace ECommerce.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDoPedido = c.DateTime(nullable: false),
                        FormaPagamento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormaPagamentoes", t => t.FormaPagamento_Id)
                .Index(t => t.FormaPagamento_Id);
            
            CreateTable(
                "dbo.ItemPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Produto_Id = c.Int(),
                        Pedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        QuantidadeEmEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormaPagamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ItemPedidoes", new[] { "Pedido_Id" });
            DropIndex("dbo.ItemPedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.Pedidoes", new[] { "FormaPagamento_Id" });
            DropForeignKey("dbo.ItemPedidoes", "Pedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.ItemPedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "FormaPagamento_Id", "dbo.FormaPagamentoes");
            DropTable("dbo.FormaPagamentoes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.ItemPedidoes");
            DropTable("dbo.Pedidoes");
        }
    }
}
