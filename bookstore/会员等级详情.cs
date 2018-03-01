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
    public partial class 会员等级详情 : Form
    {
        public 会员等级详情()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            this.label1.Text = "不是会员无折扣！";
            this.label2.Text = "会员VIP1打九折！";
            this.label3.Text = "会员VIP2打八折！";
            this.label4.Text = "会员VIP3打七折！";
            this.label5.Text = "会员VIP4打六折！";
            this.label6.Text = "会员VIP5打五折！";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
