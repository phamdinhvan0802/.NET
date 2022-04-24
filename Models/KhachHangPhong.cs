using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CuoiKy.Models
{
    public class KhachHangPhong
    {
        public PhongThue Phongthue { get; set; }
        [Required(ErrorMessage = "Chọn khách hàng")]
        public IEnumerable<KhachHang> KhachHang { get; set; }
        [Required(ErrorMessage = "Chọn phòng")]
        public IEnumerable<Phong> Phong { get; set; }
    }
}