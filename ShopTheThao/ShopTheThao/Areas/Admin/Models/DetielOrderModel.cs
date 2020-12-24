using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.Areas.Admin.Models
{
    public class DetielOrderModel
    {
        public int DHMa { get; set; }
        public string SPMa { get; set; }
        public Nullable<int> CTDHSoLuong { get; set; }
        public string CTDHThanhTien { get; set; }
        public string SPTen { get; set; }        
        public string SPGiaBan { get; set; }

    }
}