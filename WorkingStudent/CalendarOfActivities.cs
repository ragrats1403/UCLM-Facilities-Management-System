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
    public partial class CalendarOfActivities : Form
    {
        public static string idname;
        public string loadedid;
        public CalendarOfActivities()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filldata();
            lblfullname.Text = Form1.setfullname;
        }

        
        

        public void filldata()
        {
            lblfullname.Text = Form1.setfullname;
            // dataGridView1.Columns[2].Width = 108;
            Functions.Functions.gen = "Select fhreservation.eventname AS [Event Name], Convert(varchar(20), CAST(fhreservation.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(fhreservation.timeend AS time ),0)AS [Time End], fhreservation.facilityname AS [Facility] from fhreservation where fhreservation.reservationstatus = 'Approved' UNION ALL SELECT nareservations.eventname AS [Event Name],Convert(varchar(20), CAST(nareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(nareservations.timeend AS time ),0)AS [Time End], nareservations.facilityname AS [Facility] from nareservations where nareservations.reservationstatus = 'Approved' UNION ALL Select oareservations.eventname AS [Event Name],Convert(varchar(20), CAST(oareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(oareservations.timeend AS time ),0)AS [Time End], oareservations.facilityname AS [Facility] from oareservations where oareservations.reservationstatus = 'Approved' UNION ALL Select audreservations.eventname AS [Event Name],Convert(varchar(20), CAST(audreservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(audreservations.timeend AS time ),0)AS [Time End], audreservations.facilityname AS [Facility] from audreservations where audreservations.reservationstatus = 'Approved'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 110;
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
