namespace Kingsley.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinkID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        LinkTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LinkID)
                .ForeignKey("dbo.LinkTypes", t => t.LinkTypeID, cascadeDelete: true)
                .Index(t => t.LinkTypeID);
            
            CreateTable(
                "dbo.LinkTypes",
                c => new
                    {
                        LinkTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.LinkTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "LinkTypeID", "dbo.LinkTypes");
            DropIndex("dbo.Links", new[] { "LinkTypeID" });
            DropTable("dbo.LinkTypes");
            DropTable("dbo.Links");
        }
    }
}
