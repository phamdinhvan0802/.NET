using CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuoiKy.Controllers
{
    public class DichVuController : Controller
    {
        private ApplicationDbContext _context;
        public DichVuController()
        {
            _context = new ApplicationDbContext(); // tao database de ket noi
        }
        // Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: DichVu
        public ActionResult Index()
        {
            var DV = _context.DichVu.ToList();
            return View(DV);
        }
    }
}