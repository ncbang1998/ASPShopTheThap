using ShopTheThao.DAO;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Controllers
{
    public class GioHangController : Controller
    {
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        // GET: GioHang

        // get cart
        public List<Carts> GetCartsSP()
        {
            List<Carts> lstCarts = Session["Carts"] as List<Carts>;
            // ktra carts
            if (lstCarts == null)
            {
                lstCarts = new List<Carts>();
                Session["Carts"] = lstCarts;
            }
            return lstCarts;
        }

        // View Cart
        public ActionResult ViewCarts()
        {
            // ktr session
            if (Session["Carts"] == null)
            {
                return RedirectToAction("Index", "SanPham");
            }
            List<Carts> lstCarts = GetCartsSP();
            return View(lstCarts);
        }

        // add cart
        public ActionResult AddCarts(string idSP)
        {
            // ktra book ton tai?
            var checkExistedSP = _dbContext.SanPhams.FirstOrDefault(x => x.SPMa == idSP);
            if (checkExistedSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            // khoi tao carts
            List<Carts> lstCarts = GetCartsSP();

            // ktra book dc mua da co chua?
            Carts sp = lstCarts.FirstOrDefault(x => x.strIdSP == idSP);
            if (sp == null)
            {
                sp = new Carts(idSP);
                lstCarts.Add(sp);
                return RedirectToAction("ViewCarts", "GioHang");
            }
            else
            {
                sp.iQuanlitySP++;
                return RedirectToAction("ViewCarts", "GioHang");
            }
        }

        public ActionResult SuaSoLuong(string idSP, int soluongmoi)
        {
            // tìm carditem muon sua
            List<Carts> giohang = Session["Carts"] as List<Carts>;
            Carts itemSua = giohang.FirstOrDefault(m => m.strIdSP.Equals(idSP));
            if (itemSua != null)
            {
                if (soluongmoi < 1 || soluongmoi > 100)
                {

                }
                else
                {
                    @ViewBag.GioError = "";
                    itemSua.iQuanlitySP = soluongmoi;
                }
            }
            return RedirectToAction("ViewCarts", "GioHang");

        }
        //Xoá khỏi giỏ
        public ActionResult XoaKhoiGio(string idSP)
        {
            List<Carts> giohang = Session["Carts"] as List<Carts>;
            Carts itemXoa = giohang.FirstOrDefault(m => m.strIdSP.Equals(idSP));
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("ViewCarts", "GioHang");
        }
    }
}