using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string HotenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Gioitinh { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string Matkhau { get; set; }
    }
}