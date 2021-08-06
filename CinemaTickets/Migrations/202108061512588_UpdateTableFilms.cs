namespace CinemaTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableFilms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Films", "AgeRestrictions_Id", "dbo.AgeRestrictions");
            DropIndex("dbo.Films", new[] { "AgeRestrictions_Id" });
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Films", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.Films", name: "AgeRestrictions_Id", newName: "AgeRestrictionId");
            AlterColumn("dbo.Films", "AgeRestrictionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Films", "GenreId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Films", "AgeRestrictionId");
            CreateIndex("dbo.Films", "GenreId");
            AddForeignKey("dbo.Films", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Films", "AgeRestrictionId", "dbo.AgeRestrictions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "AgeRestrictionId", "dbo.AgeRestrictions");
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "GenreId" });
            DropIndex("dbo.Films", new[] { "AgeRestrictionId" });
            AlterColumn("dbo.Films", "GenreId", c => c.Guid());
            AlterColumn("dbo.Films", "AgeRestrictionId", c => c.Guid());
            RenameColumn(table: "dbo.Films", name: "AgeRestrictionId", newName: "AgeRestrictions_Id");
            RenameColumn(table: "dbo.Films", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Films", "Genre_Id");
            CreateIndex("dbo.Films", "AgeRestrictions_Id");
            AddForeignKey("dbo.Films", "AgeRestrictions_Id", "dbo.AgeRestrictions", "Id");
            AddForeignKey("dbo.Films", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
