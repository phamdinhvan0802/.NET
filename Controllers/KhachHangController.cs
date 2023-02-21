using CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using CuoiKy.Extensions;

namespace CuoiKy.Controllers
{
    public class KhachHangController : Controller
    {
        private ApplicationDbContext _context;
        public KhachHangController()
        {
            _context = new ApplicationDbContext(); // tao database de ket noi
        }
        // Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: KhachHang
        public ActionResult Index(string Search)
        {
            var searchKH = _context.KhachHang.ToList();
            if (!String.IsNullOrEmpty(Search))
            {
                searchKH = searchKH.Where(c => c.Hoten.ToLower().Contains(Search)).ToList();
            }
            return View(searchKH);
        }
        public ActionResult details(int id)
        {
            var detailsKH = _context.KhachHang.SingleOrDefault(c => c.Id == id);// trả về 1 đối tượng khách hàng có id trùng với tham số
            return View(detailsKH);
        }
        public ActionResult edit(int id)
        {
            var editKHv = _context.KhachHang.SingleOrDefault(c => c.Id == id); // hiện trang edit theo id kh
            return View(editKHv);
        }
        // edit KH
        public ActionResult editkh(KhachHang kh)
        {
            var editKH = _context.KhachHang.SingleOrDefault(c => c.Id == kh.Id);
            editKH.Hoten = kh.Hoten;
            editKH.NgaySinh = kh.NgaySinh;
            editKH.Gioitinh = kh.Gioitinh;
            editKH.CMND = kh.CMND;
            editKH.SDT = kh.SDT;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult delete(int id)
        {
            var deleteKH = _context.KhachHang.SingleOrDefault(c => c.Id == id);
            _context.KhachHang.Remove(deleteKH);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult addkh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addkh([Bind(Exclude = "Id")]KhachHang kh)
        {           
            if (!ModelState.IsValid)// kiểm tra validation
            {
                this.AddNotification("Vui lòng nhập đầy đủ thông tin!", NotificationType.ERROR);
                return View(kh);
            }
            _context.KhachHang.Add(kh);
            _context.SaveChanges();// update db
            this.AddNotification("Thêm thành công!", NotificationType.SUCCESS);
            return RedirectToAction("Index");           
        }
        [Obsolete]
        public ActionResult tinhtien(int id)
        {
            var Kh = _context.KhachHang.SingleOrDefault(c => c.Id == id);
            var dv = _context.DungDV.FirstOrDefault(c => c.KhachHangId == id);
            var Phong = _context.PhongThue.FirstOrDefault(m => m.KhachHangId == id);
            var DichVu = _context.DungDV.Where(m => m.KhachHangId == id).Include(m => m.DichVu);
            int Tong;
            int TTienDV;          
            if (dv != null)
            {
                TTienDV = Convert.ToInt32(_context.DungDV.Where(n => n.KhachHangId == id).Select(n => n.DichVu.GiaDV).Sum());
            }
            else
            {
                TTienDV = 0;
            }
            int TTienP = Convert.ToInt32(_context.PhongThue.Where(m => m.KhachHangId == id).Select(m => m.Phong.Giaphong * EntityFunctions.DiffDays(m.NgayDen, m.NgayDi)).Sum());
            Tong = Convert.ToInt32(TTienDV + TTienP);
            var model = new TinhTien
            {
                KhachHang = Kh,
                ThanhTien = Tong,
                Phong = Phong,
                DichVu = DichVu,
            };
            return View(model);
        }
    }
}
