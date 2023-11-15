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
            // 配置数据库连接，使用 MySQL 数据库提供程序和连接字符串
            optionsBuilder.UseMySql("Server=localhost;Database=res;User Id=root;Password=448260lklk;");
        }

        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// 增添用户评价：可以不上传用户头像，适用于注册按钮
        /// </summary>
        /// <param name="newReview">要添加的用户评价对象</param>
        public void AddReview(Review newReview)
        {
            // 将新用户评价对象添加到数据库集合
            Reviews.Add(newReview);

            // 保存更改到数据库
            SaveChanges();
        }

    
        /// 仅管理员能使用，删除相应的用户评价
        /// </summary>
        /// <param name="reviewId">要删除的用户评价的ID</param>
        public void DeleteReview(int reviewId)
        {
            // 查找要删除的用户评价
            var reviewToDelete = Reviews.Find(reviewId);

            if (reviewToDelete != null)
            {
                // 从数据库集合中移除用户评价
                Reviews.Remove(reviewToDelete);

                // 保存更改到数据库
                SaveChanges();
            }
        }
    }

}