namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arizalar", "lat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Arizalar", "lng", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Arizalar", "haritaBaslik");
            DropColumn("dbo.Arizalar", "haritaNokta");
            DropColumn("dbo.Arizalar", "haritaZoom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arizalar", "haritaZoom", c => c.Int(nullable: false));
            AddColumn("dbo.Arizalar", "haritaNokta", c => c.String());
            AddColumn("dbo.Arizalar", "haritaBaslik", c => c.String());
            DropColumn("dbo.Arizalar", "lng");
            DropColumn("dbo.Arizalar", "lat");
        }
    }
}
