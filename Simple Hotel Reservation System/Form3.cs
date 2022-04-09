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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_room_no.Text == "" || cmb_room_type.Text == "" || dtp_date.Text == "" || cmd_room_free_paid.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Insert Into rooms (r_no,r_type,date,r_free_paid)Values('"+txt_room_no.Text+"','"+cmb_room_type.Text+"','"+dtp_date.Text+"','"+cmd_room_free_paid.Text+"')";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(r_no) From rooms";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        showdata();
                        MessageBox.Show("Room Record Added Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        
                    }
                    else
                    {
                        MessageBox.Show("Room Record Added Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please , Enter Anthor Room No. , This No. Is All Ready Used ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
       
        }

        public void showdata() 
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            String str = "Select * From rooms";

            SqlCommand cmd = new SqlCommand(str, con);

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            roomsDataGridView.DataSource = dt;

            con.Close();

        }

        public void clear() 
        {
            txt_room_no.Text = "";
            cmb_room_type.Text = "";
            dtp_date.Text = "";
            cmd_room_free_paid.Text = "";
            txt_room_no.Focus();
        }

        private void roomsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.roomsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rooms);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            showdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_room_no.Text == "" || cmb_room_type.Text == "" || dtp_date.Text == "" || cmd_room_free_paid.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Update rooms Set r_type = '"+cmb_room_type.Text+"',date = '"+dtp_date.Text+"',r_free_paid = '"+cmd_room_free_paid.Text+"' Where r_no = '"+txt_room_no.Text+"'";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(r_no) From rooms";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        showdata();
                        MessageBox.Show("Room Record Updated Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Room Record Updated Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please , Enter Anthor Room No. , This No. Is All Ready Used ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
       
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            String str = "Select r_type,date,r_free_paid From rooms Where r_no = '" + txt_room_no.Text + "'";

            SqlCommand cmd = new SqlCommand(str, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                cmb_room_type.Text = dr.GetValue(0).ToString();
                dtp_date.Text = dr.GetValue(1).ToString();
                cmd_room_free_paid.Text = dr.GetValue(2).ToString();    
            }
            else
            {

                MessageBox.Show(" This Room No. is Invalid, Please Insert Correct No.", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.Close();
      
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txt_room_no.Text == "" || cmb_room_type.Text == "" || dtp_date.Text == "" || cmd_room_free_paid.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Delete From rooms Where r_no = '" + txt_room_no.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(r_no) From rooms";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        showdata();
                        MessageBox.Show("Room Record Deleted Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Room Record Deleted Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}