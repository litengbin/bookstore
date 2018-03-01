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
    public partial class 销售图书 : Form
    {
        public 销售图书()
        {
            InitializeComponent();
            this.textBox1.LostFocus += new System.EventHandler(textBox1_LostFocus);
            this.textBox3.LostFocus += new System.EventHandler(textBox3_LostFocus);
            this.textBox5.LostFocus += new System.EventHandler(textBox5_LostFocus);
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataReader sdr;
        int number;
        float a = 0;
        double total = 0;
        float i = 0;
        int r = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox2.Focus();
            this.textBox3.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox4.Text = "";
            this.comboBox1.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
            this.textBox7.Text = DateTime.Now.ToLongDateString();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select count(*) from CUSTOMER_INFORMATION", conn);
            int j = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            conn.Close();
            this.textBox1.Text = j.ToString();
            this.textBox2.Focus();
            this.comboBox1.Items.Add("男");
            this.comboBox1.Items.Add("女");
            this.comboBox1.SelectedIndex = 0;
            this.comboBox3.Items.Add("是");
            this.comboBox3.Items.Add("否");
            this.comboBox3.SelectedIndex = 0;
            this.textBox7.Text = DateTime.Now.ToLongDateString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedItem.ToString() == "是")
            {
                this.textBox3.Enabled = true;
                this.button4.Enabled = true;
            }
            else
            {
                this.textBox3.Text = "";
                this.textBox3.Enabled = false;
                this.button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            会员查询 frm18 = new 会员查询();
            frm18.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            图书查询 frm8 = new 图书查询();
            frm8.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox5.Text.Trim();
            string t2 = this.textBox3.Text.Trim();
            if (int.TryParse(this.textBox6.Text.Trim(), out number))
            {
                conn.Open();
                cmd = new SqlCommand("select BOOK_PRICE from BOOK_INFORMATION where BOOK_NUMBER = '" + t1 + "'", conn);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    a = float.Parse(sdr["BOOK_PRICE"].ToString().Trim());
                    sdr.Close();
                    if (this.comboBox3.SelectedItem.ToString() == "是")
                    {
                        cmd.Clone();
                        cmd = new SqlCommand("select * from VIP_INFORMATION where VIP_NUMBER = '" + t2 + "'", conn);
                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            switch (sdr["VIP_LEVEL"].ToString().Trim())
                            {
                                case "1":
                                    { i = 0.9f; total = number * a * 0.9; this.textBox4.Text = total.ToString("F2"); break; }
                                case "2":
                                    { i = 0.8f; total = number * a * 0.8; this.textBox4.Text = total.ToString("F2"); break; }
                                case "3":
                                    { i = 0.7f; total = number * a * 0.7; this.textBox4.Text = total.ToString("F2"); break; }
                                case "4":
                                    { i = 0.6f; total = number * a * 0.6; this.textBox4.Text = total.ToString("F2"); break; }
                                case "5":
                                    { i = 0.5f; total = number * a * 0.5; this.textBox4.Text = total.ToString("F2"); break; }
                            }
                        }
                        else
                        {
                            if (this.textBox3.Text == "")
                            {

                                MessageBox.Show("sorry,请填写会员编号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("sorry,该会员不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            this.textBox3.Focus();
                        }
                        sdr.Close();
                    }
                    else
                    {
                        i = 1f;
                        total = number * a * i;
                        this.textBox4.Text = total.ToString("F2");
                    }
                    sdr.Close();
                }
                else
                {
                    if (this.textBox5.Text == "")
                    {
                        MessageBox.Show("sorry,请填写图书编号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("sorry,该图书不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.textBox5.Text = "";
                    this.textBox5.Focus();
                }
            }
            else
            {
                MessageBox.Show("sorry,图书数量不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.textBox6.Focus();
            }
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            会员等级详情 frm19 = new 会员等级详情();
            frm19.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            计算详情 frm20 = new 计算详情();
            if (this.textBox4.Text == "")
            {
                frm20.s = string.Format("无信息!");
            }
            else
            {
                frm20.s = string.Format("计算过程:{0}(图书单价) * {1}(购买图书数量) * {2}(折扣) = {3}(总价格) ", a, number, i, total.ToString("F2"));
            }
            frm20.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.comboBox1.SelectedItem.ToString().Trim();
            string t4 = this.comboBox3.SelectedItem.ToString().Trim();
            int t5;
            if (int.TryParse(this.textBox6.Text.Trim(), out t5))
            {

            }
            else
            {
                MessageBox.Show("sorry,购买数量不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }  
            float t6;
            if (float.TryParse(this.textBox4.Text.Trim(), out t6))
            {

            }
            else
            {
                MessageBox.Show("sorry,总价格不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }   
            DateTime t7 =DateTime.Parse(this.textBox7.Text.Trim());
            string t8 = this.textBox5.Text.Trim();
            string t9 = this.textBox3.Text.Trim();
            conn.Open();
            cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_NUMBER='" + t8 + "'", conn);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                r = int.Parse(sdr["BOOK_RESERVE"].ToString().Trim());
                sdr.Close();
                cmd.Clone();
                r = r - t5;
                if (r >= 0)
                {
                    cmd = new SqlCommand("insert into CUSTOMER_INFORMATION values('"+t1+"','"+t2+"','"+t3+"','"+t4+"',"+t5+","+t6+",'"+t7+"','"+t8+"','"+t9+"')",conn);
                    cmd.ExecuteScalar();
                    this.label10.Text = "出售成功!";
                    this.label10.Visible = true;
                    cmd.Clone();
                    cmd = new SqlCommand("update BOOK_INFORMATION set BOOK_RESERVE=" + r + " where BOOK_NUMBER = '" + t8 + "'", conn);
                    cmd.ExecuteScalar();
                    string s = string.Format("该图书出售后，剩余库存量为{0}", r);
                    this.label11.Text = s;
                    this.label11.Visible = true;
                    cmd = new SqlCommand("select count(*) from CUSTOMER_INFORMATION", conn);
                    int i = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    this.textBox1.Text = i.ToString();
                }
                else
                {
                    MessageBox.Show("sorry,图书库存不足,无法购买!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("sorry,该图书不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.textBox2.Text = "";
            this.textBox1.Focus();
            this.textBox3.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox4.Text = "";
            this.comboBox1.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
            this.textBox7.Text = DateTime.Now.ToLongDateString();
            conn.Close();
        }
        private void textBox3_LostFocus(object sender, EventArgs e)
        {
            string t1 = this.textBox3.Text.Trim();
            SqlConnection conn = CONN.Myconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from VIP_INFORMATION where VIP_NUMBER='" + t1 + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

            }
            else
            {
                if (this.textBox3.Text != "")
                {
                    MessageBox.Show("该会员编号不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox3.Text = "";
                    this.textBox3.Focus();
                }
            }
        }
        private void textBox5_LostFocus(object sender, EventArgs e)
        {
            string t1 = this.textBox5.Text.Trim();
            SqlConnection conn = CONN.Myconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_NUMBER='" + t1 + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

            }
            else
            {
                if (this.textBox5.Text != "")
                {
                    MessageBox.Show("该图书编号不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox5.Text = "";
                    this.textBox5.Focus();
                }
            }
        }
        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            this.label10.Visible = false;
            this.label11.Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
