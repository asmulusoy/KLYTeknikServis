namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Arizalar", "lat", c => c.String());
            AlterColumn("dbo.Arizalar", "lng", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Arizalar", "lng", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Arizalar", "lat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
