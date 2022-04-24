namespace CuoiKy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHangs", "Hoten", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "Gioitinh", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "CMND", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "SDT", c => c.String(nullable: false));
            AlterColumn("dbo.PhongThues", "NgayDen", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PhongThues", "NgayDi", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhongThues", "NgayDi", c => c.DateTime());
            AlterColumn("dbo.PhongThues", "NgayDen", c => c.DateTime());
            AlterColumn("dbo.KhachHangs", "SDT", c => c.String());
            AlterColumn("dbo.KhachHangs", "CMND", c => c.String());
            AlterColumn("dbo.KhachHangs", "Gioitinh", c => c.String());
            AlterColumn("dbo.KhachHangs", "Hoten", c => c.String());
        }
    }
}
