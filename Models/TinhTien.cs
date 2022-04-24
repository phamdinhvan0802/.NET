using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class TinhTien
    {
        public KhachHang KhachHang { get; set; }
        public int ThanhTien { get; set; }
        public PhongThue Phong { get; set; }
        public IEnumerable<DungDV> DichVu { get; set; }
    }
}