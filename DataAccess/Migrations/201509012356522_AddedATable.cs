namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedATable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OkToDelete",
                c => new
                    {
                        SomeColumn = c.String(nullable: false, maxLength: 128),
                        SomeOtherColumn = c.String(),
                        OneMoreColumn = c.String(),
                    })
                .PrimaryKey(t => t.SomeColumn);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OkToDelete");
        }
    }
}
