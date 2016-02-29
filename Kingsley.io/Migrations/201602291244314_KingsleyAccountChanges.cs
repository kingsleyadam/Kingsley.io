namespace Kingsley.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KingsleyAccountChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KingsleyAccounts", "FirstName", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.KingsleyAccounts", "LastName", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KingsleyAccounts", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.KingsleyAccounts", "FirstName", c => c.String(nullable: false));
        }
    }
}
