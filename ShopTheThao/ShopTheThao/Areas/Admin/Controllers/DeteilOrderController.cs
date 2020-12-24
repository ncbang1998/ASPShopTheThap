using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class DeteilOrderController : Controller
    {
        // GET: Admin/DeteilOrder
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            var lstctdh = from ctDonHang in _dbContext.CTDonHangs
                        join sp in _dbContext.SanPhams on ctDonHang.SPMa equals sp.SPMa
                        orderby ctDonHang.DHMa descending
                        select new DetielOrderModel
                        {
                            DHMa = ctDonHang.DHMa,
                            SPMa = ctDonHang.SPMa,
                            SPTen = sp.SPTen,                        
                            CTDHSoLuong =ctDonHang.CTDHSoLuong,
                            SPGiaBan= sp.SPGiaBan,
                            CTDHThanhTien = ctDonHang.CTDHThanhTien

                        };
            return View(lstctdh.ToList());
        }
    }
}