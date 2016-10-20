namespace Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Guid(nullable: false),
                        Genre = c.Int(nullable: false),
                        Series = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Year = c.Int(nullable: false),
                        Details = c.String(),
                        NumberofSeries = c.Int(),
                        Renter = c.String(),
                        Rented = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Films");
        }
    }
}
