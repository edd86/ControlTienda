namespace ControlTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoggModify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loggs", "User_Id", "dbo.Users");
            DropIndex("dbo.Loggs", new[] { "User_Id" });
            RenameColumn(table: "dbo.Loggs", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Loggs", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Loggs", "UserId");
            AddForeignKey("dbo.Loggs", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loggs", "UserId", "dbo.Users");
            DropIndex("dbo.Loggs", new[] { "UserId" });
            AlterColumn("dbo.Loggs", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Loggs", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Loggs", "User_Id");
            AddForeignKey("dbo.Loggs", "User_Id", "dbo.Users", "Id");
        }
    }
}
