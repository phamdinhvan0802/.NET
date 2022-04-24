using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nhập họ tên")]
        [Display(Name = "Họ Tên")]
        public string Hoten { get; set; }
        [Required(ErrorMessage = "Nhập ngày sinh")]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Nhập giới tính")]
        [Display(Name = "Giới Tính")]
        public string Gioitinh { get; set; }
        [Required(ErrorMessage = "Nhập CMND")]
        [Display(Name = "CMND")]
        public string CMND { get; set; }
        [Required(ErrorMessage = "Nhập số điện thoại")]
        [Display(Name = "Số Điện Thoại")]
        public string SDT { get; set; }
    }
}