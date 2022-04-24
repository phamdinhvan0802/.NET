using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public string TenHD { get; set; }
        public PhongThue PhongThue { get; set; }
        public int PhongThueId { get; set; }
        public NhanVien NhanVien { get; set; }
        public int NhanVienId { get; set; }
        public DateTime NgaylapHD { get; set; }
        public int Tongtien { get; set; }
    }
}