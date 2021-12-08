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
    public partial class CalendarOfActivities : Form
    {
        public static string idname;
        public string loadedid;
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
        public CalendarOfActivities()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


        }

        public void filldata()
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            lblfullname.Text = Form1.setfullname;
            Functions.Functions.gen = "Select fhreservation.eventname AS [Event Name],FORMAT(fhreservation.reserveddate, 'MM/dd')AS [Date(MM/dd)], Convert(varchar(20), CAST(fhreservation.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(fhreservation.timeend AS time ),0)AS [Time End], fhreservation.facilityname AS [Facility] from fhreservation where reserveddate > '" + dt + "' and fhreservation.reservationstatus = 'Approved' UNION ALL SELECT nareservations.eventname AS [Event Name],FORMAT(nareservations.reserveddate, 'MM/dd')AS [Date(MM/dd)],Convert(varchar(20), CAST(nareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(nareservations.timeend AS time ),0)AS [Time End], nareservations.facilityname AS [Facility] from nareservations where reserveddate > '" + dt + "' and nareservations.reservationstatus = 'Approved' UNION ALL Select oareservations.eventname AS [Event Name],FORMAT(oareservations.reserveddate, 'MM/dd')AS [Date(MM/dd)],Convert(varchar(20), CAST(oareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(oareservations.timeend AS time ),0)AS [Time End], oareservations.facilityname AS [Facility] from oareservations where reserveddate > '" + dt + "' and oareservations.reservationstatus = 'Approved' UNION ALL Select audreservations.eventname AS [Event Name],FORMAT(audreservations.reserveddate, 'MM/dd')AS [Date(MM/dd)],Convert(varchar(20), CAST(audreservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(audreservations.timeend AS time ),0)AS [Time End], audreservations.facilityname AS [Facility] from audreservations where reserveddate > '" + dt + "' and audreservations.reservationstatus = 'Approved'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 110;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            GENERATINGREPORTS gen = new GENERATINGREPORTS();
            this.Visible = false;
            gen.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        

        private void CalendarOfActivities_Load(object sender, EventArgs e)
        {
            filldata();
            lblfullname.Text = Form1.setfullname;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
