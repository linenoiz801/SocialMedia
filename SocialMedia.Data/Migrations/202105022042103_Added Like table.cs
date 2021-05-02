namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLiketable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            AddColumn("dbo.Reply", "CommentID", c => c.Int());
            CreateIndex("dbo.Reply", "CommentID");
            AddForeignKey("dbo.Reply", "CommentID", "dbo.Comment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "CommentID", "dbo.Comment");
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "CommentID" });
            DropIndex("dbo.Like", new[] { "PostId" });
            DropColumn("dbo.Reply", "CommentID");
            DropTable("dbo.Like");
        }
    }
}
