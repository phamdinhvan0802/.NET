using CuoiKy.Extensions;
using CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuoiKy.Controllers
{
    public class ThueDVController : Controller
    {
        private ApplicationDbContext _context;
        public ThueDVController()
        {
            _context = new ApplicationDbContext(); // tao database de ket noi
        }
        // Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: ThueDV
        public ActionResult Index()
        {
            var DVthue = _context.DungDV.ToList();
            return View(DVthue);
        }
        public ActionResult addDV()
        {
            var KH = _context.KhachHang.ToList();
            var DichVus = _context.DichVu.ToList();
            var model = new DichVuKhachHang
            {
                KhachHang = KH,
                DichVu = DichVus,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult addDV(DungDV Dungdv)
        { 
            _context.DungDV.Add(Dungdv);
            this.AddNotification("Thêm thành công!", NotificationType.SUCCESS);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult deleteDV(int id)
        {
            var deleteDV = _context.DungDV.SingleOrDefault(c => c.Id == id);
            _context.DungDV.Remove(deleteDV);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}