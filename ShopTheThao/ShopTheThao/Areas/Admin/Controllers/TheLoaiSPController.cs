using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class TheLoaiSPController : Controller
    {
        // GET: Admin/TheLoaiSP
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            var lsttlsp = _dbContext.TheLoais.Select(x => new TheLoaiModel()
            {                
                TLMa = x.TLMa,            
                TLTen = x.TLTen,
                TLAnh = x.TLAnh
            }).ToList();
            return View(lsttlsp);
        }

        [HttpGet]
        public ActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TheLoaiModel id, HttpPostedFileBase fileUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.TLMa.ToString() == null)
                    {
                        ViewBag.message = "ID danh mục is null";
                        return RedirectToAction("Index", "TheLoaiSP");
                    }
                    var newsp = new TheLoai();
                    newsp.TLMa = id.TLMa;
                    newsp.TLTen = id.TLTen;                        

                    if (id.Image != null)
                    {
                        // lay hinh anh
                        var fileName = System.IO.Path.GetFileName(id.Image.FileName);
                        // LAY tu severs

                        var path = Path.Combine(Server.MapPath("~/image/image_tl/"), fileName);
                        if (System.IO.File.Exists(path))
                        {
                            ViewBag.message = "Image is exited";
                        }
                        else
                        {
                            fileUpload.SaveAs(path);
                        }

                        // gan value image for anhbia
                        newsp.TLAnh = id.Image.FileName;                    
                    }

                    _dbContext.TheLoais.Add(newsp);
                    _dbContext.SaveChanges();
                    if (newsp.TLMa.ToString() != null)
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

            return RedirectToAction("Index", "TheLoaiSP");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _dbContext.TheLoais.FirstOrDefault(x => x.TLMa == id);
            var item = new TheLoaiModel()
            {
                TLMa = data.TLMa,
                TLTen = data.TLTen,
                TLAnh = data.TLAnh
            };         
            return View(item);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(TheLoaiModel model)
        {
            try
            {
                var newsp = _dbContext.TheLoais.FirstOrDefault(x => x.TLMa == model.TLMa);
                if (model.TLMa.ToString() == null)
                {
                    ViewBag.message = "ID danh mục is null";
                    return RedirectToAction("Index", "TheLoaiSP");
                }
                newsp.TLMa = model.TLMa;
                newsp.TLTen = model.TLTen;
                // lay hinh anh
                // Ông phải kiểm tra hình og có upload hog nhen
                // Đầu tiên
                if (model.Image != null)
                {
                    var fileName = System.IO.Path.GetFileName(model.Image.FileName);
                    // LAY tu severs

                    var path = Path.Combine(Server.MapPath("~/image/image_tl/"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.message = "Image is exited";
                    }
                    else
                    {
                        model.Image.SaveAs(path);
                    }

                    // gan value image for anhbia
                    newsp.TLAnh = model.Image.FileName;
                   
                }

                _dbContext.SaveChanges();

                if (newsp.TLMa.ToString() != null)
                {
                    ViewBag.message = "Cập nhật success..";
                }
                ModelState.Clear();

            }
            catch (System.Data.Entity.Validation.DbUnexpectedValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction("Index", "TheLoaiSP");
        }



        [HandleError]
        public ActionResult Delete(int id, TheLoai obj)
        {
            var deletetl = _dbContext.TheLoais.FirstOrDefault(x => x.TLMa == id);
            if (deletetl == null)
            {
                ViewBag.message = "Sản phẩm Không tồn tại";
                return RedirectToAction("Index", "TheLoaiSP");
            }
            else
            {
                _dbContext.TheLoais.Remove(deletetl);
                _dbContext.SaveChanges();
                ViewBag.message = "Thêm danh mục thành Công";
                return RedirectToAction("Index", "TheLoaiSP");
            }
        }

    }
}