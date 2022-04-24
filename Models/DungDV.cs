using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class DungDV
    {
        public int Id { get; set; }
        public KhachHang KhachHang { get; set; }
        [Required(ErrorMessage = "Chọn khách hàng")]
        [Display(Name = "Mã Khách Hàng")]
        public int KhachHangId { get; set; }
        public DichVu DichVu { get; set; }
        [Required(ErrorMessage = "Chọn dịch vụ")]
        [Display(Name = "Mã Dịch Vụ")]
        public int DichVuId { get; set; }
        [Required(ErrorMessage = "Nhập ngày sử dụng")]
        [Display(Name = "Ngày Sử Dụng")]
        public DateTime NgaySD { get; set; }
    }
}