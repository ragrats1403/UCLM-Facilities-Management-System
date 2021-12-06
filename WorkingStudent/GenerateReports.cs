using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Function_Hall_Reservation_System.WorkingStudent
{
    public partial class GenerateReports : Form
    {
        public GenerateReports()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filldata();
            //Filldata2();
            lblfullname.Text = Form1.setfullname;
        }
        public void Filldata()
        {
            Functions.Functions.gen = "Select reservationid AS [Reservation ID], eventname as [Event Name], reservedby as [Reserved By], checkedby as [Checked By], approvedby as [Approved By], reservedequipments as [Reserved Equipments], datereserved as [Date Reserved], reserveddate as [Reserved Date], timestart as [Time Start], timeend As [Time End],facilityname as [Facility Name] from fhreservation where reservationstatus = 'Approved' UNION ALL Select reservationid AS [Reservation ID], eventname as [Event Name], reservedby as [Reserved By], checkedby as [Checked By], approvedby as [Approved By], reservedequipments as [Reserved Equipments], datereserved as [Date Reserved], reserveddate as [Reserved Date], timestart as [Time Start], timeend As [Time End],facilityname as [Facility Name] from audreservations where reservationstatus = 'Approved' UNION ALL Select reservationid AS [Reservation ID], eventname as [Event Name], reservedby as [Reserved By], checkedby as [Checked By], approvedby as [Approved By], reservedequipments as [Reserved Equipments], datereserved as [Date Reserved], reserveddate as [Reserved Date], timestart as [Time Start], timeend As [Time End],facilityname as [Facility Name] from oareservations where reservationstatus = 'Approved' UNION ALL Select reservationid AS [Reservation ID], eventname as [Event Name], reservedby as [Reserved By], checkedby as [Checked By], approvedby as [Approved By], reservedequipments as [Reserved Equipments], datereserved as [Date Reserved], reserveddate as [Reserved Date], timestart as [Time Start], timeend As [Time End],facilityname as [Facility Name] from nareservations where reservationstatus = 'Approved'";
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            this.Visible = false;
            reservation.Show();
        }

        

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.ShowDialog();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            try
            {
                
                e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(0, 0));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }


        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {


                /*richTextBox1.Clear();
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");


                richTextBox1.AppendText("       " + " Student Details " + "\n");
                richTextBox1.AppendText("    ⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻" + "\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("    User ID:" + "\t" + "\t" + "\t" + "\t" + "\t" + useridTextBox.Text + "\n");
                richTextBox1.AppendText("    First Name:" + "\t" + "\t" + "\t" + "\t" + "\t" + firstnameTextBox.Text + "\n");
                richTextBox1.AppendText("    Last Name:" + "\t" + "\t" + "\t" + "\t" + "\t" + lastnameTextBox.Text + "\n");
                richTextBox1.AppendText("    Full Name:" + "\t" + "\t" + "\t" + "\t" + "\t" + studentnameTextBox.Text + "\n");
                richTextBox1.AppendText("    Age:" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + ageTextBox.Text + "\n");
                richTextBox1.AppendText("    Status:" + "\t" + "\t" + "\t" + "\t" + "\t" + statusTextBox.Text + "\n");
                richTextBox1.AppendText("    Date Registered:" + "\t" + "\t" + "\t" + "\t" + txtdateregistered.Text + "\n");
                richTextBox1.AppendText("    Student ID:" + "\t" + "\t" + "\t" + "\t" + "\t" + studentidTextBox.Text + "\n");
                //richTextBox1.AppendText("Password:" + "\t" + "\t" + "\t" + "\t" + "\t" + passwordTextBox.Text + "\n");
                richTextBox1.AppendText("    Gender:" + "\t" + "\t" + "\t" + "\t" + "\t" + txtgender.Text + "\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("\n");*/

                richTextBox1.AppendText("       " + "Reservation Details" + "\n");
                richTextBox1.AppendText("    ⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻⎻" + "\n");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("    Event Name:" + "\t" + "\t" + "\t" + "\t" + "\t" + eventnameTextBox.Text + "\n");
                richTextBox1.AppendText("    Time Start:" + "\t" + "\t" + "\t" + "\t" + "\t" + dtptimestart.Value.ToShortTimeString() + "\n");
                richTextBox1.AppendText("    Time End:" + "\t" + "\t" + "\t" + "\t" + "\t" + dtptimeend.Value.ToShortTimeString() + "\n");
                richTextBox1.AppendText("    Venue:" + "\t" + "\t" + "\t" + "\t" + "\t" + txtFacility.Text + "\n");
                richTextBox1.AppendText("    Reserved By:" + "\t" + "\t" + "\t" + "\t" + "\t" + reservedbyTextBox.Text + "\n");
                richTextBox1.AppendText("    Date Reserved:" + "\t" + "\t" + "\t" + "\t" + dtpdatereserved.Value.ToShortDateString() + "\n");
                richTextBox1.AppendText("    Reserved Date:" + "\t" + "\t" + "\t" + "\t" + dtpreserveddate.Value.ToShortDateString() + "\n");
                richTextBox1.AppendText("    Reserved Equipments:" + "\t" + "\t" + "\t" + "\t" + reservedequipmentsTextBox.Text + "\n");
                richTextBox1.AppendText("    Checked By:" + "\t" + "\t" + "\t" + "\t" + "\t" + checkedbyTextBox.Text + "\n");
                richTextBox1.AppendText("    Approved By:" + "\t" + "\t" + "\t" + "\t" + "\t" + approvedbyTextBox.Text + "\n");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string timestart = "";
            string timeend = "";
            string reserveddate = "";
            string datereserved = "";

            try
            {

                reservationidTextBox.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                eventnameTextBox.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                reservedbyTextBox.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                checkedbyTextBox.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                approvedbyTextBox.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                reservedequipmentsTextBox.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                
                datereserved = dataGridView1[8, e.RowIndex].Value.ToString();
                dtpdatereserved.Format = DateTimePickerFormat.Short;
                dtpdatereserved.Value = Convert.ToDateTime(datereserved);
                
                reserveddate = dataGridView1[8, e.RowIndex].Value.ToString();
                dtpreserveddate.Format = DateTimePickerFormat.Short;
                dtpreserveddate.Value = Convert.ToDateTime(reserveddate);
                timestart = dataGridView1[8, e.RowIndex].Value.ToString();
                dtptimestart.Format = DateTimePickerFormat.Time;
                dtptimestart.Value = Convert.ToDateTime(timestart);
                
                timeend = dataGridView1[9, e.RowIndex].Value.ToString();
                dtptimeend.Format = DateTimePickerFormat.Time;
                dtptimeend.Value = Convert.ToDateTime(timeend);
                txtFacility.Text = dataGridView1[10, e.RowIndex].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eventnameLabel_Click(object sender, EventArgs e)
        {

        }

        private void reservedbyLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WorkingStudent.CalendarOfActivities ca = new WorkingStudent.CalendarOfActivities();
            this.Visible = false;
            ca.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorkingStudent.Reservation re = new WorkingStudent.Reservation();
            this.Visible = false;
            re.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorkingStudent.Equipments eq = new WorkingStudent.Equipments();
            this.Visible = false;
            eq.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            WorkingStudent.GenerateReports gr = new WorkingStudent.GenerateReports();
            this.Visible = false;
            gr.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            GenerateReports report = new GenerateReports();
            this.Visible = false;
            report.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            CalendarOfActivities calendar = new CalendarOfActivities();
            this.Visible = false;
            calendar.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            this.Visible = false;
            reservation.Show();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            Equipments equipments = new Equipments();
            this.Visible = false;
            equipments.Show();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }
    }
}
