namespace Vattenfall_IT_test.DataMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FooModels",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Surename = c.String(),
                        Age = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FooModels");
        }
    }
}
