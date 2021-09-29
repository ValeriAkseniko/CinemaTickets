namespace CinemaTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableParameters : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "CashierId", "dbo.Cashiers");
            DropIndex("dbo.Tickets", new[] { "CashierId" });
            AlterColumn("dbo.Tickets", "CashierId", c => c.Guid());
            AlterColumn("dbo.Tickets", "TypeOfCalculation", c => c.Int());
            AlterColumn("dbo.Tickets", "DateOfSale", c => c.DateTime());
            CreateIndex("dbo.Tickets", "CashierId");
            AddForeignKey("dbo.Tickets", "CashierId", "dbo.Cashiers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CashierId", "dbo.Cashiers");
            DropIndex("dbo.Tickets", new[] { "CashierId" });
            AlterColumn("dbo.Tickets", "DateOfSale", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "TypeOfCalculation", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "CashierId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tickets", "CashierId");
            AddForeignKey("dbo.Tickets", "CashierId", "dbo.Cashiers", "Id", cascadeDelete: true);
        }
    }
}
