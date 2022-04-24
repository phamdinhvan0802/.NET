using CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuoiKy.Controllers
{
    public class PhongController : Controller
    {
        private ApplicationDbContext _context;
        public PhongController()
        {
            _context = new ApplicationDbContext(); // tao database de ket noi
        }
        // Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Phong
        public ActionResult Index()
        {
            var Phong = _context.Phong.ToList();
            return View(Phong);
        }
    }
}