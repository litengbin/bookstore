using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bookstore
{
    public partial class 主界面 : Form
    {
        public 主界面()
        {
            InitializeComponent();
        }
        public string authorization;
        public string name;
        public string time;
        private void Form2_Load(object sender, EventArgs e)
        {
            switch (this.authorization)
            {
                case "1": toolStripStatusLabel4.Text = "管理人员"; break;
                case "2": toolStripStatusLabel4.Text = "销售人员"; break;
            }
            toolStripStatusLabel2.Text = name;
            toolStripStatusLabel6.Text = time;
            if (this.authorization == "2")
            {
                图书入库管理ToolStripMenuItem.Enabled = false;
                用户管理ToolStripMenuItem.Enabled = false;
                系统管理ToolStripMenuItem.Enabled = false;
            }
            系统备份ToolStripMenuItem.Enabled = true;
            系统恢复ToolStripMenuItem.Enabled = false;
        }

        private void 增加图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图书信息添加 frm4 = new 图书信息添加();
            frm4.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {

                Application.Exit();
            }
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            关于 frm3 = new 关于();
            frm3.ShowDialog();
        }

        private void 更改图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图书信息更改 frm5 = new 图书信息更改();
            frm5.ShowDialog();
        }

        private void 删除图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图书信息删除 frm6 = new 图书信息删除();
            frm6.ShowDialog();
        }

        private void 显示图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图书信息查看 frm7 = new 图书信息查看();
            frm7.ShowDialog();
        }

        private void 会员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            会员添加 frm9 = new 会员添加();
            frm9.ShowDialog();
        }

        private void 会员信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            会员删除 frm10 = new 会员删除();
            frm10.ShowDialog();
        }

        private void 会员信息ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            会员信息查看 frm11 = new 会员信息查看();
            frm11.ShowDialog();
        }

        private void 权限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            权限设置 frm12 = new 权限设置();
            frm12.n = name;
            frm12.ShowDialog();
            if (frm12.symbol == true)
            {
                this.Hide();
                登录 frm1 = new 登录();
                frm1.ShowDialog();
            }
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            更改密码 frm13 = new 更改密码();
            frm13.s = name;
            frm13.ShowDialog();
        }

        private void 锁定系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            锁定系统 frm14 = new 锁定系统();
            frm14.s = name;
            frm14.ShowDialog();
        }

        private void 系统备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            系统备份 frm15 = new 系统备份();
            frm15.ShowDialog();
        }

        private void 系统恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            系统恢复 frm16 = new 系统恢复();
            frm16.ShowDialog();
        }

        private void 图书销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            销售图书 frm17 = new 销售图书();
            frm17.ShowDialog();
        }

        private void 会员查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            会员查询 frm18 = new 会员查询();
            frm18.ShowDialog();
        }

        private void 销售列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            销售统计 frm21 = new 销售统计();
            frm21.ShowDialog();
        }

        private void 图书入库管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 书店会员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 图书查询统计ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            图书查询 frm8 = new 图书查询();
            frm8.ShowDialog();
        }

        private void 用户注册ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            用户注册 frm22 = new 用户注册();
            frm22.ShowDialog();
        }

        private void 用户删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            用户删除 frm23 = new 用户删除();
            frm23.ShowDialog();
        }

        private void 用户查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            用户信息查看 frm24 = new 用户信息查看();
            frm24.ShowDialog();
        }

        private void 维护入库图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 用户查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户查询 frm26 = new 用户查询();
            frm26.ShowDialog();
        }

        private void 会员更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            会员更改 frm27 = new 会员更改();
            frm27.ShowDialog();
        }

        private void 用户更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户更改 frm28 = new 用户更改();
            frm28.ShowDialog();
        }
    }
}
