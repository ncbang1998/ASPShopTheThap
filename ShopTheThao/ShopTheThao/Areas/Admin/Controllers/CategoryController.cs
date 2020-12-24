using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.DAO;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public ActionResult Index()
        {
            var lstLSanPham = _dbContext.LoaiSanPhams.Select(x => new CategoryModel()
            {
                LSPMa = x.LSPMa,
                TLMa = x.TLMa,
                LSPTen = x.LSPTen,
                TLTen = x.TheLoai.TLTen
            }).ToList();
            return View(lstLSanPham);
        }

        [HttpGet]
        public ActionResult CreatLoaiSP()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatLoaiSP(CategoryModel LSP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (LSP.LSPMa.ToString() == null)
                    {
                        ViewBag.message = "ID Loai San Pham is null";
                        return View();
                    }

                    var itemDB = _dbContext.LoaiSanPhams.FirstOrDefault(x => x.LSPMa == LSP.LSPMa);
                    if (itemDB != null)
                    {
                        ViewBag.message = "Loại sản phẩm tồn tại";
                        return View();
                    }
                    var obj = new LoaiSanPham();
                    obj.LSPMa = LSP.LSPMa;
                    obj.TLMa = LSP.TLMa;
                    obj.LSPTen = LSP.LSPTen;                   
                   

                    _dbContext.LoaiSanPhams.Add(obj);

                    _dbContext.SaveChanges();

                    if (obj.LSPMa.ToString() != null)
                    {
                        ViewBag.message = "Insert success..";
                    }
                    ModelState.Clear();
                }
                SetViewBag();
            }
            catch (System.Data.Entity.Validation.DbUnexpectedValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Index", "Category");

        }

        [HttpGet]
        public ActionResult EditLSP(int id)
        {
            var data = _dbContext.LoaiSanPhams.FirstOrDefault(x => x.LSPMa == id);
            var item = new CategoryModel()
            {
                LSPMa = data.LSPMa,
                TLMa = data.TLMa,
                LSPTen = data.LSPTen
            };
            SetViewBag();
            return View(item);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditLSP(CategoryModel LSP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (LSP.LSPMa.ToString() == null)
                    {
                        ViewBag.message = "ID Loai San Pham is null";
                        return View();
                    }

                    var itemDB = _dbContext.LoaiSanPhams.FirstOrDefault(x => x.LSPMa == LSP.LSPMa);

                    itemDB.LSPMa = LSP.LSPMa;
                    itemDB.TLMa = LSP.TLMa;
                    itemDB.LSPTen = LSP.LSPTen;
                 
                    _dbContext.SaveChanges();                 
                                  
                    ModelState.Clear();
                }
                SetViewBag();
            }
            catch (System.Data.Entity.Validation.DbUnexpectedValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
                ViewBag.message = "Edit Loại sản phẩm success..";   
            return RedirectToAction("Index", "Category");

        }

        [HandleError]
        public ActionResult DeleteLSP(int id, LoaiSanPham obj)
        {
            var deletelsp = _dbContext.LoaiSanPhams.FirstOrDefault(x => x.LSPMa == id);
            if (deletelsp == null)
            {
                ViewBag.message = "Loại sản phẩm Không tồn tại";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                _dbContext.LoaiSanPhams.Remove(deletelsp);
                _dbContext.SaveChanges();
                ViewBag.message = "Thêm Loại sản phẩm thành Công";
                return RedirectToAction("Index", "Category");
            }      
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.TLMa = new SelectList(dao.Listall(), "TLMa", "TLTen", selectedID);
        }

    }
}