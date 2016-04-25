namespace Vattenfall_IT_test.DataMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FooModels", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FooModels", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FooModels", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FooModels", "Created", c => c.DateTime(nullable: false));
        }
    }
}
