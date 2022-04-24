namespace CuoiKy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HoTen", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "NgaySinh", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CMND", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CMND");
            DropColumn("dbo.AspNetUsers", "NgaySinh");
            DropColumn("dbo.AspNetUsers", "HoTen");
        }
    }
}
