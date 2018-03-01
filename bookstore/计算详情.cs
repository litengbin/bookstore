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
    public partial class 计算详情 : Form
    {
        public 计算详情()
        {
            InitializeComponent();
        }
        public string s;
        private void Form20_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
