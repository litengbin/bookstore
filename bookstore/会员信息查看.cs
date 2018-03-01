using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bookstore
{
    public partial class 会员信息查看 : Form
    {
        public 会员信息查看()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        private void Form11_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select VIP_NUMBER as 会员编号, VIP_NAME as 会员姓名, VIP_SEX as 会员性别, VIP_LEVEL as 会员等级 from VIP_INFORMATION", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "VIP_INFORMATION");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
