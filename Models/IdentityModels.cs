using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CuoiKy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }
        [Required]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Required]
        [Display(Name = "CMND")]
        public string CMND { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<Phong> Phong { get; set; }
        public DbSet<PhongThue> PhongThue { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<DichVu> DichVu { get; set; }
        public DbSet<DungDV> DungDV { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}