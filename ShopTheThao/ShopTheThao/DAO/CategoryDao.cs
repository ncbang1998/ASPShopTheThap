using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.DAO
{
    public class CategoryDao
    {
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();

        public List<TheLoai> Listall()
        {
            return _dbContext.TheLoais.ToList();
        }
    }
}