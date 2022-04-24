namespace CuoiKy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DichVus", "ImageDV", c => c.String());
            AddColumn("dbo.Phongs", "ImageP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phongs", "ImageP");
            DropColumn("dbo.DichVus", "ImageDV");
        }
    }
}
