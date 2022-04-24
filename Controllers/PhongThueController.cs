using CuoiKy.Extensions;
using CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuoiKy.Controllers
{
    public class PhongThueController : Controller
    {
        private ApplicationDbContext _context;
        public PhongThueController()
        {
            _context = new ApplicationDbContext(); // tao database de ket noi
        }
        // Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: PhongThue
        public ActionResult Index()
        {
            var PThue = _context.PhongThue.ToList();
            return View(PThue);
        }
        public ActionResult addPhong()
        {
            var KH = _context.KhachHang.ToList();
            var Phong = _context.Phong.ToList();
            var model = new KhachHangPhong
            {
                KhachHang = KH,
                Phong = Phong
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult addPhong(PhongThue Phongthue)
        {
            var KHKT = _context.PhongThue.SingleOrDefault(c => c.KhachHangId == Phongthue.KhachHangId);
            var PhongKT = _context.PhongThue.SingleOrDefault(c => c.PhongId == Phongthue.PhongId);
            if(PhongKT != null)
            {
                this.AddNotification("Đã có khách " + PhongKT.KhachHangId, NotificationType.ERROR);
            }
            else if(KHKT != null) 
            {
                this.AddNotification("Khách đã có phòng!", NotificationType.ERROR);
            }
            else
            {
                var PhongTT = _context.Phong.SingleOrDefault(a => a.Id == Phongthue.PhongId);
                PhongTT.Tinhtrang = "Có khách";
                _context.PhongThue.Add(Phongthue);
                this.AddNotification("Thêm thành công!", NotificationType.SUCCESS);
            }            
            _context.SaveChanges();// update database
            return RedirectToAction("Index");
        }
        public ActionResult deletePhong(int id, int Phongthue)
        {
            var deletePT = _context.PhongThue.SingleOrDefault(c => c.Id == id);
            _context.PhongThue.Remove(deletePT);
            var deleteTT = _context.Phong.SingleOrDefault(a => a.Id == Phongthue);
            deleteTT.Tinhtrang = "Trống";
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}