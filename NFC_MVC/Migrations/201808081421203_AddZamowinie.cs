namespace NFC_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZamowinie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produkt", "Zamowienie_ZamowienieId", "dbo.Zamowienie");
            DropIndex("dbo.Produkt", new[] { "Zamowienie_ZamowienieId" });
            CreateTable(
                "dbo.ZamowienieProdukt",
                c => new
                    {
                        Zamowienie_ZamowienieId = c.Int(nullable: false),
                        Produkt_ProduktId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zamowienie_ZamowienieId, t.Produkt_ProduktId })
                .ForeignKey("dbo.Zamowienie", t => t.Zamowienie_ZamowienieId, cascadeDelete: true)
                .ForeignKey("dbo.Produkt", t => t.Produkt_ProduktId, cascadeDelete: true)
                .Index(t => t.Zamowienie_ZamowienieId)
                .Index(t => t.Produkt_ProduktId);
            
            DropColumn("dbo.Produkt", "Zamowienie_ZamowienieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produkt", "Zamowienie_ZamowienieId", c => c.Int());
            DropForeignKey("dbo.ZamowienieProdukt", "Produkt_ProduktId", "dbo.Produkt");
            DropForeignKey("dbo.ZamowienieProdukt", "Zamowienie_ZamowienieId", "dbo.Zamowienie");
            DropIndex("dbo.ZamowienieProdukt", new[] { "Produkt_ProduktId" });
            DropIndex("dbo.ZamowienieProdukt", new[] { "Zamowienie_ZamowienieId" });
            DropTable("dbo.ZamowienieProdukt");
            CreateIndex("dbo.Produkt", "Zamowienie_ZamowienieId");
            AddForeignKey("dbo.Produkt", "Zamowienie_ZamowienieId", "dbo.Zamowienie", "ZamowienieId");
        }
    }
}
