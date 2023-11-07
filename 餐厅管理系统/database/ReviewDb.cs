﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using 餐厅管理系统.database;

namespace 餐厅管理系统
{
    internal class ReviewDb : DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 使用 MySQL 数据库提供程序和连接字符串
            optionsBuilder.UseMySql("Server=localhost;Database=classes;User Id=root;Password=hf20030819;");
        }
        public DbSet<Review> Reviews { get; set; }

        public void AddUser(Review newReviews)    //增添用户：可以不上传用户头像，注册按钮使用
        {
            
            Reviews.Add(newReviews);
            SaveChanges();
        }

        public void UpdateUser(Review updatedReviews)  //每次用户修改数据时使用，如修改密码，修改昵称
        {
            Reviews.Update(updatedReviews);
            SaveChanges();
        }

        public void DeleteUser(int dishid)  //仅管理员能使用，删除相应的账号
        {

            var studentToDelete = Reviews.Find(dishid);
            if (studentToDelete != null)
            {
                Reviews.Remove(studentToDelete);
                SaveChanges();

            }
        }
    }
}