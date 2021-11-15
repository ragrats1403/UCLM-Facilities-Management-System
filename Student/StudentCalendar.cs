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

namespace Function_Hall_Reservation_System.Student
{
    public partial class StudentCalendar : Form
    {
        public string name = Form1.setfirstname + " " + Form1.setlastname;
        public StudentCalendar()
        {
            InitializeComponent();
        }

        private void StudentCalendar_Load(object sender, EventArgs e)
        {
            filldata();
            Checkapprove();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservation reserve = new Reservation();
            this.Visible = false;
            reserve.Show();

        }

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
            lblfullname.Text = Form1.setfullname;   
           // dataGridView1.Columns[2].Width = 108;
            Functions.Functions.gen = "Select fhreservation.eventname AS [Event Name],fhreservation.reserveddate AS [Date], Convert(varchar(20), CAST(fhreservation.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(fhreservation.timeend AS time ),0)AS [Time End], fhreservation.facilityname AS [Facility] from fhreservation where fhreservation.reservationstatus = 'Approved' UNION ALL SELECT nareservations.eventname AS [Event Name],nareservations.reserveddate AS [Date],Convert(varchar(20), CAST(nareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(nareservations.timeend AS time ),0)AS [Time End], nareservations.facilityname AS [Facility] from nareservations where nareservations.reservationstatus = 'Approved' UNION ALL Select oareservations.eventname AS [Event Name],oareservations.reserveddate AS [Date],Convert(varchar(20), CAST(oareservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(oareservations.timeend AS time ),0)AS [Time End], oareservations.facilityname AS [Facility] from oareservations where oareservations.reservationstatus = 'Approved' UNION ALL Select audreservations.eventname AS [Event Name],audreservations.reserveddate AS [Date],Convert(varchar(20), CAST(audreservations.timestart AS time ),0) AS [Time Start],Convert(varchar(20), CAST(audreservations.timeend AS time ),0)AS [Time End], audreservations.facilityname AS [Facility] from audreservations where audreservations.reservationstatus = 'Approved'";
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            StudentDashboard sd = new StudentDashboard();
            this.Close();
            sd.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Checkapprove()
        {
            int read;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select * from fhreservation where reservationstatus = 'Approved' and reservedby = '" + name + "' UNION ALL Select * from nareservations where reservationstatus = 'Approved' and reservedby = '" + name + "' UNION ALL Select * from oareservations where reservationstatus = 'Approved' and reservedby = '" + name + "' UNION ALL Select * from audreservations where reservationstatus = 'Approved' and reservedby = '" + name + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

                if (Functions.Functions.reader.HasRows)
                {
                    Functions.Functions.reader.Read();
                    read = Convert.ToInt32(Functions.Functions.reader["readstatus"]);

                    if (read == 0)
                    {

                        pbapprovenotif.Visible = true;


                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbapprovenotif_Click(object sender, EventArgs e)
        {
            int read = 0;
            String tempeventname;
            String tempdate;
            String tempfac;
            String facid;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select * from fhreservation where reservationstatus = 'Approved' and reservedby = '" + name + "' UNION ALL Select * from nareservations where reservationstatus = 'Approved' and reservedby = '" + name + "' UNION ALL Select * from oareservations where reservationstatus = 'Approved' and reservedby = '" + name + "' UNION ALL Select * from audreservations where reservationstatus = 'Approved' and reservedby = '" + name + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

                if (Functions.Functions.reader.HasRows)
                {
                    Functions.Functions.reader.Read();
                    read = Convert.ToInt32(Functions.Functions.reader["readstatus"]);
                    tempeventname = Functions.Functions.reader["eventname"].ToString();
                    tempdate = Functions.Functions.reader["reserveddate"].ToString();
                    tempfac = Functions.Functions.reader["facilityname"].ToString();
                    facid = Functions.Functions.reader["facilityid"].ToString();
                    Connection.Connection.conn.Close();


                    if (read == 0)
                    {

                        var gen = MessageBox.Show("Your reservation was approved!\nReservation Name and Date: " + tempeventname + " " + tempdate + "\nFacility: " + tempfac + "\nMark Notification as Read?", "Delete equipment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (gen == DialogResult.Yes)
                        {

                            Connection.Connection.DB();
                            Functions.Functions.gen = "UPDATE " + facid + " SET readstatus = 1 where reservationstatus = 'Approved' and reservedby = '" + name + "'";
                            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                            Functions.Functions.command.ExecuteNonQuery();
                            Connection.Connection.conn.Close();
                            pbapprovenotif.Visible = false;


                        }
                        else if (gen == DialogResult.No)
                        {

                            pbapprovenotif.Visible = true;
                        }



                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
