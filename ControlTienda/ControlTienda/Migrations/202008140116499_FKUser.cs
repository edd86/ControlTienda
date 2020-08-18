namespace ControlTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Rol_Id", "dbo.Rols");
            DropIndex("dbo.Users", new[] { "Rol_Id" });
            RenameColumn(table: "dbo.Users", name: "Rol_Id", newName: "RolId");
            AlterColumn("dbo.Users", "RolId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RolId");
            AddForeignKey("dbo.Users", "RolId", "dbo.Rols", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RolId", "dbo.Rols");
            DropIndex("dbo.Users", new[] { "RolId" });
            AlterColumn("dbo.Users", "RolId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "RolId", newName: "Rol_Id");
            CreateIndex("dbo.Users", "Rol_Id");
            AddForeignKey("dbo.Users", "Rol_Id", "dbo.Rols", "Id");
        }
    }
}
