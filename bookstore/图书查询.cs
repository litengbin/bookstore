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
    public partial class 图书查询 : Form
    {
        public 图书查询()
        {
            InitializeComponent();
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
                this.label1.Text = "输入图书类别:";
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                label1.Text = "输入图书类别:";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入出版社:";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入书名:";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入作者:";
            }
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
                    cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_VARIETY='" + t1 + "'", conn);
                }
                else if (this.radioButton2.Checked == true)
                {
                    cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_PUBLISHER='" + t1 + "'", conn);
                }
                else if (this.radioButton3.Checked == true)
                {
                    cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_NAME='" + t1 + "'", conn);
                }
                else if (this.radioButton4.Checked == true)
                {
                    cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_AUTHOR='" + t1 + "'", conn);
                }
                else if (this.radioButton5.Checked == true)
                {
                    cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_NUMBER='" + t1 + "'", conn);
                }
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string s1 = sdr[0].ToString().Trim();
                    this.dataGridView1.Visible = true;
                    cmd.Clone();
                    sdr.Close();
                    cmd = new SqlCommand("select BOOK_NUMBER as 图书编号,BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, BOOK_PUBLISHER as 出版社,BOOK_PRICE as 图书单价, BOOK_VARIETY as 图书类别, BOOK_RESERVE as 库存量 from BOOK_INFORMATION where BOOK_NUMBER = '" + s1 + "'", conn);
                    sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    ds = new DataSet();
                    sda.Fill(ds, "BOOK_INFORMATION");
                    this.dataGridView1.DataSource = ds.Tables[0];
                    cmd.Clone();
                }
                else
                {                
                     MessageBox.Show("sorry,该图书不存在!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.dataGridView1.Visible = false;
                    this.textBox1.Text = "";
                }
            }
            conn.Close();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                this.textBox1.Text = "";
                this.dataGridView1.Visible = false;
                this.groupBox4.Visible = true;
                this.label1.Text = "输入图书编号:";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
