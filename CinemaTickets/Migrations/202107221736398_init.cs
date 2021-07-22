namespace CinemaTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeRestrictions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MinAge = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AgeRestrictions");
        }
    }
}
