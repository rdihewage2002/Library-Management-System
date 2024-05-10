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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bnametxtbox.Text != "" && bpubltxtbox.Text != "" && bptxtbox.Text != "" && bqtxtbox.Text != "")
            {
                String bname = bnametxtbox.Text;
                String baname = anametxtbox.Text;
                String bpublname = bpubltxtbox.Text;
                String bpdate = pdtxtbox.Text;
                Int64 bprice = Int64.Parse(bptxtbox.Text);
                Int64 bquan = Int64.Parse(bqtxtbox.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=ROHANSI-PC\\SQLEXPRESS02;database=master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into NewBook(bname,bauthor,bpubl,bpdate,bprice,bquan) values ('" + bname + "','" + baname + "','" + bpublname + "','" + bpdate + "','" + bprice + "','" + bquan + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bnametxtbox.Clear();
                anametxtbox.Clear();
                bpubltxtbox.Clear();
                bptxtbox.Clear();
                bqtxtbox.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will DELETE your unsaved DATA.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK) 
                {
                this.Close();
                }
        }
    }
}
