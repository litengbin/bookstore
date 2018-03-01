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
    public partial class 用户信息查看 : Form
    {
        public 用户信息查看()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        private void Form24_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select USERS_NUMBER as 用户编号, USERS_NAME as 用户姓名, USERS_SEX as 用户性别, USERS_LOGINNAME as 登录名, USERS_PASSWORDS as 密码,USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "USERS_INFORMATION");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
