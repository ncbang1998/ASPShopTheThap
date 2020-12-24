using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTheThao.Areas.Admin.Models
{
    public class CategoryModel
    {
        [Key]
        public int LSPMa { get; set; }
        public Nullable<int> TLMa { get; set; }
        public string LSPTen { get; set; }
        public string TLTen { get; set; }
    }
}