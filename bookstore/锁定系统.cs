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
    public partial class 锁定系统 : Form
    {
        public 锁定系统()
        {
            InitializeComponent();
        }
        public string s;
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataReader sdr;
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_PASSWORDS='" + textBox1.Text.Trim() + "'and USERS_LOGINNAME ='"+ s +"'", conn);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("密码错误", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
            conn.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
        }
    }
}
