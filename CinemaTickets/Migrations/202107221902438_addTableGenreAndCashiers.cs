namespace CinemaTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableGenreAndCashiers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cashiers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Genres");
            DropTable("dbo.Cashiers");
        }
    }
}
