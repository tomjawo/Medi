namespace Medi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Examinations", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Examinations", "User_Id");
            AddForeignKey("dbo.Examinations", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Examinations", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Examinations", new[] { "User_Id" });
            DropColumn("dbo.Examinations", "User_Id");
        }
    }
}
