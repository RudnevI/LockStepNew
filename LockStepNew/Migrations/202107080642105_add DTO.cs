namespace LockStepNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDTO : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prices", "From", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "From", c => c.DateTime(nullable: false));
        }
    }
}
