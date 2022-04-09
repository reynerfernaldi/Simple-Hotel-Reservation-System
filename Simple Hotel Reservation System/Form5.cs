using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Simple_Hotel_Reservation_System
{
    public partial class Form5 : Form
    {
        int loadpersent;

        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                con.Open();

                String str = "Select username From loginuser Where username = '" + txt_username.Text + "' and password = '" + txt_password.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);

                cmd.ExecuteNonQuery();

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {

                    timer1.Enabled = true;
                    loadpersent = 0;
                    lbl_loding.Visible = true;

                }
                else
                {
                    MessageBox.Show("You Are Invalid User ...!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            lbl_loding.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (loadpersent < 100)
            {
                loadpersent += 2;
                lbl_loding.Text = loadpersent.ToString() + "% Loading ...";
            }
            else
            {
                this.Hide();
                timer1.Enabled = false;
                Form1 F = new Form1();
                F.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_password.UseSystemPasswordChar = true;
            }
            else 
            {
                txt_password.UseSystemPasswordChar = false;
            }
        }
    }
}
