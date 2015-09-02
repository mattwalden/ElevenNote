namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropOkToDelete : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OkToDelete");
        }
        
        public override void Down()
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
    }
}
