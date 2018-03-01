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
    public partial class 用户删除 : Form
    {
        public 用户删除()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter sda;
        DataSet ds;
        private void Form23_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.groupBox1.Visible = true;
                this.dataGridView1.Visible = false;
                this.groupBox1.Enabled = true;
                this.groupBox3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.groupBox1.Enabled = false;
                this.dataGridView1.Visible = true;
                this.groupBox3.Enabled = true;
                conn.Open();
                cmd = new SqlCommand("select USERS_NUMBER as 用户编号, USERS_NAME as 用户姓名, USERS_SEX as 用户性别, USERS_LOGINNAME as 登录名, USERS_PASSWORDS as 密码,USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "USERS_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];
                cmd.Clone();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.textBox3.Text.Trim();
            if (t1 == "")
            {
                MessageBox.Show("用户编号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dataGridView1.Visible = false;
                this.textBox1.Focus();
            }
            else
            {
                conn.Open();
                cmd = new SqlCommand("select * from USERS_INFORMATION where USERS_NUMBER='" + t1 + "'", conn);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.dataGridView1.Visible = true;
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
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox4.Text.Trim();
            string t2 = this.textBox5.Text.Trim();
            string t3 = this.textBox6.Text.Trim();
            if (t1 == "")
            {
                MessageBox.Show("请选择要删除的用户信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            conn.Open();
            cmd = new SqlCommand("delete from USERS_INFORMATION where USERS_NUMBER ='" + t1 + "'", conn);
            cmd.ExecuteScalar();
            MessageBox.Show("删除成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            cmd.Clone();
            if (this.radioButton2.Checked == true)
            {
                cmd = new SqlCommand("select * from USERS_INFORMATION", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "USERS_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.radioButton1.Checked == true)
            {
                cmd = new SqlCommand("select USERS_NUMBER as 用户编号, USERS_NAME as 用户姓名, USERS_SEX as 用户性别, USERS_LOGINNAME as 登录名, USERS_PASSWORDS as 密码,USERS_AUTHORIZATIONS as 权限 from USERS_INFORMATION where USERS_NUMBER ='" + t1 + "'", conn);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, "USERS_INFORMATION");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            cmd.Clone();
            conn.Close();     
        }
    }
}
