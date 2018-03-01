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
    public partial class 图书信息查看 : Form
    {
        public 图书信息查看()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select BOOK_NUMBER as 图书编号,BOOK_NAME as 图书名称, BOOK_AUTHOR as 图书作者, BOOK_PUBLISHER as 出版社,BOOK_PRICE as 图书单价, BOOK_VARIETY as 图书类别, BOOK_RESERVE as 库存量 from BOOK_INFORMATION", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "BOOK_INFORMATION");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }
    }
}
