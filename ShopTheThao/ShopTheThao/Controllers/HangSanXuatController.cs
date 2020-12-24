using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Controllers
{
    public class HangSanXuatController : Controller
    {
        // GET: HangSanXuat
        ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHangSX()
        {
            var hangsx = _dbContext.NhaSanXuats.OrderBy(x => x.NSXTen).ToList();
            return PartialView(hangsx);
        }
    }
}