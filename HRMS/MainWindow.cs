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
       
        static User user = null;
        public MainWindow()
        {
            LoginDialog LD = new LoginDialog();
            Application.Run(LD);
            InitializeComponent();
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
            LoginDialog LD = new LoginDialog();
            LD.ShowDialog();
            this.ShowDialog();
        }
    }
}
