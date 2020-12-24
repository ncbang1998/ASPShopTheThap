using ShopTheThao.Areas.Admin.comman;
using ShopTheThao.Areas.Admin.Models;
using ShopTheThao.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTheThao.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(AccountModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.LogIn(model.TaiKhoan, model.MatKhau);
                if (result == 1)
                {
                    var user = dao.GetByID(model.TaiKhoan);
                    var userssesion = new UserLogIn();
                    userssesion.TaiKhoan = user.TaiKhoan;
                    Session.Add(Contanst.USER_SSESION, userssesion);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }                            
                else
                {
                    ModelState.AddModelError("", "Đăng nhập sai thông tin");
                }
            }           
            return View("LogIn");
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["TaiKhoan"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}