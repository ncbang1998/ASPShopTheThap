using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Custumer
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            var lstkh = _dbContext.KhachHangs.Select(x => new CustumerModel()
            {
                KHSdt = x.KHSdt,
                KHHoTen = x.KHHoTen,
                KHDiaChi = x.KHDiaChi,
                KHEmail = x.KHEmail
            }).ToList();
            return View(lstkh);

        }
    }
}