﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 餐厅管理系统.database;

namespace 餐厅管理系统
{
    public partial class FormResRegister : Form
    {
        // 标记是否上传图片
        bool isUpLoadPicture;

        // 上传的图片的后缀名
        string empUpLoadPictureFormat;

        // OpenFileDialog 控件，用于选择上传的图片文件
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        // 数据库操作对象，用于将餐厅信息保存到数据库
        ApplyDb db = new ApplyDb();

        public FormResRegister()
        {
            InitializeComponent();
        }

        private void FormResRegister_Load(object sender, EventArgs e)
        {
            // 在窗体加载时执行的代码（可留空）
        }

     

        // 上传图片按钮点击事件
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                // 设置文件过滤器，只允许选择特定格式的图片
                openFileDialog1.Filter = "*.jpg|*.jpg|*.png|*.png|*.bmp|*.bmp|*.tiff|*.tiff";

                // 如果用户点击了"确定"按钮
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    isUpLoadPicture = true; // 记录已上传图片，用于保存操作
                    try
                    {
                        string uploadpicture;
                        uploadpicture = openFileDialog1.FileName; // 图片的物理路径
                        String[] empImageData = uploadpicture.Split('.'); // 获取文件类型
                        empUpLoadPictureFormat = empImageData[1]; // 上传的图片的后缀名
                        pictureBox2.Image = Image.FromFile(uploadpicture); // 将图片显示在 PictureBox 控件中
                    }
                    catch
                    {
                        MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("上传相片出错: " + ex.Message);
            }
        }


        // 保存按钮点击事件，用于保存餐厅信息到数据库
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前应用程序的上级目录，用于保存图片
                DirectoryInfo pname = new DirectoryInfo(Application.StartupPath);
                string filename = pname.Parent.Parent.FullName;

                // 如果上传了图片
                if (isUpLoadPicture)
                {
                    // 设置餐厅图片的名字
                    string resImageName = textBox1.Text + "商家图片." + empUpLoadPictureFormat;

                    // 将上传的图片复制到指定目录
                    File.Copy(openFileDialog1.FileName, filename + "\\image\\restaurantimage\\" + resImageName);

                    // 创建餐厅对象并设置属性
                    Restaurant restaurant = new Restaurant();
                    restaurant.Name = textBox1.Text;
                    restaurant.account = textBox4.Text;
                    restaurant.Password = textBox2.Text;
                    restaurant.Address = textBox3.Text;
                    restaurant.ResPicture = resImageName;

                    // 将餐厅信息添加到数据库
                    db.AddResapply(restaurant);

                    // 显示申请已提交消息
                    MessageBox.Show("申请已提交，请耐心等待");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存餐厅信息时发生错误: {ex.Message}");
            }
        }

        // 返回登录界面按钮点击事件
        private void button3_Click_1(object sender, EventArgs e)
        {
            // 隐藏当前窗体并显示登录窗体
            this.Hide();
            FormLogin form = new FormLogin();
            form.Show();
        }

        private void FormResRegister_Load_1(object sender, EventArgs e)
        {

        }
    }

}
