namespace ControlTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CategoryId_Id", c => c.Int());
            CreateIndex("dbo.Products", "CategoryId_Id");
            AddForeignKey("dbo.Products", "CategoryId_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId_Id" });
            DropColumn("dbo.Products", "CategoryId_Id");
        }
    }
}
