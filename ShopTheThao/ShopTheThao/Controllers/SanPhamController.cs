using PagedList;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Controllers
{
    public class SanPhamController : Controller
    {
        ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        // GET: SanPham
        public ActionResult Index(int? page)
        {
            //so sach tren trang
            int pageSize = 12;
            //so trang
            int pageNumber = (page ?? 1);
            var LstAllSanPham = _dbContext.SanPhams.OrderByDescending(x => x.SPNgayUpdate).ToList();
            var LsAllSanPham = _dbContext.SanPhams.OrderByDescending(x => x.SPNgayUpdate).ToPagedList(pageNumber, pageSize);
            if (LsAllSanPham.Count > 0)
            {
                ViewBag.message = "Tổng sản phẩm: " + LsAllSanPham.Count.ToString();
            }
            return View(LsAllSanPham);

        }

        public ActionResult DetailSanPham(string idSP)
        {

            var detailsanpham = _dbContext.SanPhams.SingleOrDefault(x => x.SPMa == idSP);
            if (detailsanpham == null)
            {
                ViewBag.message = "Sản phẩm chưa có thông tin chi tiết....";
                return RedirectToAction("Index", "SanPham");
            }
            return View(detailsanpham);
        }


        public ActionResult SanPhamTheoLoai(int idSPLoai)
        {
            //check topic exit?
            var lsanpham = _dbContext.LoaiSanPhams.FirstOrDefault(x => x.LSPMa == idSPLoai);
            if (lsanpham == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("Index", "SanPham");
            }
            var lstloaiSP = _dbContext.SanPhams.Where(x => x.LSPMa == idSPLoai).OrderByDescending(x => x.SPGiaBan).ToList();
            if (lstloaiSP.Count > 0)
            {
                ViewBag.message = "Tổng sản phẩm: " + lstloaiSP.Count.ToString();
            }
            if (lstloaiSP.Count == 0)
            {
                ViewBag.message = "Sản phẩm hiện chưa mở bán";
            }
            return View(lstloaiSP);
        }


        public ActionResult SanPhamTheoNSX(int idNhasx)
        {
            //check topic exit?
            var lsanpham = _dbContext.NhaSanXuats.FirstOrDefault(x => x.NSXMa == idNhasx);
            if (lsanpham == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("Index", "SanPham");
            }
            var lstnhasx = _dbContext.SanPhams.Where(x => x.NSXMa == idNhasx).OrderByDescending(x => x.SPGiaBan).ToList();
            if (lstnhasx.Count > 0)
            {
                ViewBag.message = "Tổng sản phẩm: " + lstnhasx.Count.ToString();
            }
            if (lstnhasx.Count == 0)
            {
                ViewBag.message = "Sản phẩm hiện chưa mở bán";
            }
            return View(lstnhasx);
        }
    }
}