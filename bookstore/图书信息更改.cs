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
    public partial class 图书信息更改 : Form
    {
        public 图书信息更改()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        private void Form5_Load(object sender, EventArgs e)
        {
    
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.textBox3.Text.Trim();
            if (t1 == "")
            {
                MessageBox.Show("图书编号不能为空!","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.dataGridView1.Visible = false;
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from BOOK_INFORMATION where BOOK_NUMBER='" + t1 + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.dataGridView1.Visible = true;
                    this.groupBox3.Enabled = true;
                    cmd.Clone();
                    sdr.Close();
                    cmd = new SqlCommand("select BOOK_NUMBER as 图书编号,BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, BOOK_PUBLISHER as 出版社,BOOK_PRICE as 图书单价, BOOK_VARIETY as 图书类别, BOOK_RESERVE as 库存量 from BOOK_INFORMATION where BOOK_NUMBER = '" + t1 + "'", conn);
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
                }        
            }
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            conn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.groupBox1.Enabled = true;
                this.dataGridView1.Visible = false;
                this.groupBox3.Enabled = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
                this.textBox9.Text = "";
                this.textBox10.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.groupBox1.Enabled = false;
                this.dataGridView1.Visible = true;
                this.groupBox3.Enabled = true;
                conn = CONN.Myconn();
                conn.Open();
                cmd = new SqlCommand("select BOOK_NUMBER as 图书编号,BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, BOOK_PUBLISHER as 出版社,BOOK_PRICE as 图书单价, BOOK_VARIETY as 图书类别, BOOK_RESERVE as 库存量 from BOOK_INFORMATION", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "BOOK_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];
                cmd.Clone();
                conn.Close();
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
                this.textBox9.Text = "";
                this.textBox10.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox4.Text = this.dataGridView1.SelectedCells[0].Value.ToString();
            this.textBox5.Text = this.dataGridView1.SelectedCells[1].Value.ToString();
            this.textBox6.Text = this.dataGridView1.SelectedCells[2].Value.ToString();
            this.textBox7.Text = this.dataGridView1.SelectedCells[3].Value.ToString();
            this.textBox8.Text = this.dataGridView1.SelectedCells[4].Value.ToString();
            this.textBox9.Text = this.dataGridView1.SelectedCells[5].Value.ToString();
            this.textBox10.Text = this.dataGridView1.SelectedCells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox4.Text.Trim();
            string t2 = this.textBox5.Text.Trim();
            string t3 = this.textBox6.Text.Trim();
            string t4 = this.textBox7.Text.Trim();
            float t5;
            if (float.TryParse(this.textBox8.Text.Trim(), out t5))
            {

            }
            else
            {
                t5 = 0;
            }
            string t6 = this.textBox9.Text.Trim();
            int t7;
            if (int.TryParse(this.textBox10.Text.Trim(), out t7))
            {

            }
            else
            {
                t7 = 0;
            }
            if (t1 == "")
            {
                MessageBox.Show("请选择要更改的图书信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("update BOOK_INFORMATION set BOOK_NAME = '" + t2 + "',BOOK_AUTHOR='" + t3 + "',BOOK_PUBLISHER='" + t4 + "',BOOK_PRICE=" + t5 + ",BOOK_VARIETY='" + t6 + "',BOOK_RESERVE=" + t7 + " where BOOK_NUMBER ='"+ t1 +"'", conn);
            cmd.ExecuteScalar();
            MessageBox.Show("更新成功!","成功",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            cmd.Clone();
            if (this.radioButton2.Checked == true)
            {
                cmd = new SqlCommand("select BOOK_NUMBER as 图书编号,BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, BOOK_PUBLISHER as 出版社,BOOK_PRICE as 图书单价, BOOK_VARIETY as 图书类别, BOOK_RESERVE as 库存量 from BOOK_INFORMATION", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "BOOK_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if(this.radioButton1.Checked == true)
            {
                cmd = new SqlCommand("select BOOK_NUMBER as 图书编号,BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, BOOK_PUBLISHER as 出版社,BOOK_PRICE as 图书单价, BOOK_VARIETY as 图书类别, BOOK_RESERVE as 库存量 from BOOK_INFORMATION where BOOK_NUMBER ='" + t1 + "'", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "BOOK_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];        
            }
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            cmd.Clone();
            conn.Close();        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
        }
    }
}
