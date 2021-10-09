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

namespace Function_Hall_Reservation_System.WorkingStudent
{
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filldata();
            lblfullname.Text = Form1.setfullname;
        }
        public void Filldata()
        {
            Functions.Functions.gen = "Select * from users";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendarOfActivities calendar = new CalendarOfActivities();
            this.Visible = false;
            calendar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            this.Visible = false;
            reservation.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Accounts accounts = new Accounts();
            this.Visible = false;
            accounts.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Equipments equipments = new Equipments();
            this.Visible = false;
            equipments.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            GenerateReports report = new GenerateReports();
            this.Visible = false;
            report.Show();
        }

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtfirstname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtlastname.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                txtage.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                cmbstatus.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                txtstudentid.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                txtpassword.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                txtroleid.Text = dataGridView1[8, e.RowIndex].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[9].FormattedValue.Equals("Male"))
                {
                    rdbmale.Checked = true;
                    rdbfemale.Checked = false;
                }
                else
                {
                    rdbmale.Checked = false;
                    rdbfemale.Checked = true;
                }
                //btnRegister.Enabled = false;
                //btnUpdate.Enabled = true;
                //btnDelete.Enabled = true;
                lbldate.Visible = true;
                //lblroleid.Visible = true;
                txtroleid.Visible = true;
                dateTimePicker1.Visible = true;
                this.tabControl1.SelectedIndex = 1;
                button7.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE users SET roleid='" + txtroleid.Text + "' where studentid = '"+txtstudentid.Text+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "users", MessageBoxButtons.OK);

                Connection.Connection.conn.Close();
                Accounts acc = new Accounts();
                this.Close();
                acc.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
