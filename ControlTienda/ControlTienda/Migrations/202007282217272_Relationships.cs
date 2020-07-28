namespace ControlTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashFlows", "Cash_Id", c => c.Int());
            AddColumn("dbo.DetailPurchases", "Product_Id", c => c.Int());
            AddColumn("dbo.DetailPurchases", "Purchase_Id", c => c.Int());
            AddColumn("dbo.DetailSales", "Product_Id", c => c.Int());
            AddColumn("dbo.DetailSales", "Sale_Id", c => c.Int());
            AddColumn("dbo.Loggs", "User_Id", c => c.Int());
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            AddColumn("dbo.Purchases", "CashFlow_Id", c => c.Int());
            AddColumn("dbo.Refunds", "DetailSale_Id", c => c.Int());
            AddColumn("dbo.Sales", "CashFlow_Id", c => c.Int());
            AddColumn("dbo.Sales", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "Rol_Id", c => c.Int());
            CreateIndex("dbo.CashFlows", "Cash_Id");
            CreateIndex("dbo.DetailPurchases", "Product_Id");
            CreateIndex("dbo.DetailPurchases", "Purchase_Id");
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Purchases", "CashFlow_Id");
            CreateIndex("dbo.DetailSales", "Product_Id");
            CreateIndex("dbo.DetailSales", "Sale_Id");
            CreateIndex("dbo.Sales", "CashFlow_Id");
            CreateIndex("dbo.Sales", "User_Id");
            CreateIndex("dbo.Users", "Rol_Id");
            CreateIndex("dbo.Loggs", "User_Id");
            CreateIndex("dbo.Refunds", "DetailSale_Id");
            AddForeignKey("dbo.CashFlows", "Cash_Id", "dbo.Cashes", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.DetailPurchases", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Purchases", "CashFlow_Id", "dbo.CashFlows", "Id");
            AddForeignKey("dbo.DetailPurchases", "Purchase_Id", "dbo.Purchases", "Id");
            AddForeignKey("dbo.DetailSales", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Sales", "CashFlow_Id", "dbo.CashFlows", "Id");
            AddForeignKey("dbo.Users", "Rol_Id", "dbo.Rols", "Id");
            AddForeignKey("dbo.Sales", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.DetailSales", "Sale_Id", "dbo.Sales", "Id");
            AddForeignKey("dbo.Loggs", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Refunds", "DetailSale_Id", "dbo.DetailSales", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Refunds", "DetailSale_Id", "dbo.DetailSales");
            DropForeignKey("dbo.Loggs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DetailSales", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Sales", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Rol_Id", "dbo.Rols");
            DropForeignKey("dbo.Sales", "CashFlow_Id", "dbo.CashFlows");
            DropForeignKey("dbo.DetailSales", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.DetailPurchases", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "CashFlow_Id", "dbo.CashFlows");
            DropForeignKey("dbo.DetailPurchases", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.CashFlows", "Cash_Id", "dbo.Cashes");
            DropIndex("dbo.Refunds", new[] { "DetailSale_Id" });
            DropIndex("dbo.Loggs", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Rol_Id" });
            DropIndex("dbo.Sales", new[] { "User_Id" });
            DropIndex("dbo.Sales", new[] { "CashFlow_Id" });
            DropIndex("dbo.DetailSales", new[] { "Sale_Id" });
            DropIndex("dbo.DetailSales", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "CashFlow_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.DetailPurchases", new[] { "Purchase_Id" });
            DropIndex("dbo.DetailPurchases", new[] { "Product_Id" });
            DropIndex("dbo.CashFlows", new[] { "Cash_Id" });
            DropColumn("dbo.Users", "Rol_Id");
            DropColumn("dbo.Sales", "User_Id");
            DropColumn("dbo.Sales", "CashFlow_Id");
            DropColumn("dbo.Refunds", "DetailSale_Id");
            DropColumn("dbo.Purchases", "CashFlow_Id");
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Loggs", "User_Id");
            DropColumn("dbo.DetailSales", "Sale_Id");
            DropColumn("dbo.DetailSales", "Product_Id");
            DropColumn("dbo.DetailPurchases", "Purchase_Id");
            DropColumn("dbo.DetailPurchases", "Product_Id");
            DropColumn("dbo.CashFlows", "Cash_Id");
        }
    }
}
