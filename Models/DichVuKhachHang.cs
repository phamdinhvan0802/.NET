using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CuoiKy.Models
{
    public class DichVuKhachHang
    {
        public DungDV Dungdv { get; set; }
        [Required(ErrorMessage = "Chọn khách hàng")]
        public IEnumerable<KhachHang> KhachHang { get; set; }
        [Required(ErrorMessage = "Chọn dịch vụ")]
        public IEnumerable<DichVu> DichVu { get; set; }
    }
}