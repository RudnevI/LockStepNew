namespace LockStepNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prices", "From", c => c.DateTime());
            AlterColumn("dbo.Prices", "To", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "To", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Prices", "From", c => c.DateTime(nullable: false));
        }
    }
}
