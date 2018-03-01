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
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
            skinEngine1.SkinFile = "MP10.ssk";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection conn = CONN.Myconn();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_LOGINNAME='" + t1 + "' and USERS_PASSWORDS='" + t2 + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.Hide();
                    主界面 frm2 = new 主界面();
                    frm2.authorization = sdr["USERS_AUTHORIZATIONS"].ToString().Trim();
                    frm2.name = t1;
                    frm2.time = DateTime.Now.ToLongDateString() + " " + DateTime.Now.DayOfWeek;
                    frm2.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox2.Text = "";
                    this.textBox2.Focus();
                }

            }
            else
            {
                MessageBox.Show("用户名或密码不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
