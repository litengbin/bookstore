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
    public partial class 用户更改 : Form
    {
        public 用户更改()
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
                cmd = new SqlCommand("select USERS_NUMBER as 用户编号,USERS_NAME as 姓名, USERS_SEX as 性别, USERS_LOGINNAME as 登录名,USERS_PASSWORDS as 密码, USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "USERS_INFORMATION");
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
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string t1 = this.textBox1.Text.Trim();
            if (t1 == "")
            {
                MessageBox.Show("用户编号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dataGridView1.Visible = false;
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_NUMBER='" + t1 + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.dataGridView1.Visible = true;
                    this.groupBox3.Enabled = true;
                    cmd.Clone();
                    sdr.Close();
                    cmd = new SqlCommand("select USERS_NUMBER as 用户编号, USERS_NAME as 用户姓名, USERS_SEX as 用户性别, USERS_LOGINNAME as 登录名, USERS_PASSWORDS as 密码,USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION where USERS_NUMBER = '" + t1 + "'", conn);
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
                }
            }
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox4.Text = this.dataGridView1.SelectedCells[0].Value.ToString();
            this.textBox5.Text = this.dataGridView1.SelectedCells[1].Value.ToString();
            this.textBox6.Text = this.dataGridView1.SelectedCells[2].Value.ToString();
            this.textBox7.Text = this.dataGridView1.SelectedCells[3].Value.ToString();
            this.textBox2.Text = this.dataGridView1.SelectedCells[4].Value.ToString();
            this.textBox3.Text = this.dataGridView1.SelectedCells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox4.Text.Trim();
            string t2 = this.textBox5.Text.Trim();
            string t3 = this.textBox6.Text.Trim();
            string t4 = this.textBox7.Text.Trim();
            string t5 = this.textBox2.Text.Trim();
            string t6 = this.textBox3.Text.Trim();
            if (t1 == "")
            {
                MessageBox.Show("请选择要更改的用户信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            switch (t6)
            {
                case "1":
                case "2": break;
                default:
                    {
                        MessageBox.Show("填写不正确,权限只能填1或2(1---管理人员, 2---销售人员)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.textBox3.Text = "";
                        this.textBox3.Focus();
                        return;
                    }
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("update USERS_INFORMATION set USERS_NAME = '" + t2 + "',USERS_SEX='" + t3 + "',USERS_LOGINNAME='" + t4 + "',USERS_PASSWORDS='" + t5 + "',USERS_AUTHORIZATIONS='" + t6 + "' where USERS_NUMBER ='" + t1 + "'", conn);
            cmd.ExecuteScalar();
            MessageBox.Show("更新成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            cmd.Clone();
            if (this.radioButton2.Checked == true)
            {
                cmd = new SqlCommand("select USERS_NUMBER as 用户编号, USERS_NAME as 用户姓名, USERS_SEX as 用户性别, USERS_LOGINNAME as 登录名, USERS_PASSWORDS as 密码,USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "USERES_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.radioButton1.Checked == true)
            {
                cmd = new SqlCommand("select USERS_NUMBER as 用户编号, USERS_NAME as 用户姓名, USERS_SEX as 用户性别, USERS_LOGINNAME as 登录名, USERS_PASSWORDS as 密码,USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION where USERS_NUMBER = '" + t1 + "'", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "USERS_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            cmd.Clone();
            conn.Close();        
        }
    }
}
