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
                Functions.Functions.gen = "Insert into users(firstname,lastname,age,gender,status,studentid,password,dateregistered,roleid)values('" + txtFirstname.Text + "','" + txtLastname.Text + "'," + txtAge.Text + ",'" + str + "','" + cmbStatus.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + DateTime.Now.ToString() + "',1)";
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
    }
}
