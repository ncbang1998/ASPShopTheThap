using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class NhaSanXController : Controller
    {
        // GET: Admin/NhaSanX
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();

        public ActionResult Index()
        {
            var lstnsx = _dbContext.NhaSanXuats.Select(x => new NhaSXModel()
            {
                NSXMa = x.NSXMa,
                NSXTen = x.NSXTen,
                NSXThongTin = x.NSXThongTin,
                NSXSdt = x.NSXSdt,
                NSXEmail = x.NSXEmail,
                NSXDiaChi = x.NSXDiaChi
            }).ToList();
            return View(lstnsx);
        }

        [HttpGet]
        public ActionResult Creat()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Creat(NhaSXModel nsx)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (nsx.NSXMa.ToString() == null)
                    {
                        ViewBag.message = "ID nhà sản xuất is null";
                        return View();
                    }

                    var itemDB = _dbContext.NhaSanXuats.FirstOrDefault(x => x.NSXMa == nsx.NSXMa);
                    if (itemDB != null)
                    {
                        ViewBag.message = "Nhà sản xuất tồn tại";
                        return View();
                    }
                    var obj = new NhaSanXuat();
                    obj.NSXMa = nsx.NSXMa;
                    obj.NSXTen = nsx.NSXTen;
                    obj.NSXSdt = nsx.NSXSdt;
                    obj.NSXEmail = nsx.NSXEmail;
                    obj.NSXDiaChi = nsx.NSXDiaChi;
                    obj.NSXThongTin = nsx.NSXThongTin;

                    _dbContext.NhaSanXuats.Add(obj);

                    _dbContext.SaveChanges();

                    if (obj.NSXMa.ToString() != null)
                    {
                        ViewBag.message = "Insert success..";
                    }
                    ModelState.Clear();
                }
               
            }
            catch (System.Data.Entity.Validation.DbUnexpectedValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Index", "NhaSanX");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _dbContext.NhaSanXuats.FirstOrDefault(x => x.NSXMa == id);
            var item = new NhaSXModel()
            {
                NSXMa = data.NSXMa,
                NSXTen = data.NSXTen,
                NSXSdt = data.NSXSdt,
                NSXThongTin = data.NSXThongTin,
                NSXDiaChi = data.NSXDiaChi,
                NSXEmail = data.NSXEmail
            };
            
            return View(item);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NhaSXModel nsx)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (nsx.NSXMa.ToString() == null)
                    {
                        ViewBag.message = "ID nhà sản xuất is null";
                        return View();
                    }

                    var itemDB = _dbContext.NhaSanXuats.FirstOrDefault(x => x.NSXMa == nsx.NSXMa);

                    itemDB.NSXMa = nsx.NSXMa;
                    itemDB.NSXTen = nsx.NSXTen;
                    itemDB.NSXSdt = nsx.NSXSdt;
                    itemDB.NSXEmail = nsx.NSXEmail;
                    itemDB.NSXDiaChi = nsx.NSXDiaChi;
                    itemDB.NSXThongTin = nsx.NSXThongTin;

                    _dbContext.SaveChanges();

                    ModelState.Clear();
                }
                
            }
            catch (System.Data.Entity.Validation.DbUnexpectedValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
            ViewBag.message = "Edit nhà sản xuất success..";
            return RedirectToAction("Index", "NhaSanX");

        }

        [HandleError]
        public ActionResult Delete(int id, NhaSanXuat obj)
        {
            var deletelnsx = _dbContext.NhaSanXuats.FirstOrDefault(x => x.NSXMa == id);
            if (deletelnsx == null)
            {
                ViewBag.message = "Nhà sản xuất Không tồn tại";
                return RedirectToAction("Index", "NhaSanX");
            }
            else
            {
                _dbContext.NhaSanXuats.Remove(deletelnsx);
                _dbContext.SaveChanges();
                ViewBag.message = "Xoá nhà sản xuất thành Công";
                return RedirectToAction("Index", "NhaSanX");
            }
        }
    }
}