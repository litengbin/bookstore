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
    public partial class 用户查询 : Form
    {
        public 用户查询()
        {
            InitializeComponent();
            if (this.radioButton1.Checked == true)
            {
                label1.Text = "输入用户编号:";
            }
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入用户编号:";
                this.textBox1.Focus();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入用户名称:";
                this.textBox1.Focus();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入登录名:";
                this.textBox1.Focus();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入权限:";
                this.textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string s = string.Format("{0}不能为空!", this.label1.Text);
            if (t1 == "")
            {
                MessageBox.Show(s, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                if (this.radioButton1.Checked == true)
                {
                    cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_NUMBER='" + t1 + "'", conn);
                }
                else if (this.radioButton2.Checked == true)
                {
                    cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_NAME='" + t1 + "'", conn);
                }
                else if (this.radioButton2.Checked == true)
                {
                    cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_LOGINNAME='" + t1 + "'", conn);
                }
                else if (this.radioButton2.Checked == true)
                {
                    cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_AUTHORIZATION='" + t1 + "'", conn);
                }
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string s1 = sdr[0].ToString().Trim();
                    this.dataGridView1.Visible = true;
                    cmd.Clone();
                    sdr.Close();
                    cmd = new SqlCommand("select USERS_NUMBER as 用户编号, USERS_NAME as 用户姓名, USERS_SEX as 用户性别, USERS_LOGINNAME as 登录名, USERS_PASSWORDS as 密码,USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION where USERS_NUMBER = '" + s1 + "'", conn);
                    sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    ds = new DataSet();
                    sda.Fill(ds, "USERS_INFORMATION");
                    this.dataGridView1.DataSource = ds.Tables[0];
                    cmd.Clone();
                }
                else
                {
                    MessageBox.Show("sorry,该用户不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dataGridView1.Visible = false;
                    this.textBox1.Text = "";
                }
            }
            conn.Close();
        }

        private void 用户查询_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
