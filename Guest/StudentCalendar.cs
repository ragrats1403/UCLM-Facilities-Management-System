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
using System.Runtime.InteropServices;

namespace Function_Hall_Reservation_System.Guest
{
    public partial class StudentCalendar : Form
    {
        public string name = Form1.setfirstname + " " + Form1.setlastname;
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
        public StudentCalendar()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void StudentCalendar_Load(object sender, EventArgs e)
        {
            filldata();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            Reservation reserve = new Reservation();
            this.Visible = false;
            reserve.Show();
        }*/

        private void button4_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        public void filldata()
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            Functions.Functions.gen = "Select fhreservation.eventname AS [Event Name],FORMAT(fhreservation.reserveddate, 'MM/dd')AS [Date(MM/dd)], Convert(varchar(20), CAST(fhreservation.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(fhreservation.timeend AS time ),0)AS [Time End], fhreservation.facilityname AS [Facility] from fhreservation where reserveddate > '" + dt + "' and fhreservation.reservationstatus = 'Approved' UNION ALL SELECT nareservations.eventname AS [Event Name],FORMAT(nareservations.reserveddate, 'MM/dd')AS [Date(MM/dd)],Convert(varchar(20), CAST(nareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(nareservations.timeend AS time ),0)AS [Time End], nareservations.facilityname AS [Facility] from nareservations where reserveddate > '" + dt + "' and nareservations.reservationstatus = 'Approved' UNION ALL Select oareservations.eventname AS [Event Name],FORMAT(oareservations.reserveddate, 'MM/dd')AS [Date(MM/dd)],Convert(varchar(20), CAST(oareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(oareservations.timeend AS time ),0)AS [Time End], oareservations.facilityname AS [Facility] from oareservations where reserveddate > '" + dt + "' and oareservations.reservationstatus = 'Approved' UNION ALL Select audreservations.eventname AS [Event Name],FORMAT(audreservations.reserveddate, 'MM/dd')AS [Date(MM/dd)],Convert(varchar(20), CAST(audreservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(audreservations.timeend AS time ),0)AS [Time End], audreservations.facilityname AS [Facility] from audreservations where reserveddate > '" + dt + "' and audreservations.reservationstatus = 'Approved'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
            
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 110;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentCalendar calendar = new StudentCalendar();
            this.Visible = false;
            calendar.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        /*private void button4_Click_1(object sender, EventArgs e)
        {
            StudentDashboard sd = new StudentDashboard();
            this.Close();
            sd.Show();
        }*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

       
            

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblfullname_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
