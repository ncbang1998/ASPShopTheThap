using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.DAO
{
    public class NSXDao
    {
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();

        public List<NhaSanXuat> Listall()
        {
            return _dbContext.NhaSanXuats.ToList();
        }
    }
}