using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.Areas.Admin.Models
{
    public class TheLoaiModel
    {
        public int TLMa { get; set; }

        public string TLTen { get; set; }

        public string TLAnh { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}