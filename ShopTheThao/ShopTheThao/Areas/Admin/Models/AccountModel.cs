using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTheThao.Areas.Admin.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Mời nhập user name")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Mời nhập password")]
        public string MatKhau { get; set; }
    }
}