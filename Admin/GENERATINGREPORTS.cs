using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Function_Hall_Reservation_System.Admin
{
    public partial class GENERATINGREPORTS : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public GENERATINGREPORTS()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void GENERATINGREPORTS_Load(object sender, EventArgs e)
        {
            lblfullname.Text = Form1.setfullname;

            Filldata();
        }




        public void Filldata()
        {
            Functions.Functions.gen = "Select eventname as [Event Name], reservedby as [Reserved By], checkedby as [Checked By], approvedby as [Approved By], reservedequipments as [Reserved Equipments], datereserved as [Date Reserved], reserveddate as [Reserved Date], timestart as [Time Start], timeend As [Time End],facilityname as [Facility Name] from reservations where reservationstatus = 'Approved'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }






        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

        {
            
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(0, 0));
           
        }





        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GENERATINGREPORTS gen = new GENERATINGREPORTS();
            this.Visible = false;
            gen.Show();
        }

        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendarOfActivities coa = new CalendarOfActivities();
            this.Visible = false;
            coa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewReservationList vrl = new ViewReservationList();
            this.Visible = false;
            vrl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ACCOUNTS acc = new ACCOUNTS();
            this.Visible = false;
            acc.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Equipment eq = new Equipment();
            this.Visible = false;
            eq.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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
            richTextBox1.Clear();
            try
            {


                eventnameTextBox.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                reservedbyTextBox.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                checkedbyTextBox.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                approvedbyTextBox.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                reservedequipmentsTextBox.Text = dataGridView1[4, e.RowIndex].Value.ToString();

                datereserved = dataGridView1[5, e.RowIndex].Value.ToString();
                dtpdatereserved.Format = DateTimePickerFormat.Short;
                dtpdatereserved.Value = Convert.ToDateTime(datereserved);

                reserveddate = dataGridView1[6, e.RowIndex].Value.ToString();
                dtpreserveddate.Format = DateTimePickerFormat.Short;
                dtpreserveddate.Value = Convert.ToDateTime(reserveddate);
                timestart = dataGridView1[7, e.RowIndex].Value.ToString();
                dtptimestart.Format = DateTimePickerFormat.Time;
                dtptimestart.Value = Convert.ToDateTime(timestart);

                timeend = dataGridView1[8, e.RowIndex].Value.ToString();
                dtptimeend.Format = DateTimePickerFormat.Time;
                dtptimeend.Value = Convert.ToDateTime(timeend);
                txtFacility.Text = dataGridView1[9, e.RowIndex].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
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
                richTextBox1.AppendText("    User ID:" + "\t" + "\t" + "\t" + "\t" + "\t"  + useridTextBox.Text + "\n");
                richTextBox1.AppendText("    First Name:" + "\t" + "\t" + "\t" + "\t" + "\t" + firstnameTextBox.Text + "\n");
                richTextBox1.AppendText("    Last Name:" + "\t" + "\t" + "\t" + "\t" + "\t" + lastnameTextBox.Text + "\n");
                richTextBox1.AppendText("    Full Name:" + "\t" + "\t" + "\t" + "\t" + "\t" + studentnameTextBox.Text + "\n");
                richTextBox1.AppendText("    Age:" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + ageTextBox.Text + "\n");
                richTextBox1.AppendText("    Status:" + "\t" + "\t" + "\t" + "\t" + "\t" + statusTextBox.Text + "\n");
                richTextBox1.AppendText("    Date Registered:" + "\t" + "\t" + "\t" + "\t"  + txtdateregistered.Text + "\n");
                richTextBox1.AppendText("    Student ID:" + "\t" + "\t" + "\t" + "\t" + "\t" + studentidTextBox.Text + "\n");
                //richTextBox1.AppendText("Password:" + "\t" + "\t" + "\t" + "\t" + "\t" + passwordTextBox.Text + "\n");
                richTextBox1.AppendText("    Gender:" + "\t" + "\t" + "\t" + "\t" + "\t"  + txtgender.Text + "\n");
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

        private void button10_Click_1(object sender, EventArgs e)
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

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateregisteredLabel_Click(object sender, EventArgs e)
        {

        }

        private void reservedequipmentsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttimestart_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txttimeend_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtreservedate_TextChanged(object sender, EventArgs e)
        {

        }

        private void datereserved_TextChanged(object sender, EventArgs e)
        {

        }

        private void reservationidLabel_Click(object sender, EventArgs e)
        {

        }

        private void reservationidTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void eventnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void reservedbyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void reservationstatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void reservationstatusTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void datereservedLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkedbyLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkedbyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void approvedbyLabel_Click(object sender, EventArgs e)
        {

        }

        private void approvedbyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void reservedequipmentsLabel_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
