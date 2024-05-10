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

namespace loginpg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usernametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernametextbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (usernametextbox.Text == "Username") ;
            {
                usernametextbox.Clear();
            }
        }

        private void passwordtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordtextbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (passwordtextbox.Text == "Password") ;
            {
                passwordtextbox.Clear();
                passwordtextbox.PasswordChar = '*';
            }
        }

        private void insterpicbox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void facebookpicbox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void youtubepicbox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=ROHANSI-PC\\SQLEXPRESS02;database=master; integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = " select * from usertable where Username = '"+ usernametextbox.Text + "'and Password = '" + passwordtextbox.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count !=0)
            {
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
