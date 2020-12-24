using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTheThao.Areas.Admin.Models
{
    public class ProductModel
    {
        [Key]
        public string SPMa { get; set; }
        public Nullable<int> NSXMa { get; set; }
        public Nullable<int> LSPMa { get; set; }
        public string SPTen { get; set; }
        public string SPSize { get; set; }
        public string SPGiaBan { get; set; }
        public Nullable<int> SPGIamGia { get; set; }
        public string SPAnh { get; set; }
        [StringLength(50)]
        public string SPNgayUpdate { get; set; }
        [DataType(DataType.Html)]
        public string SPNoiDung { get; set; }
        public string NSXTen { get; set; }
        public string LSPTen { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}