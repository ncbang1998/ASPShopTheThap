using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialLoaiSanPham()
        {
            var loaisanpham = _dbContext.LoaiSanPhams.OrderBy(x => x.LSPTen).ToList();
            return PartialView(loaisanpham);
        }
    }
}