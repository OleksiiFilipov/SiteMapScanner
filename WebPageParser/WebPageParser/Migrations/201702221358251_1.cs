namespace WebPageParser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CssLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinkNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoorUrl = c.String(),
                        Url = c.String(),
                        LoadTime = c.Long(nullable: false),
                        HtmlSize = c.Long(nullable: false),
                        IsInternal = c.Boolean(nullable: false),
                        LinkNode_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LinkNodes", t => t.LinkNode_Id)
                .Index(t => t.LinkNode_Id);
            
            CreateTable(
                "dbo.ImgLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Root_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LinkNodes", t => t.Root_Id)
                .Index(t => t.Root_Id);
            
            CreateTable(
                "dbo.LinkNodeCssLinks",
                c => new
                    {
                        LinkNode_Id = c.Int(nullable: false),
                        CssLink_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LinkNode_Id, t.CssLink_Id })
                .ForeignKey("dbo.LinkNodes", t => t.LinkNode_Id, cascadeDelete: true)
                .ForeignKey("dbo.CssLinks", t => t.CssLink_Id, cascadeDelete: true)
                .Index(t => t.LinkNode_Id)
                .Index(t => t.CssLink_Id);
            
            CreateTable(
                "dbo.LinkNodeImgLinks",
                c => new
                    {
                        LinkNode_Id = c.Int(nullable: false),
                        ImgLink_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LinkNode_Id, t.ImgLink_Id })
                .ForeignKey("dbo.LinkNodes", t => t.LinkNode_Id, cascadeDelete: true)
                .ForeignKey("dbo.ImgLinks", t => t.ImgLink_Id, cascadeDelete: true)
                .Index(t => t.LinkNode_Id)
                .Index(t => t.ImgLink_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "Root_Id", "dbo.LinkNodes");
            DropForeignKey("dbo.LinkNodeImgLinks", "ImgLink_Id", "dbo.ImgLinks");
            DropForeignKey("dbo.LinkNodeImgLinks", "LinkNode_Id", "dbo.LinkNodes");
            DropForeignKey("dbo.LinkNodeCssLinks", "CssLink_Id", "dbo.CssLinks");
            DropForeignKey("dbo.LinkNodeCssLinks", "LinkNode_Id", "dbo.LinkNodes");
            DropForeignKey("dbo.LinkNodes", "LinkNode_Id", "dbo.LinkNodes");
            DropIndex("dbo.LinkNodeImgLinks", new[] { "ImgLink_Id" });
            DropIndex("dbo.LinkNodeImgLinks", new[] { "LinkNode_Id" });
            DropIndex("dbo.LinkNodeCssLinks", new[] { "CssLink_Id" });
            DropIndex("dbo.LinkNodeCssLinks", new[] { "LinkNode_Id" });
            DropIndex("dbo.Sites", new[] { "Root_Id" });
            DropIndex("dbo.LinkNodes", new[] { "LinkNode_Id" });
            DropTable("dbo.LinkNodeImgLinks");
            DropTable("dbo.LinkNodeCssLinks");
            DropTable("dbo.Sites");
            DropTable("dbo.ImgLinks");
            DropTable("dbo.LinkNodes");
            DropTable("dbo.CssLinks");
        }
    }
}
