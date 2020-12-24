using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.DAO
{
    public class Carts
    {
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();
        public string strIdSP { get; set; }
        public string strNameSP { get; set; }
        public string strImageSP { get; set; }
        public int iQuanlitySP { get; set; }
        public double dPriceSP { get; set; }
        public double dAmount { get { return iQuanlitySP * dPriceSP; } }

        //xd hàm khởi tạo cho giỏ hàng
        public Carts(string idSP)
        {
            strIdSP = idSP;
            SanPham sp = _dbContext.SanPhams.Single(n => n.SPMa == strIdSP);
            strNameSP = sp.SPTen;
            strImageSP = sp.SPAnh;
            dPriceSP = double.Parse(sp.SPGiaBan.ToString());
            iQuanlitySP = 1; //khi nhấn vào nút mua hàng khởi tạo số lượng = 1
        }
    }
}