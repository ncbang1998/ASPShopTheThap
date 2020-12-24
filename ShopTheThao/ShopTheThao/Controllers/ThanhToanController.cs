using ShopTheThao.DAO;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult ViewCarts()
        {
            List<Carts> giohang = Session["Carts"] as List<Carts>;
            return View(giohang);
        }

        [HttpPost]
        public ActionResult StepEnd()
        {
            //Nhận reqest từ trang index
            string phone = Request.Form["phone"];
            string fullname = Request.Form["fullname"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];
            //kiểm tra xem có customer chưa và cập nhật lại
            KhachHang newCus = new KhachHang();
            var cus = _dbContext.KhachHangs.FirstOrDefault(p => p.KHSdt.Equals(phone));
            if (cus != null)
            {
                //nếu có số điện thoại trong db rồi
                //cập nhật thông tin và lưu
                cus.KHHoTen = fullname;
                cus.KHEmail = email;
                cus.KHDiaChi = address;
                _dbContext.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                //nếu chưa có sđt trong db
                //thêm thông tin và lưu
                newCus.KHSdt = phone;
                newCus.KHHoTen = fullname;
                newCus.KHEmail = email;
                newCus.KHDiaChi = address;
                _dbContext.KhachHangs.Add(newCus);
                _dbContext.SaveChanges();
            }
            //Thêm thông tin vào order và orderdetail
            List<Carts> giohang = Session["Carts"] as List<Carts>;
            //thêm order mới
            DonHang newOrder = new DonHang();
            var newIDOrder = _dbContext.DonHangs.OrderByDescending(x => x.DHTGDatHang);        
            newOrder.KHSdt = phone;
            newOrder.KHTinNhan = note;
            newOrder.DHTGDatHang = DateTime.Now.ToString();          
            _dbContext.DonHangs.Add(newOrder);
            _dbContext.SaveChanges();
            //thêm details
            for (int i = 0; i < giohang.Count; i++)
            {
                CTDonHang newOrdts = new CTDonHang();
                newOrdts.DHMa = newOrder.DHMa;
                newOrdts.SPMa = giohang.ElementAtOrDefault(i).strIdSP;
                newOrdts.CTDHSoLuong = giohang.ElementAtOrDefault(i).iQuanlitySP;
                newOrdts.CTDHThanhTien = giohang.ElementAtOrDefault(i).dAmount.ToString();
                _dbContext.CTDonHangs.Add(newOrdts);
                _dbContext.SaveChanges();
            }
            Session["MHD"] = "HD" + newIDOrder;
            Session["Phone"] = phone;
            //xoá sạch giỏ hàng
            giohang.Clear();
            return RedirectToAction("HoaDon", "ThanhToan");
        }
        
        public ActionResult HoaDon()
        {
            return View();
        }
    }
}