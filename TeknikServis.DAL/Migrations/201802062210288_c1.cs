namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Arizalar", "IslemTarihi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arizalar", "IslemTarihi", c => c.DateTime(nullable: false));
        }
    }
}
