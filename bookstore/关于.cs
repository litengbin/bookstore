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
    public partial class 关于 : Form
    {
        public 关于()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label4.Text = "开发人员：李腾彬";
            label5.Text = "书店销售系统为李腾彬所有";
            label6.Text = "不可用于商业用途";
            label7.Text = "否则追究法律责任";   
        }
    }
}
