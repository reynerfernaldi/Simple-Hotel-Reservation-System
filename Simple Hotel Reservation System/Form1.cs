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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form3 F = new Form3();
            F.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form4 F = new Form4();
            F.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            totalclient();
            totalrooms();
            totalreservations();

        }

        public void totalclient() 
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Select Count(c_id)From client";

            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            lbl_clients.Text = rows_count.ToString();

        }

        public void totalrooms()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Select Count(r_no)From rooms";

            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            lbl_rooms.Text = rows_count.ToString();

        }

        public void totalreservations()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Select Count(reserv_id)From reservation";

            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            lbl_reservations.Text = rows_count.ToString();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 F = new Form3();
            F.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form4 F = new Form4();
            F.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            totalclient();
            totalrooms();
            totalreservations();
        }
    }
}
