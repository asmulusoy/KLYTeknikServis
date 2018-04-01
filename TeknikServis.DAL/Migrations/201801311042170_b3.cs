namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirmaAdi", c => c.String(maxLength: 50));
            DropColumn("dbo.Arizalar", "FirmaAdi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arizalar", "FirmaAdi", c => c.String());
            DropColumn("dbo.AspNetUsers", "FirmaAdi");
        }
    }
}
