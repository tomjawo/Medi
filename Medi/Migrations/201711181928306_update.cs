namespace Medi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Examination_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Examination_Id");
            AddForeignKey("dbo.AspNetUsers", "Examination_Id", "dbo.Examinations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Examination_Id", "dbo.Examinations");
            DropIndex("dbo.AspNetUsers", new[] { "Examination_Id" });
            DropColumn("dbo.AspNetUsers", "Examination_Id");
        }
    }
}
