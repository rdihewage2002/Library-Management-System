using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginpg.Properties
{
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible= false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=ROHANSI-PC\\SQLEXPRESS02; database=master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        int bid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                bid=int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
               // MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=ROHANSI-PC\\SQLEXPRESS02; database=master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook where bid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            txtbname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtauthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtbpubl.Text = ds.Tables[0].Rows[0][3].ToString();
            txtbpdate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtbprice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtbquan.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtbookname_TextChanged(object sender, EventArgs e)
        {
            if(txtbookname.Text!="")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=ROHANSI-PC\\SQLEXPRESS02; database=master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook where bname LIKE '"+txtbname.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=ROHANSI-PC\\SQLEXPRESS02; database=master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtbookname.Clear();
            panel2.Visible = false;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            String bname = txtbname.Text;
            String bauthor = txtauthor.Text;
            String bpubl 
        }
    }
}
