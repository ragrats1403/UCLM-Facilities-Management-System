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
    public partial class Reservation : Form
    {
        public Reservation()
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
            //Functions.Functions.gen = "Select events.eventid AS [EVENT ID], events.eventname AS [EVENT NAME], events.eventprice AS [Event Price],events.dateregistered AS [DATE REGISTERED] from events";
            //Functions.Functions.gen = "Select * from reservation where studentid = '" + Form1.setstudentid + "'";
            Functions.Functions.gen = "Select * from reservation where reservationstatus = 'Pending'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            Accounts accounts = new Accounts();
            this.Visible = false;
            accounts.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Equipments equipments = new Equipments();
            this.Visible = false;
            equipments.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerateReports report = new GenerateReports();
            this.Visible = false;
            report.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtstudentid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtreservationid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txteventname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtreservedby.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                cmbstatus.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txtdatereserved.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                txtcheckedby.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                txtapprovedby.Text = dataGridView1[6, e.RowIndex].Value.ToString(); 
                txtstudentid.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                txtstudentname.Text = dataGridView1[8, e.RowIndex].Value.ToString();
                txtreservedequipments.Text = dataGridView1[9, e.RowIndex].Value.ToString();
                txtreservedate.Text = dataGridView1[10, e.RowIndex].Value.ToString();
                txttimestart.Text = dataGridView1[11, e.RowIndex].Value.ToString();
                txttimerend.Text = dataGridView1[12, e.RowIndex].Value.ToString();

                //btnRegister.Enabled = false;
                //btnUpdate.Enabled = true;
                //btnDelete.Enabled = true;
                lbldate.Visible = true;
                //lblroleid.Visible = true;
                txtapprovedby.Visible = true;
                txtdatereserved.Visible = true;
                this.tabControl1.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE reservation SET reservationstatus='" + cmbstatus.Text +"',checkedby='"+Form1.setfullname+"' where reservationid = '"+txtreservationid.Text+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "reservation", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();
                Reservation res = new Reservation();
                this.Close();
                res.Show();

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
    }
}
