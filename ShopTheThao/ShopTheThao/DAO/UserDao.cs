using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.DAO
{
    public class UserDao
    {
        private ShopTheThaoEntities _dbContext = new ShopTheThaoEntities();

        public string Insert(Administrator entity)
        {
            _dbContext.Administrators.Add(entity);
            _dbContext.SaveChanges();
            return entity.TaiKhoan;
        }

        public Administrator GetByID(string TaiKhoan)
        {
            return _dbContext.Administrators.SingleOrDefault(x => x.TaiKhoan == TaiKhoan);
        }

        public int LogIn(string TaiKhoan, string MatKhau)
        {
            var result = _dbContext.Administrators.SingleOrDefault(x => x.TaiKhoan == TaiKhoan && x.MatKhau == MatKhau);
            //if(result.TaiKhoan == TaiKhoan && result.MatKhau == MatKhau)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}
            if (result == null)
            {
                return 0;
            }
            else if(result.TaiKhoan != TaiKhoan || result.MatKhau != MatKhau)
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }
    }
}