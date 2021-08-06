namespace CinemaTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableTickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilmId = c.Guid(nullable: false),
                        PlaceId = c.Guid(nullable: false),
                        StatusId = c.Guid(nullable: false),
                        CashierId = c.Guid(nullable: false),
                        TypeOfCalculation = c.Int(nullable: false),
                        DateOfSale = c.DateTime(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cashiers", t => t.CashierId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.PlaceId)
                .Index(t => t.StatusId)
                .Index(t => t.CashierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Tickets", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Tickets", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Tickets", "CashierId", "dbo.Cashiers");
            DropIndex("dbo.Tickets", new[] { "CashierId" });
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropIndex("dbo.Tickets", new[] { "PlaceId" });
            DropIndex("dbo.Tickets", new[] { "FilmId" });
            DropTable("dbo.Tickets");
        }
    }
}
