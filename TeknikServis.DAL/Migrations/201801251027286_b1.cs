namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arizalar", "FirmaAdi", c => c.String());
            DropColumn("dbo.Arizalar", "FaturaKodu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arizalar", "FaturaKodu", c => c.String());
            DropColumn("dbo.Arizalar", "FirmaAdi");
        }
    }
}
