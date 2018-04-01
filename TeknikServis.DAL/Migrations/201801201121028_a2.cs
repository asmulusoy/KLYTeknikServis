namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arizalar", "haritaBaslik", c => c.String());
            AddColumn("dbo.Arizalar", "haritaNokta", c => c.String());
            AddColumn("dbo.Arizalar", "haritaZoom", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Arizalar", "haritaZoom");
            DropColumn("dbo.Arizalar", "haritaNokta");
            DropColumn("dbo.Arizalar", "haritaBaslik");
        }
    }
}
