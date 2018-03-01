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
    public partial class 系统备份 : Form
    {
        public 系统备份()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string strg = Application.StartupPath.ToString();
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg += @"\Data";
                string sqltxt = @"BACKUP DATABASE BOOKSTORE TO Disk='" + strg + "\\" + this.TextBox1.Text + ".bak" + "'";
                conn.Open();
                cmd = new SqlCommand(sqltxt, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                if (MessageBox.Show("备份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
