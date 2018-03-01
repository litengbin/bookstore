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
    public partial class 更改密码 : Form
    {
        public 更改密码()
        {
            InitializeComponent();
        }
        public string s;
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("请输入密码");
                this.textBox1.Focus();
            }
            else
            {
                if (this.textBox1.Text != this.textBox2.Text)
                {
                    MessageBox.Show("两次密码不一致");
                    this.textBox2.Focus();
                }
                else
                {
                    conn.Open();
                    cmd = new SqlCommand("update USERS_INFORMATION set USERS_PASSWORDS='" + this.textBox1.Text + "' where USERS_LOGINNAME='" + s + "'", conn);
                    cmd.ExecuteScalar();
                    if (MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        this.Close();
                    }
                    conn.Close();
                }
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}
