namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arizalar", "sonuclandiMi", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Arizalar", "sonuclandiMi");
        }
    }
}
