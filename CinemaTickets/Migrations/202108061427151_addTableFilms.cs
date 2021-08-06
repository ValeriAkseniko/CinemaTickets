namespace CinemaTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableFilms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Duration = c.Int(nullable: false),
                        Description = c.String(),
                        AgeRestrictions_Id = c.Guid(),
                        Genre_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeRestrictions", t => t.AgeRestrictions_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.AgeRestrictions_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Films", "AgeRestrictions_Id", "dbo.AgeRestrictions");
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            DropIndex("dbo.Films", new[] { "AgeRestrictions_Id" });
            DropTable("dbo.Films");
        }
    }
}
