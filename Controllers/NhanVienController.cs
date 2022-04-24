using CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuoiKy.Controllers
{
    public class NhanVienController : Controller
    {
        private ApplicationDbContext _context;
        public NhanVienController()
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
            var searchNV = _context.NhanVien.ToList();
            if (!String.IsNullOrEmpty(Search))
            {
                searchNV = searchNV.Where(c => c.HotenNV.ToLower().Contains(Search)).ToList();
            }
            return View(searchNV);
        }
        public ActionResult detailsnv(int id) // trang chi tiết
        {
            var detailsNV = _context.NhanVien.SingleOrDefault(c => c.Id == id);// trả về 1 đối tượng khách hàng có id trùng với tham số
            return View(detailsNV);
        }
        public ActionResult edit(int id)
        {
            var editNVv = _context.NhanVien.SingleOrDefault(c => c.Id == id); // hiện trang edit theo id kh
            return View("edit", editNVv);
        }
        public ActionResult editnv(NhanVien nv)
        {
            var editNV = _context.NhanVien.SingleOrDefault(c => c.Id == nv.Id);
            editNV.HotenNV = nv.HotenNV;
            editNV.NgaySinh = nv.NgaySinh;
            editNV.Gioitinh = nv.Gioitinh;
            editNV.CMND = nv.CMND;
            editNV.SDT = nv.SDT;
            editNV.Matkhau = nv.Matkhau;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult deletenv(int id)
        {
            var deleteNVs = _context.NhanVien.SingleOrDefault(c => c.Id == id);
            _context.NhanVien.Remove(deleteNVs);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult addnv()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addnv(NhanVien NV)
        {
            _context.NhanVien.Add(NV);
            _context.SaveChanges();// update db
            return RedirectToAction("Index");
        }
    }
}