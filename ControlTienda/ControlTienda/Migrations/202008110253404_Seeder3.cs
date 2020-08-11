namespace ControlTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seeder3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Nickname", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 15));
            AlterColumn("dbo.Users", "Nickname", c => c.String(maxLength: 8));
        }
    }
}
