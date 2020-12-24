using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.DAO;
using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();

        public ActionResult Index()
        {
            var lstProduct = from sanpham in _dbContext.SanPhams
                           join LSP in _dbContext.LoaiSanPhams on sanpham.LSPMa equals LSP.LSPMa
                           join NSX in _dbContext.NhaSanXuats on sanpham.NSXMa equals NSX.NSXMa                        
                           orderby sanpham.SPNgayUpdate descending
                           select new ProductModel
                           {
                               SPMa = sanpham.SPMa,
                               SPTen = sanpham.SPTen,
                               SPGiaBan = sanpham.SPGiaBan,
                               SPAnh = sanpham.SPAnh,
                               SPSize = sanpham.SPSize,
                               SPNoiDung = sanpham.SPNoiDung,
                               SPNgayUpdate = sanpham.SPNgayUpdate,
                               SPGIamGia = sanpham.SPGIamGia,
                               LSPMa = sanpham.LSPMa,
                               LSPTen = LSP.LSPTen,
                               NSXMa = sanpham.NSXMa,
                               NSXTen = NSX.NSXTen
                           };
            return View(lstProduct.ToList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag1();
            SetViewBag();
            return View();          
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductModel id, HttpPostedFileBase fileUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.SPMa == null)
                    {
                        ViewBag.message = "ID sản phẩm is null";
                        return RedirectToAction("Index", "Products");
                    }
                    var newsp = new SanPham();
                    newsp.SPMa = id.SPMa;
                    newsp.SPTen = id.SPTen;
                    newsp.LSPMa = id.LSPMa;
                    newsp.NSXMa = id.NSXMa;
                    newsp.SPSize = id.SPSize;
                    newsp.SPGiaBan = id.SPGiaBan;
                    newsp.SPGIamGia = id.SPGIamGia;
                    newsp.SPNoiDung = id.SPNoiDung;
                    newsp.SPNgayUpdate = id.SPNgayUpdate;

                    if (id.Image != null)
                    {
                        // lay hinh anh
                        var fileName = System.IO.Path.GetFileName(id.Image.FileName);
                        // LAY tu severs

                        var path = Path.Combine(Server.MapPath("~/image/image_sp/"), fileName);
                        if (System.IO.File.Exists(path))
                        {
                            ViewBag.message = "Image is exited";
                        }
                        else
                        {
                            fileUpload.SaveAs(path);
                        }

                        // gan value image for anhbia
                        newsp.SPAnh = id.Image.FileName;
                        SetViewBag1();
                        SetViewBag();
                    }
                        
                    _dbContext.SanPhams.Add(newsp);
                    _dbContext.SaveChanges();
                    if (newsp.SPMa != null)
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
            
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var data = _dbContext.SanPhams.FirstOrDefault(x => x.SPMa == id);
            var item = new ProductModel()
            {
                SPMa = data.SPMa,
                SPTen = data.SPTen,
                NSXMa = data.NSXMa,
                LSPMa = data.LSPMa,
                SPGiaBan = data.SPGiaBan,
                SPSize = data.SPSize,
                SPGIamGia = data.SPGIamGia,
                SPAnh = data.SPAnh,
                SPNoiDung = data.SPNoiDung,
                SPNgayUpdate = data.SPNgayUpdate
            };
            SetViewBag();
            SetViewBag1();
            return View(item);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            try
            {                               
                    var newsp = _dbContext.SanPhams.FirstOrDefault(x => x.SPMa == model.SPMa);
                    if (model.SPMa == null)
                    {
                        ViewBag.message = "ID sản phẩm is null";
                        return RedirectToAction("Index", "Products");
                    }                                
                    newsp.SPTen = model.SPTen;
                    newsp.LSPMa = model.LSPMa;
                    newsp.NSXMa = model.NSXMa;
                    newsp.SPSize = model.SPSize;
                    newsp.SPGiaBan = model.SPGiaBan;
                    newsp.SPGIamGia = model.SPGIamGia;
                    newsp.SPNoiDung = model.SPNoiDung;
                    newsp.SPNgayUpdate = model.SPNgayUpdate;


                    // lay hinh anh
                    // Ông phải kiểm tra hình og có upload hog nhen
                    // Đầu tiên
                    if(model.Image != null)
                {
                    var fileName = System.IO.Path.GetFileName(model.Image.FileName);
                    // LAY tu severs

                    var path = Path.Combine(Server.MapPath("~/image/image_sp/"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.message = "Image is exited";
                    }
                    else
                    {
                        model.Image.SaveAs(path);
                    }

                    // gan value image for anhbia
                    newsp.SPAnh = model.Image.FileName;
                    SetViewBag1();
                    SetViewBag();
                }

                   
                    _dbContext.SaveChanges();

                    if (newsp.SPMa != null)
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

            return RedirectToAction("Index", "Products");
        }



        [HandleError]
        public ActionResult Delete(string id, SanPham obj)
        {
            var deletesp = _dbContext.SanPhams.FirstOrDefault(x => x.SPMa == id);
            if (deletesp == null)
            {
                ViewBag.message = "Sản phẩm Không tồn tại";
                return RedirectToAction("Index", "Products");
            }
            else
            {

                
                _dbContext.SanPhams.Remove(deletesp);
                _dbContext.SaveChanges();
                ViewBag.message = "Thêm sản phẩm thành Công";
                return RedirectToAction("Index", "Products");
            }
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new ProductTypeDao();
            ViewBag.LSPMa = new SelectList(dao.Listall(), "LSPMa", "LSPTen", selectedID);
        }

        public void SetViewBag1(int? selectedID = null)
        {
            var dao = new NSXDao();
            ViewBag.NSXMa = new SelectList(dao.Listall(), "NSXMa", "NSXTen", selectedID);
        }

        public ActionResult Searchproduct(FormCollection s)
        {
            string skey = s["txt_search"].ToString();
            var lstSearch = _dbContext.SanPhams.Where(x => x.SPTen.ToLower().Contains(skey.ToLower()) || x.SPNoiDung.ToLower().Contains(skey.ToLower())).ToList();
            if (lstSearch.Count == 0)
            {
                ViewBag.message = "Sản phẩm không tồn tại";
                return RedirectToAction("Index", "Products");
            }
            ViewBag.message = "Tìm thấy " + lstSearch.Count.ToString() + " sản phẩm";
            return View(lstSearch.OrderBy(x => x.SPNgayUpdate));
        }

    }
}