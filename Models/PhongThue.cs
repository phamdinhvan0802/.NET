using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class PhongThue
    {
        public int Id { get; set; }
        public KhachHang KhachHang { get; set; }
        [Required(ErrorMessage = "Chọn khách hàng")]
        [Display(Name = "Mã Khách Hàng")]
        public int KhachHangId { get; set; }
        public Phong Phong { get; set; }
        [Required(ErrorMessage = "Chọn phòng")]
        [Display(Name = "Mã Phòng")]
        public int PhongId { get; set; }
        [Required(ErrorMessage = "Nhập ngày đến")]
        [Display(Name = "Ngày Đến")]
        public DateTime? NgayDen { get; set; }
        [Required(ErrorMessage = "Nhập ngày đi")]
        [Display(Name = "Ngày Đi")]
        public DateTime? NgayDi { get; set; }
    }
}