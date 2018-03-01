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
    public partial class 会员添加 : Form
    {
        public 会员添加()
        {
            InitializeComponent();
            this.textBox1.LostFocus += new System.EventHandler(textBox1_LostFocus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.comboBox1.SelectedItem.ToString();
            string t4 = "";
            switch (comboBox2.SelectedItem.ToString())
            {
                case "VIP1": t4 = "1"; break;
                case "VIP2": t4 = "2"; break;
                case "VIP3": t4 = "3"; break;
                case "VIP4": t4 = "4"; break;
                case "VIP5": t4 = "5"; break;
            }
            if (t1 == "")
            {
                MessageBox.Show("会员编号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = CONN.Myconn();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from VIP_INFORMATION where VIP_NUMBER='" + t1 + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.label8.Text = "该会员信息已存在!";
                    this.label8.Visible = true;
                    sdr.Close();
                }
                else
                {
                    cmd.Clone();
                    cmd = new SqlCommand("insert VIP_INFORMATION values('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "')", conn);
                    sdr.Close();
                    cmd.ExecuteScalar();
                    this.label8.Text = "增加成功!";
                    this.label8.Visible = true;
                }
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.comboBox1.SelectedIndex = 0;
                this.comboBox2.SelectedIndex = 0;
                conn.Close();
            }
            this.textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.textBox1.Focus();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("男");
            this.comboBox1.Items.Add("女");
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.Items.Add("VIP1");
            this.comboBox2.Items.Add("VIP2");
            this.comboBox2.Items.Add("VIP3");
            this.comboBox2.Items.Add("VIP4");
            this.comboBox2.Items.Add("VIP5");
            this.comboBox2.SelectedIndex = 0;
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                this.label8.Visible = false;
            }
        }
        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            SqlConnection conn = CONN.Myconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from VIP_INFORMATION where VIP_NUMBER='" + t1 + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                if (MessageBox.Show("该会员编号已存在!请重新填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                      this.textBox1.Text = "";
                    this.textBox1.Focus();
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
