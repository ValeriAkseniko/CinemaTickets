namespace CinemaTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableHallsRowsPlaces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rows",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        HallId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        RowId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rows", t => t.RowId, cascadeDelete: true)
                .Index(t => t.RowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "RowId", "dbo.Rows");
            DropForeignKey("dbo.Rows", "HallId", "dbo.Halls");
            DropIndex("dbo.Places", new[] { "RowId" });
            DropIndex("dbo.Rows", new[] { "HallId" });
            DropTable("dbo.Places");
            DropTable("dbo.Rows");
            DropTable("dbo.Halls");
        }
    }
}
