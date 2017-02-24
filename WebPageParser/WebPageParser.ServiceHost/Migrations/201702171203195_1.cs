namespace WebPageParser.ServiceHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        WithExternalLinks = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                        FilePath = c.String(),
                        Depth = c.Int(),
                        ThreadsCount = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Commands");
        }
    }
}
