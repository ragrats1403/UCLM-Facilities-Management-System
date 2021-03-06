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

namespace Function_Hall_Reservation_System.Student
{
    public partial class StudentDashboard : Form
    {
        private static int count = 0;
        //public static string idname;
        public string loadedid;
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

        public StudentDashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            //filldata();
            Checkapprove();
            lblfullname.Text = name;
            loadedid = "reservations";
            reservationtotalcount(loadedid);
            approvedtotalcount(loadedid);
            pendingtotalcount(loadedid);
        }


        public void notificationtab()
        {

        }
        public void reservationtotalcount(String idname)
        {
            
            Connection.Connection.DB();
            Functions.Functions.gen = "Select count(*) from "+idname+"";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
            while (Functions.Functions.reader.Read())
            {
                count = Functions.Functions.reader.GetInt32(0);
                lblreservationcount.Text = count.ToString();
            }
            Connection.Connection.conn.Close();
        }
        public void pendingtotalcount(String idname)
        {

            Connection.Connection.DB();
            Functions.Functions.gen = "select count(*) from "+idname+" where "+idname+".reservationstatus = 'Pending'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
            while (Functions.Functions.reader.Read())
            {
                count = Functions.Functions.reader.GetInt32(0);
                lblpendingcount.Text = count.ToString();
            }
            Connection.Connection.conn.Close();
        }
        public void approvedtotalcount(String idname)
        {

            Connection.Connection.DB();
            Functions.Functions.gen = "select count(*) from "+idname+" where "+idname+".reservationstatus = 'Approved'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
            while (Functions.Functions.reader.Read())
            {
                count = Functions.Functions.reader.GetInt32(0);
                lblapprovedcount.Text = count.ToString();
            }
            Connection.Connection.conn.Close();
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

      /*  public void filldata()
        {
            lblfullname.Text = Form1.setfullname;   
           // dataGridView1.Columns[2].Width = 108;
            Functions.Functions.gen = "Select reservation.eventname as [Event Name],reservation.reserveddate as [Date],reservation.timestart as [Time Start], reservation.timeend as [Time End] from reservation where reservation.reservationstatus = 'Approved'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
            
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 110;
        }*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StudentDashboard sd = new StudentDashboard();
            this.Visible = false;
            sd.Show();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            StudentCalendar calendar = new StudentCalendar();
            this.Visible = false;
            calendar.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StudentCalendar calendar = new StudentCalendar();
            this.Visible = false;
            calendar.Show();
        }
        public void Checkapprove()
        {
            int read;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select * from reservations where reservationstatus = 'Approved' and studentid = '" + Form1.setstudentid + "'";
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
            
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select * from reservations where reservationstatus = 'Approved' and studentid = '" + Form1.setstudentid + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

                if (Functions.Functions.reader.HasRows)
                {
                    Functions.Functions.reader.Read();
                    read = Convert.ToInt32(Functions.Functions.reader["readstatus"]);
                    tempeventname = Functions.Functions.reader["eventname"].ToString();
                    tempdate = Functions.Functions.reader["reserveddate"].ToString();
                    tempfac = Functions.Functions.reader["facilityname"].ToString();
                    //facid = Functions.Functions.reader["facilityid"].ToString();
                    Connection.Connection.conn.Close();

                    DateTime dt = Convert.ToDateTime(tempdate);


                    if (read == 0)
                    {

                        var gen = MessageBox.Show("Your reservation was approved!\nReservation Name: " + tempeventname + "\nReservation Date: " + dt.ToShortDateString() + "\nFacility: " + tempfac + "\nMark Notification as Read?", "Delete equipment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (gen == DialogResult.Yes)
                        {

                            Connection.Connection.DB();
                            Functions.Functions.gen = "UPDATE reservations SET readstatus = 1 where reservationstatus = 'Approved' and reservedby = '" + name + "'";
                            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                            Functions.Functions.command.ExecuteNonQuery();
                            Connection.Connection.conn.Close();
                            pbapprovenotif.Visible = false;
                            Checkapprove();

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Reservation reserve = new Reservation();
            this.Visible = false;
            reserve.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            StudentCalendar calendar = new StudentCalendar();
            this.Visible = false;
            calendar.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            StudentDashboard sd = new StudentDashboard();
            this.Close();
            sd.Show();
        }
    }
    }

