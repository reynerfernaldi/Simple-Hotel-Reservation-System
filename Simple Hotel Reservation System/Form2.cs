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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Showdata();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clear()
        {
            txt_client_address.Clear();
            txt_client_contact.Clear();
            txt_client_id.Clear();
            txt_client_name.Clear();
            cmb_client_gender.Text = "";
            dtp_client_dob.Text = "";
            dtp_client_registration_date.Text = "";
            txt_client_id.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_client_id.Text == "" || txt_client_name.Text == "" || txt_client_contact.Text == "" || txt_client_address.Text == "" || cmb_client_gender.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Insert Into client (c_id,c_name,c_gender,c_dateofbirth,c_contact,c_registration_date,c_address)Values('" + txt_client_id.Text + "','" + txt_client_name.Text + "','" + cmb_client_gender.Text + "','" + dtp_client_dob.Text + "','" + txt_client_contact.Text + "','" + dtp_client_registration_date.Text + "','" + txt_client_address.Text + "')";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(c_id) From client";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        Showdata();
                        MessageBox.Show("Clients Registration is Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Clients Registration is Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please , Enter Anthor ID , This ID Is All Ready Used ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void clientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.clients);

        }

        private void clientBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.clients);

        }

        public void Showdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            String str = "Select * From client";

            SqlCommand cmd = new SqlCommand(str, con);

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            clientDataGridView.DataSource = dt;

            con.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

            con.Open();

            String str = "Select c_name,c_gender,c_dateofbirth,c_contact,c_registration_date,c_address From client Where c_id = '" + txt_client_id.Text + "'";

            SqlCommand cmd = new SqlCommand(str, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txt_client_name.Text = dr.GetValue(0).ToString();
                cmb_client_gender.Text = dr.GetValue(1).ToString();
                dtp_client_dob.Text = dr.GetValue(2).ToString();
                txt_client_contact.Text = dr.GetValue(3).ToString();
                dtp_client_registration_date.Text = dr.GetValue(4).ToString();
                txt_client_address.Text = dr.GetValue(5).ToString();
            }
            else
            {

                MessageBox.Show(" This Client Id is Invalid, Please Insert Correct Id", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (txt_client_name.Text == "" || txt_client_contact.Text == "" || txt_client_address.Text == "" || cmb_client_gender.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Update client Set c_name = '" + txt_client_name.Text + "',c_gender = '" + cmb_client_gender.Text + "',c_dateofbirth = '" + dtp_client_dob.Text + "',c_contact = '" + txt_client_contact.Text + "',c_registration_date = '" + dtp_client_registration_date.Text + "',c_address = '" + txt_client_address.Text + "' Where c_id = '" + txt_client_id.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(c_id) From client";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        Showdata();
                        MessageBox.Show("Client Record Updated Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Client Record Updated  Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_client_name.Text == "" || txt_client_contact.Text == "" || txt_client_address.Text == "" || cmb_client_gender.Text == "")
            {
                MessageBox.Show("Please Fill Up All Deteils ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\Hotel Resv Sys\database\Simple_Hotel_Reservation_System.mdf;Integrated Security=True");

                    con.Open();

                    String str = "Delete From client Where c_id = '" + txt_client_id.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, con);

                    String str2 = "Select max(c_id) From client";

                    SqlCommand cmd2 = new SqlCommand(str2, con);

                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        Showdata();
                        MessageBox.Show("Client Record Deleted Successfull ...!", "SHRS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Client Record Deleted Failed ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}