﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HRMS
{
    public partial class LoginDialog : Form
    {
        User user = new User();
        public LoginDialog(User user)
        {
            this.user = user;
            InitializeComponent();
            linkLabel1.BackColor = Color.Transparent;
            //this.ControlBox = false;//取消右上角关闭按钮显示
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                /*string ConStr = "server=DESKTOP-V752EIN;database=" + "HRMS" + ";uid=16211160112;pwd=16211160112";
                //创建SqlConnection对象
                conn = new SqlConnection(ConStr);
                conn.Open();//打开连接*/
                SqlConnection conn = DBAccess.GetConnection();
                if (conn.State == ConnectionState.Open)//判断当前连接的状态
                {
                    //显示状态信息
                    SqlCommand sqlCommand = conn.CreateCommand();
                    //String SQLstr = "select * from dbo.tb_Login where Name='16211160112' and Password='16211160112'";
                    String SQLstr = "select ID ,Name, Position from dbo.tb_Login where ID='" + nameTextBox.Text + "' and Password='" + codeTextBox.Text + "';";
                    sqlCommand.CommandText = SQLstr;
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    bool bReader = dataReader.Read();
                    if (bReader)
                    {
                        string Position = dataReader.GetString(2).ToString();
                        string Name = dataReader.GetString(1).ToString();
                        string Id= dataReader.GetString(0).ToString();
                        MessageBox.Show("登录成功！\n当前用户姓名："+Name+"\n您的身份为："+Position, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        user.SetUser(Id, Name, Position);
                        conn.Close();
                        conn.Dispose();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("连接数据库失败");//出现异常弹出提示
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Resetpsw rst = new Resetpsw();
            rst.ShowDialog();
            
        }
        /* private void cancleButton_Click(object sender, EventArgs e)
{
    Application.Exit();
}*/
    }
}