namespace Medi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Examination_Id", "dbo.Examinations");
            DropIndex("dbo.AspNetUsers", new[] { "Examination_Id" });
            DropColumn("dbo.AspNetUsers", "Examination_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Examination_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Examination_Id");
            AddForeignKey("dbo.AspNetUsers", "Examination_Id", "dbo.Examinations", "Id");
        }
    }
}
