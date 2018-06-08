using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HRMS
{
    public partial class MainWindow : Form
    {
        User user = new User("-1","","");
        public void studentinit()//学生界面初始化
        {
            资料查询ToolStripMenuItem.Enabled = false;
        }
        public void teacherinit()//教师界面初始化
        {
            资料查询ToolStripMenuItem.Enabled = true;
        }
        public MainWindow()
        {
            LoginDialog LD = new LoginDialog(user);
            Application.Run(LD);
            if (user.getid() .Equals("-1"))
                this.Close();
            InitializeComponent();
            toolStripStatusLabel1.Text = "当前用户:" + user.getname();
        }
       private void 资料查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StuffForm SF = new StuffForm();
            SF.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            user = new User("-1", "", "");
            LoginDialog LD = new LoginDialog(user);
            LD.ShowDialog();
            if (user.getid().Equals("-1"))
                this.Close();
            toolStripStatusLabel1.Text = "当前用户:" + user.getname();
            if(user.getposition()=="Student")
                studentinit();
            this.Show();
            
        }
    }
}
