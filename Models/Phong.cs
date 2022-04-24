using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class Phong
    {
        [Key]
        public int Id { get; set; }
        public string Loaiphong { get; set; }
        public int Giaphong { get; set; }
        public string Tinhtrang { get; set; }
        public string ImageP { get; set; }
    }
}