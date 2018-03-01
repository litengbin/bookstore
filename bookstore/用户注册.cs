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
    public partial class 用户注册 : Form
    {
        public 用户注册()
        {
            InitializeComponent();
            this.textBox1.LostFocus += new System.EventHandler(textBox1_LostFocus);
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataReader sdr;
        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.comboBox1.SelectedItem.ToString().Trim();
            string t4 = this.textBox4.Text.Trim();
            string t5 = this.textBox5.Text.Trim();
            string t6 = "";
            switch (comboBox2.SelectedItem.ToString())
            {
                case "管理人员": t6 = "1"; break;
                case "销售人员": t6 = "2"; break;
            }
            if (t1 == "")
            {
                MessageBox.Show("用户编号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn = CONN.Myconn();
                conn.Open();
                cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_NUMBER='" + t1 + "'", conn);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.label8.Text = "该用户信息已存在!";
                    this.label8.Visible = true;
                    sdr.Close();
                }
                else
                {
                    cmd.Clone();
                    cmd = new SqlCommand("insert USERS_INFORMATION values('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "')", conn);
                    sdr.Close();
                    cmd.ExecuteScalar();
                    this.label8.Text = "增加成功!";
                    this.label8.Visible = true;
                }
                this.textBox1.Text = "";
                this.textBox1.Focus();
                this.textBox2.Text = "";
                this.comboBox1.SelectedItem = 0;
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.comboBox2.SelectedItem = 0;
                conn.Close();
            }
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            this.comboBox1.Items.Add("男");
            this.comboBox1.Items.Add("女");
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.Items.Add("管理人员");
            this.comboBox2.Items.Add("销售人员");
            this.comboBox2.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                this.label8.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox1.Focus();
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
        }
        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            SqlConnection conn = CONN.Myconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_NUMBER='" + t1 + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                if (MessageBox.Show("该用户编号已存在!请重新填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    this.textBox1.Text = "";
                    this.textBox1.Focus();
                }
            }
        }
    }
}
