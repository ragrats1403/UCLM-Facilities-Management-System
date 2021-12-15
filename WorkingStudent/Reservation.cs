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

namespace Function_Hall_Reservation_System.WorkingStudent
{
    public partial class Reservation : Form
    {
        public static string idname;
        public string loadedid;
        public static int loadedcount = 0;
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
        public Reservation()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }
        public void cbstyleset()
        {

            facilitycb.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            cbstyleset();
            lblfullname.Text = Form1.setfullname;
        }
      /*  public void Filldata()
        {
            //Functions.Functions.gen = "Select events.eventid AS [EVENT ID], events.eventname AS [EVENT NAME], events.eventprice AS [Event Price],events.dateregistered AS [DATE REGISTERED] from events";
            //Functions.Functions.gen = "Select * from reservation where studentid = '" + Form1.setstudentid + "'";
            Functions.Functions.gen = "Select * from fhreservation where reservationstatus = 'Pending'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }*/
        public void Fillfhreservationdata()
        {
            idname = "fhreservation";
            Functions.Functions.gen = "Select * from fhreservation where reserveddate >= '" + DateTime.Now + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Fillaudreservationdata()
        {
            idname = "audreservation";
            Functions.Functions.gen = "Select * from audreservations where reserveddate > '" + DateTime.Now + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Fillnareservationdata()
        {
            idname = "nareservations";
            Functions.Functions.gen = "Select * from nareservations where reserveddate > '" + DateTime.Now + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Filloareservationdata()
        {
            idname = "oareservations";
            Functions.Functions.gen = "Select * from oareservations where reserveddate > '" + DateTime.Now + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void filldata(String id)
        {
            Functions.Functions.gen = "Select eventname,reservedby,reservationstatus,datereserved,checkedby,approvedby,reservedequipments,timestart,month,timeend,reserveddate,facilityname from reservations where reserveddate > '" + DateTime.Now + "' and facilityname = '"+id+"'";
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
            string timestart = "";
            string timeend = "";
            string reserveddate = "";
            try
            {
                
                txteventname.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtreservedby.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                cmbstatus.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                txtdatereserved.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txtcheckedby.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                txtapprovedby.Text = dataGridView1[5, e.RowIndex].Value.ToString();
               
                txtreservedequipments.Text = dataGridView1[6, e.RowIndex].Value.ToString();
               
                timestart = dataGridView1[7, e.RowIndex].Value.ToString();
                dtpTimeStart.Format = DateTimePickerFormat.Time;
                dtpTimeStart.Value = Convert.ToDateTime(timestart);

                reserveddate = dataGridView1[10, e.RowIndex].Value.ToString();
                dtpReservedDate.Format = DateTimePickerFormat.Short;
                dtpReservedDate.Value = Convert.ToDateTime(reserveddate);
                timeend = dataGridView1[9, e.RowIndex].Value.ToString();
                dtpTimeEnd.Format = DateTimePickerFormat.Time;
                dtpTimeEnd.Value = Convert.ToDateTime(timeend);
                txtfacilityname.Text = dataGridView1[11, e.RowIndex].Value.ToString();
                

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

        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");
                    filldata("Function Hall");
                }
                else if (facilitycb.SelectedItem.ToString() == "Auditorium")
                {

                    //MessageBox.Show("Debug Line for Auditorium Executed");
                    filldata("Auditorium");
                }
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    filldata("New AVR");
                }

                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    filldata("Old AVR");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Boolean checkdateconflict(DateTime dt)
        {
            int count = 0;
            bool confirm = false;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select count(" + loadedid + ".reserveddate) from " + loadedid + " where reserveddate = '" + dt + "' and reservationstatus = 'Approved'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    count = Functions.Functions.reader.GetInt32(0);

                }
                if (count == 0)
                {
                    confirm = false;
                }
                else
                {
                    confirm = true;
                }



                Connection.Connection.conn.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return confirm;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE "+loadedid+" SET reservationstatus='" + cmbstatus.Text +"',checkedby='"+Form1.setfullname+"' where eventname = '"+txteventname.Text+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "fhreservation", MessageBoxButtons.OK);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txttimerend_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
                    }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime datestart = dtpReservedDate.Value.Date + dtpTimeStart.Value.TimeOfDay;
            DateTime dateend = dtpReservedDate.Value.Date + dtpTimeEnd.Value.TimeOfDay;
           
            if (cmbstatus.Text == "Verified")
            {
                try
                {



                    if (checkdateconflict(dtpReservedDate.Value.Date) == true)
                    {
                        
                        Connection.Connection.DB();
                        Functions.Functions.gen = "Select count(*) from " + loadedid + " where '" + dtpTimeStart.Value + "' between timestart and timestart and reservationstatus = 'Approved' or '" + dtpTimeEnd.Value + "' between timestart and timeend and reservationstatus = 'Approved'and reservationstatus = 'Approved' or timestart between '" + datestart + "' and '" + dateend + "' and reservationstatus = 'Approved' or timeend between '" + dtpTimeStart.Value + "' and '" + dtpTimeEnd.Value + "' and reservationstatus = 'Approved'";

                        Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                        Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                        Functions.Functions.reader.Read();
                        
                        loadedcount = Functions.Functions.reader.GetInt32(0);


                        Connection.Connection.conn.Close();
                        if (loadedcount > 0)
                        {


                            MessageBox.Show("The Facility is reserved within that time! \nCheck Calendar of Activities for approved schedules. ");
                            
                        }
                        else
                        {
                            MessageBox.Show("No Conflits Found!");
                        }

                    }
                    else
                    {
                       
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmbstatus.Text == "Declined")
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WorkingStudent.Reservation re = new WorkingStudent.Reservation();
            this.Visible = false;
            re.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WorkingStudent.CalendarOfActivities ca = new WorkingStudent.CalendarOfActivities();
            this.Visible = false;
            ca.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button4_Click_2(object sender, EventArgs e)
        {
            WorkingStudent.Equipments eq = new WorkingStudent.Equipments();
            this.Visible = false;
            eq.Show();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            WorkingStudent.CalendarOfActivities ca = new WorkingStudent.CalendarOfActivities();
            this.Visible = false;
            ca.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            WorkingStudent.Reservation re = new WorkingStudent.Reservation();
            this.Visible = false;
            re.Show();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            WorkingStudent.GenerateReports gr = new WorkingStudent.GenerateReports();
            this.Visible = false;
            gr.Show();
        }
    }
}
