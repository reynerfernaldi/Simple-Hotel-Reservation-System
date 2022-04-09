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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reservationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.reservationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.reservation);

        }



        private void Form4_Load(object sender, EventArgs e)
        {
            showdata();
            fillroomno();
        }


        public void fillroomno()
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                con.Open();

                String str = "Select r_no From rooms";

                SqlCommand cmd = new SqlCommand(str, con);

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                foreach (DataRow dr in dt.Rows) 
                {
                    cmb_room_no.Items.Add(dr["r_no"].ToString());
                }

                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_reservatoin_id.Text == "" || txt_client_id.Text == "" || cmb_room_type.Text == "" || cmb_room_no.Text == "" || dtp_date_in.Text == "" || dtp_date_out.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Insert Into reservation (reserv_id,client_id,room_type,room_no,date_in,date_out)Values('"+txt_reservatoin_id.Text+"','"+txt_client_id.Text+"','"+cmb_room_type.Text+"','"+cmb_room_no.Text+"','"+dtp_date_in.Text+"','"+dtp_date_out.Text+"')";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(reserv_id) From reservation";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        showdata();
                        MessageBox.Show("Reservation Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Reservation Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please , Enter Anthor ID , This ID Is All Ready Used ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
       
        }

        public void showdata() 
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            String str = "Select * From reservation";

            SqlCommand cmd = new SqlCommand(str, con);

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            reservationDataGridView.DataSource = dt;

            con.Close();

        }

        public void clear() 
        {
            txt_reservatoin_id.Text = "";
            txt_client_id.Text = "";
            cmb_room_type.Text = "";
            cmb_room_no.Text = "";
            dtp_date_in.Text = "";
            dtp_date_out.Text = "";
            txt_reservatoin_id.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_reservatoin_id.Text == "" || txt_client_id.Text == "" || cmb_room_type.Text == "" || cmb_room_no.Text == "" || dtp_date_in.Text == "" || dtp_date_out.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Update reservation Set client_id = '"+txt_client_id.Text+"',room_type = '"+cmb_room_type.Text+"',room_no = '"+cmb_room_no.Text+"',date_in = '"+dtp_date_in.Text+"',date_out = '"+dtp_date_out.Text+"' Where reserv_id = '"+txt_reservatoin_id.Text+"'";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(reserv_id) From reservation";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        showdata();
                        MessageBox.Show("Reservation Updated Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Reservation Updated Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please , Enter Anthor ID , This ID Is All Ready Used ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
       
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txt_reservatoin_id.Text == "" || txt_client_id.Text == "" || cmb_room_type.Text == "" || cmb_room_no.Text == "" || dtp_date_in.Text == "" || dtp_date_out.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Delete From reservation Where reserv_id = '" + txt_reservatoin_id.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(reserv_id) From reservation ";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        showdata();
                        MessageBox.Show("Reservation Record Deleted Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Reservation Record Deleted Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                con.Open();

                String str = "Select client_id,room_type,room_no,date_in,date_out From reservation Where reserv_id = '" + txt_reservatoin_id.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txt_client_id.Text = dr.GetValue(0).ToString();
                    cmb_room_type.Text = dr.GetValue(1).ToString();
                    cmb_room_no.Text = dr.GetValue(2).ToString();
                    dtp_date_in.Text = dr.GetValue(3).ToString();
                    dtp_date_out.Text = dr.GetValue(4).ToString();
                }
                else
                {

                    MessageBox.Show(" This Reservation ID is Invalid , Insert Correct ID", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                con.Close();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
    
        }

    }
}
