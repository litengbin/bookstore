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
    public partial class 图书信息添加 : Form
    {
        public 图书信息添加()
        {
            InitializeComponent();
            this.textBox1.LostFocus += new System.EventHandler(textBox1_LostFocus);
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.textBox3.Text.Trim();
            string t4 = this.textBox4.Text.Trim();
            float t5;
            if (float.TryParse(this.textBox5.Text.Trim(), out t5))
            {
                
            }
            else
            {
                t5 = 0;
            }   
            string t6 = this.textBox6.Text.Trim();
            int t7;
            if (int.TryParse(this.textBox7.Text.Trim(), out t7))
            {

            }
            else
            {
                t7 = 0;
            }
            int number;
            if (t1 == "")
            {
                MessageBox.Show("图书编号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = CONN.Myconn();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_NUMBER='" + t1 + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.label8.Text = "图书信息已存在!";
                    this.label8.Visible = true;
                    number = int.Parse(sdr["BOOK_RESERVE"].ToString().Trim());
                    sdr.Close();
                    cmd.Clone();
                    number = number + t7;
                    cmd = new SqlCommand("update BOOK_INFORMATION set BOOK_RESERVE=" + number + " where BOOK_NUMBER = '"+ t1 +"'", conn);
                    cmd.ExecuteScalar();
                    string s = string.Format("新增{0}本图书后，总的库存量为{1}",t7,number);
                    this.label9.Text = s;
                    this.label9.Visible = true;
                }
                else
                {
                    cmd.Clone();
                    cmd = new SqlCommand("insert BOOK_INFORMATION values('"+ t1 +"','"+ t2 +"','"+ t3 +"','"+ t4 +"',"+ t5 +",'"+ t6 + "',"+ t7 +")",conn);
                    sdr.Close();
                    cmd.ExecuteScalar();
                    this.label8.Text = "增加成功!";
                    this.label8.Visible = true;
                    string s = string.Format("该图书入库后，总的库存量为{0}", t7);
                    this.label9.Text = s;
                    this.label9.Visible = true;
                }
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox1.Focus();
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
                this.label9.Visible = false;
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_LostFocus(object sender,EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            SqlConnection conn = CONN.Myconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_NUMBER='" + t1 + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                if (MessageBox.Show("图书编号已存在!是否显示", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.textBox2.Text = sdr[1].ToString().Trim();
                    this.textBox3.Text = sdr[2].ToString().Trim();
                    this.textBox4.Text = sdr[3].ToString().Trim();
                    this.textBox5.Text = sdr[4].ToString().Trim();
                    this.textBox6.Text = sdr[5].ToString().Trim();
                    this.textBox7.Focus();
                }
                else
                {
                    this.textBox1.Text = "";
                    this.textBox1.Focus();
                   
                }
            }
        }
    }
}
