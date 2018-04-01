namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anketler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnketIsmi = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sorular",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoruMetni = c.String(nullable: false),
                        AnketID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Anketler", t => t.AnketID, cascadeDelete: true)
                .Index(t => t.AnketID);
            
            CreateTable(
                "dbo.Cevaplar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoruCevap = c.Int(),
                        SoruID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sorular", t => t.SoruID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.SoruID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 25),
                        SurName = c.String(maxLength: 25),
                        RegisterDate = c.DateTime(nullable: false),
                        ActivationCode = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Arizalar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KategoriID = c.Int(nullable: false),
                        Aciklama = c.String(nullable: false),
                        UserID = c.String(maxLength: 128),
                        OperatorID = c.String(maxLength: 128),
                        TeknisyenID = c.String(maxLength: 128),
                        Baslik = c.String(nullable: false),
                        Rapor = c.String(),
                        FaturaKodu = c.String(),
                        IslemTarihi = c.DateTime(nullable: false),
                        Konum = c.String(nullable: false),
                        AdresAciklamasi = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.OperatorID)
                .ForeignKey("dbo.AspNetUsers", t => t.TeknisyenID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.KategoriID)
                .Index(t => t.UserID)
                .Index(t => t.OperatorID)
                .Index(t => t.TeknisyenID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ArizaDurumlar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArizaID = c.Int(nullable: false),
                        Durum = c.Int(nullable: false),
                        Aciklama = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arizalar", t => t.ArizaID, cascadeDelete: true)
                .Index(t => t.ArizaID);
            
            CreateTable(
                "dbo.Fotograflar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false),
                        ArızaID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arizalar", t => t.ArızaID, cascadeDelete: true)
                .Index(t => t.ArızaID);
            
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cevaplar", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "TeknisyenID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "OperatorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Arizalar", "KategoriID", "dbo.Kategoriler");
            DropForeignKey("dbo.Fotograflar", "ArızaID", "dbo.Arizalar");
            DropForeignKey("dbo.ArizaDurumlar", "ArizaID", "dbo.Arizalar");
            DropForeignKey("dbo.Cevaplar", "SoruID", "dbo.Sorular");
            DropForeignKey("dbo.Sorular", "AnketID", "dbo.Anketler");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Fotograflar", new[] { "ArızaID" });
            DropIndex("dbo.ArizaDurumlar", new[] { "ArizaID" });
            DropIndex("dbo.Arizalar", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Arizalar", new[] { "TeknisyenID" });
            DropIndex("dbo.Arizalar", new[] { "OperatorID" });
            DropIndex("dbo.Arizalar", new[] { "UserID" });
            DropIndex("dbo.Arizalar", new[] { "KategoriID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cevaplar", new[] { "UserID" });
            DropIndex("dbo.Cevaplar", new[] { "SoruID" });
            DropIndex("dbo.Sorular", new[] { "AnketID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.Fotograflar");
            DropTable("dbo.ArizaDurumlar");
            DropTable("dbo.Arizalar");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Cevaplar");
            DropTable("dbo.Sorular");
            DropTable("dbo.Anketler");
        }
    }
}
