using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Admin/Orders
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            var lstdh = from DonHang in _dbContext.DonHangs
                            join kh in _dbContext.KhachHangs on DonHang.KHSdt equals kh.KHSdt                          
                            orderby DonHang.DHTGDatHang descending
                             select new OrdersModel
                             {
                                 DHMa = DonHang.DHMa,
                                 KHSdt = DonHang.KHSdt,
                                 KHHoTen = kh.KHHoTen,
                                 KHDiaChi =kh.KHDiaChi,
                                 KHTinNhan = DonHang.KHTinNhan,
                                 DHNoidung = DonHang.DHNoidung,
                                 DHTGDatHang = DonHang.DHTGDatHang,
                                 
                                 
                             };
            return View(lstdh.ToList());          
        }

    }
}