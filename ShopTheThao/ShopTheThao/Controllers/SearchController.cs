using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchSanPham(FormCollection s)
        {
            string skey = s["txt_search"].ToString();
            var lstSearch = _dbContext.SanPhams.Where(x => x.SPTen.ToLower().Contains(skey.ToLower()) || x.SPNoiDung.ToLower().Contains(skey.ToLower())).ToList();
            if (lstSearch.Count == 0)
            {
                ViewBag.message = "San pham không ton tai";
                return RedirectToAction("Index", "SanPham");
            }
            ViewBag.message = "Tìm thấy " + lstSearch.Count.ToString() + " Sản Phẩm";
            return View(lstSearch.OrderBy(x => x.SPGiaBan));
        }
    }
}