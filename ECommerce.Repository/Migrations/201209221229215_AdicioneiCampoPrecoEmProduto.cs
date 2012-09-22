namespace ECommerce.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicioneiCampoPrecoEmProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Preco", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Preco");
        }
    }
}
