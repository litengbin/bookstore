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
    public partial class 销售统计 : Form
    {
        public 销售统计()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        string t1 = "";
        private void Form21_Load(object sender, EventArgs e)
        { 
            if (this.radioButton1.Checked == true)
            {
                label1.Text = "输入YYYY-MM-DD:";
            }
            this.comboBox1.Items.Add("第一季度");
            this.comboBox1.Items.Add("第二季度");
            this.comboBox1.Items.Add("第三季度");
            this.comboBox1.Items.Add("第四季度");
            this.comboBox1.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.textBox1.Text = ""; 
                this.groupBox3.Enabled = false;
                this.dataGridView1.Visible = false;
                this.label1.Text = "输入YYYY-MM-DD:";
                this.label2.Visible = false;
                this.comboBox1.Visible = false;
                this.textBox2.Visible = false;
                this.label3.Visible = false;
                this.textBox1.Focus();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.textBox1.Text = "";
                this.groupBox3.Enabled = false;
                this.dataGridView1.Visible = false;
                this.label1.Text = "输入YYYY-MM:";
                this.comboBox1.Visible = false;
                this.label2.Visible = false;
                this.textBox2.Visible = false;
                this.label3.Visible = false;
                this.textBox1.Focus();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                this.textBox1.Text = "";
                this.groupBox3.Enabled = false;
                this.dataGridView1.Visible = false;
                this.comboBox1.Visible = true;
                this.label2.Visible = true;
                this.textBox2.Visible = false;
                this.label3.Visible = false;
                this.label1.Text = "输入YYYY:";
                this.textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime t;
            t1 = this.textBox1.Text.Trim();
            float a = 0;
            int t2;
            string s = string.Format("{0}不能为空!", this.label1.Text);
            if (t1 == "")
            {
                MessageBox.Show(s, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                if (!DateTime.TryParse(t1, out t))
                {
                    if (this.radioButton3.Checked == true)
                    {
                        if (int.TryParse(this.textBox1.Text.ToString().Trim(), out t2) && int.Parse(t1.ToString().Trim()) >= 2010 && int.Parse(t1.ToString().Trim()) <= int.Parse(DateTime.Now.Year.ToString().Trim()))
                        {
                            switch (comboBox1.SelectedItem.ToString())
                            {
                                case "第一季度":
                                    {
                                        cmd = new SqlCommand("select sum(CUSTOMER_BUYNUMBER) as 图书总数,BOOK_NUMBER as 图书编号, BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, sum(CUSTOMER_MONEY) as 销售额 from CUSTOMER_INFORMATION, BOOK_INFORMATION where BOOK_NUMBER = CUSTOMER_BOOK_NUMBER and BUYTIME between '" + t1 + "-01-01' and '" + t1 + "-03-31' group by BOOK_NUMBER,BOOK_NAME,BOOK_AUTHOR order by 图书总数 desc,BOOK_NUMBER", conn); break;
                                    }
                                case "第二季度":
                                    {
                                        cmd = new SqlCommand("select sum(CUSTOMER_BUYNUMBER) as 图书总数,BOOK_NUMBER as 图书编号, BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, sum(CUSTOMER_MONEY) as 销售额 from CUSTOMER_INFORMATION, BOOK_INFORMATION where BOOK_NUMBER = CUSTOMER_BOOK_NUMBER and BUYTIME between '" + t1 + "-04-01' and '" + t1 + "-06-30' group by BOOK_NUMBER,BOOK_NAME,BOOK_AUTHOR order by 图书总数 desc,BOOK_NUMBER", conn); break;
                                    }
                                case "第三季度":
                                    {
                                        cmd = new SqlCommand("select sum(CUSTOMER_BUYNUMBER) as 图书总数,BOOK_NUMBER as 图书编号, BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, sum(CUSTOMER_MONEY) as 销售额 from CUSTOMER_INFORMATION, BOOK_INFORMATION where BOOK_NUMBER = CUSTOMER_BOOK_NUMBER and  BUYTIME between '" + t1 + "-07-01' and '" + t1 + "-09-30'group by BOOK_NUMBER,BOOK_NAME,BOOK_AUTHOR order by 图书总数 desc,BOOK_NUMBER", conn); break;
                                    }
                                case "第四季度":
                                    {
                                        cmd = new SqlCommand("select sum(CUSTOMER_BUYNUMBER) as 图书总数,BOOK_NUMBER as 图书编号, BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, sum(CUSTOMER_MONEY) as 销售额 from CUSTOMER_INFORMATION, BOOK_INFORMATION where BOOK_NUMBER = CUSTOMER_BOOK_NUMBER and  BUYTIME between '" + t1 + "-10-01' and '" + t1 + "-12-31'group by BOOK_NUMBER,BOOK_NAME,BOOK_AUTHOR order by 图书总数 desc,BOOK_NUMBER", conn); break;
                                    }
                            }
                        }
                        else
                        {
                            s = string.Format("时间为2010---{0}", DateTime.Now.Year.ToString().Trim());
                            MessageBox.Show(s, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            conn.Close();
                            this.textBox1.Text = "";
                            this.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请正确输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        conn.Close();
                        this.textBox1.Text = "";
                        this.Focus();
                        return;
                    }
                }
                else
                {
                    if (this.radioButton1.Checked == true)
                    {
                        cmd = new SqlCommand("select sum(CUSTOMER_BUYNUMBER) as 图书总数,BOOK_NUMBER as 图书编号, BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, sum(CUSTOMER_MONEY) as 销售额 from CUSTOMER_INFORMATION, BOOK_INFORMATION where  BUYTIME='" + t1 + "' and BOOK_NUMBER = CUSTOMER_BOOK_NUMBER group by BOOK_NUMBER,BOOK_NAME,BOOK_AUTHOR order by 图书总数 desc,BOOK_NUMBER ", conn);
                    }
                    else if (this.radioButton2.Checked == true)
                    {
                        cmd = new SqlCommand("select sum(CUSTOMER_BUYNUMBER) as 图书总数,BOOK_NUMBER as 图书编号, BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, sum(CUSTOMER_MONEY) as 销售额 from CUSTOMER_INFORMATION, BOOK_INFORMATION where convert(varchar(7),BUYTIME,120) ='" + t1 + "' and BOOK_NUMBER = CUSTOMER_BOOK_NUMBER group by BOOK_NUMBER,BOOK_NAME,BOOK_AUTHOR order by 图书总数 desc,BOOK_NUMBER ", conn);
                    }
                    else if (this.radioButton3.Checked == true)
                    {
                        MessageBox.Show("请正确输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        conn.Close();
                        this.textBox1.Text = "";
                        this.Focus();
                        return;
                    }
                }   
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        string s1 = sdr[0].ToString().Trim();
                        this.groupBox3.Enabled = true;
                        this.dataGridView1.Visible = true;
                        this.textBox2.Visible = true;
                        this.label3.Visible = true;
                        a = float.Parse(sdr["销售额"].ToString().Trim());
                        while (sdr.Read())
                        {
                            a += float.Parse(sdr["销售额"].ToString().Trim());

                        }
                        this.textBox2.Text = a.ToString("F2");
                        sdr.Close();
                        sda = new SqlDataAdapter();
                        sda.SelectCommand = cmd;
                        ds = new DataSet();
                        sda.Fill(ds, "CUSTOMER_INFORMATION");
                        this.dataGridView1.DataSource = ds.Tables[0];
                        cmd.Clone();
                    }
                    else
                    {
                        MessageBox.Show("sorry,无顾客信息!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.dataGridView1.Visible = false;
                        this.groupBox3.Enabled = false;
                        this.label3.Visible = false;
                        this.textBox2.Visible = false;
                        this.textBox1.Text = "";
                    }
            }
            conn.Close(); 
            this.textBox1.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
