namespace NFC_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupa",
                c => new
                    {
                        GrupaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GrupaId)
                .ForeignKey("dbo.Lodowka", t => t.GrupaId)
                .Index(t => t.GrupaId);
            
            CreateTable(
                "dbo.Lodowka",
                c => new
                    {
                        LodowkaId = c.Int(nullable: false, identity: true),
                        Pojemnosc = c.Int(nullable: false),
                        DataAktualizacji = c.DateTime(nullable: false),
                        GrupaId = c.Int(),
                    })
                .PrimaryKey(t => t.LodowkaId);
            
            CreateTable(
                "dbo.StanLodowki",
                c => new
                    {
                        LodowkaId = c.Int(nullable: false),
                        ProduktId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LodowkaId, t.ProduktId })
                .ForeignKey("dbo.Lodowka", t => t.LodowkaId, cascadeDelete: true)
                .ForeignKey("dbo.Produkt", t => t.ProduktId, cascadeDelete: true)
                .Index(t => t.LodowkaId)
                .Index(t => t.ProduktId);
            
            CreateTable(
                "dbo.Produkt",
                c => new
                    {
                        ProduktId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        RFIDTag = c.String(nullable: false),
                        DataWaznosci = c.DateTime(nullable: false),
                        Producent = c.String(),
                        GlobalnyNumerJednostkiHandlowej = c.Int(nullable: false),
                        NumerPartiiProdukcyjnej = c.Int(nullable: false),
                        Cena = c.Single(nullable: false),
                        Zamowienie_ZamowienieId = c.Int(),
                    })
                .PrimaryKey(t => t.ProduktId)
                .ForeignKey("dbo.Zamowienie", t => t.Zamowienie_ZamowienieId)
                .Index(t => t.Zamowienie_ZamowienieId);
            
            CreateTable(
                "dbo.UpodobaniaUzytkownika",
                c => new
                    {
                        UzytkownikId = c.String(nullable: false, maxLength: 128),
                        ProduktId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UzytkownikId, t.ProduktId })
                .ForeignKey("dbo.Produkt", t => t.ProduktId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UzytkownikId, cascadeDelete: true)
                .Index(t => t.UzytkownikId)
                .Index(t => t.ProduktId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        DataRejestracji = c.DateTime(nullable: false),
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
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowienieId = c.Int(nullable: false, identity: true),
                        DataZamowienia = c.DateTime(nullable: false),
                        DataDostarczenia = c.DateTime(nullable: false),
                        TypZamowienia = c.Int(nullable: false),
                        UzytkownikId = c.String(maxLength: 128),
                        LodowkaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZamowienieId)
                .ForeignKey("dbo.Lodowka", t => t.LodowkaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UzytkownikId)
                .Index(t => t.UzytkownikId)
                .Index(t => t.LodowkaId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UzytkownikGrupa",
                c => new
                    {
                        Uzytkownik_Id = c.String(nullable: false, maxLength: 128),
                        Grupa_GrupaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Uzytkownik_Id, t.Grupa_GrupaId })
                .ForeignKey("dbo.AspNetUsers", t => t.Uzytkownik_Id, cascadeDelete: true)
                .ForeignKey("dbo.Grupa", t => t.Grupa_GrupaId, cascadeDelete: true)
                .Index(t => t.Uzytkownik_Id)
                .Index(t => t.Grupa_GrupaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Zamowienie", "UzytkownikId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Produkt", "Zamowienie_ZamowienieId", "dbo.Zamowienie");
            DropForeignKey("dbo.Zamowienie", "LodowkaId", "dbo.Lodowka");
            DropForeignKey("dbo.UpodobaniaUzytkownika", "UzytkownikId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UzytkownikGrupa", "Grupa_GrupaId", "dbo.Grupa");
            DropForeignKey("dbo.UzytkownikGrupa", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UpodobaniaUzytkownika", "ProduktId", "dbo.Produkt");
            DropForeignKey("dbo.StanLodowki", "ProduktId", "dbo.Produkt");
            DropForeignKey("dbo.StanLodowki", "LodowkaId", "dbo.Lodowka");
            DropForeignKey("dbo.Grupa", "GrupaId", "dbo.Lodowka");
            DropIndex("dbo.UzytkownikGrupa", new[] { "Grupa_GrupaId" });
            DropIndex("dbo.UzytkownikGrupa", new[] { "Uzytkownik_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Zamowienie", new[] { "LodowkaId" });
            DropIndex("dbo.Zamowienie", new[] { "UzytkownikId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UpodobaniaUzytkownika", new[] { "ProduktId" });
            DropIndex("dbo.UpodobaniaUzytkownika", new[] { "UzytkownikId" });
            DropIndex("dbo.Produkt", new[] { "Zamowienie_ZamowienieId" });
            DropIndex("dbo.StanLodowki", new[] { "ProduktId" });
            DropIndex("dbo.StanLodowki", new[] { "LodowkaId" });
            DropIndex("dbo.Grupa", new[] { "GrupaId" });
            DropTable("dbo.UzytkownikGrupa");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Zamowienie");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UpodobaniaUzytkownika");
            DropTable("dbo.Produkt");
            DropTable("dbo.StanLodowki");
            DropTable("dbo.Lodowka");
            DropTable("dbo.Grupa");
        }
    }
}
