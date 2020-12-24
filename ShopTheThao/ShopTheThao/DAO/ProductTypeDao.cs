using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.DAO
{
    public class ProductTypeDao
    {
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();

        public List<LoaiSanPham> Listall()
        {
            return _dbContext.LoaiSanPhams.ToList();
        }
    }
}