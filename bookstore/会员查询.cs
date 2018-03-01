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
    public partial class 会员查询 : Form
    {
        public 会员查询()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        private void Form18_Load(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                label1.Text = "输入会员编号:";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入会员编号:";
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
                this.label1.Text = "输入会员名称:";
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
                    cmd = new SqlCommand("select * from VIP_INFORMATION where VIP_NUMBER='" + t1 + "'", conn);
                }
                else if (this.radioButton2.Checked == true)
                {
                    cmd = new SqlCommand("select * from VIP_INFORMATION where VIP_NAME='" + t1 + "'", conn);
                }
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string s1 = sdr[0].ToString().Trim();
                    this.dataGridView1.Visible = true;
                    cmd.Clone();
                    sdr.Close();
                    cmd = new SqlCommand("select VIP_NUMBER as 会员编号, VIP_NAME as 会员姓名, VIP_SEX as 会员性别, VIP_LEVEL as 会员等级 from VIP_INFORMATION where VIP_NUMBER = '" + s1 + "'", conn);
                    sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    ds = new DataSet();
                    sda.Fill(ds, "VIP_INFORMATION");
                    this.dataGridView1.DataSource = ds.Tables[0];
                    cmd.Clone();
                }
                else
                {
                    MessageBox.Show("sorry,该会员不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dataGridView1.Visible = false;
                    this.textBox1.Text = "";
                }
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
