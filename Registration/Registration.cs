using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Function_Hall_Reservation_System.Registration
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            string str = "";
            if (rdbMale.Checked == true)
            {
                str = rdbMale.Text; // male
                rdbFemale.Checked = false;
            }
            else
            {
                str = rdbFemale.Text;
                rdbMale.Checked = false;
            }
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Insert into users(firstname,lastname,gender,studentid,password,dateregistered,roleid)values('" + txtFirstname.Text + "','" + txtLastname.Text + "','" + str + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + DateTime.Now.ToString() + "',1)";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Registered Successfully!\n can now log in with your account", "Login", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();

                Form1 login = new Form1();
                this.Visible = false;
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
