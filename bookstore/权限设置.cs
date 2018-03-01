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
    public partial class 权限设置 : Form
    {
        public 权限设置()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataReader sdr;
        public string n;
        public bool symbol = false;
        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            switch (comboBox2.SelectedItem.ToString())
            {
                case "管理人员": s = "1"; break;
                case "销售人员": s = "2"; break;
            }
            conn.Open();
            string s1 = this.comboBox1.SelectedItem.ToString().Trim();
            cmd = new SqlCommand("update USERS_INFORMATION set USERS_AUTHORIZATIONS='" + s + "' where USERS_LOGINNAME = '"+ s1 + "'", conn);
            cmd.ExecuteScalar();
            if (MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {    
                if(n == this.comboBox1.SelectedItem.ToString().Trim())
                {
                    MessageBox.Show("由于您修改当前账号的权限,请重新登录!","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    symbol = true;
                }
                this.Close();
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from USERS_INFORMATION", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                this.comboBox1.Items.Add(sdr["USERS_LOGINNAME"].ToString().Trim());
            }
            this.comboBox1.SelectedIndex = 0;
            sdr.Close();
            this.comboBox2.Items.Add("管理人员");
            this.comboBox2.Items.Add("销售人员");
            this.comboBox2.SelectedIndex = 0;
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
