namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Arizalar", "Aciklama", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Arizalar", "Baslik", c => c.String(nullable: false, maxLength: 90));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Arizalar", "Baslik", c => c.String(nullable: false));
            AlterColumn("dbo.Arizalar", "Aciklama", c => c.String(nullable: false));
        }
    }
}
