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

namespace Function_Hall_Reservation_System.Admin
{
    public partial class ViewReservationList : Form
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

        public ViewReservationList()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
       

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstudentid_TextChanged(object sender, EventArgs e)
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

                this.tabControl1.SelectedIndex = 1;
                lbldate.Visible = true;
                //lblroleid.Visible = true;
                txtapprovedby.Visible = true;
                txtdatereserved.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE reservation SET reservationstatus='" + cmbstatus.Text + "',checkedby='" + Form1.setfullname + "' where eventname = '" + txteventname.Text + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                /*Functions.Functions.gen = "UPDATE fhreservation SET fhreservationstatus='" + cmbstatus.Text + "',approvedby = '"+Form1.setfullname+"' where reservationid= '"+txtreservationid.Text+"'";*/
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "fhreservation", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();
                ViewReservationList viewres = new ViewReservationList();
                this.Close();
                viewres.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewReservationList_Load(object sender, EventArgs e)
        {
            lblfullname.Text = Form1.setfullname;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        public void filldata(String id)
        {
            Functions.Functions.gen = "Select eventname,reservedby,reservationstatus,datereserved,checkedby,approvedby,reservedequipments,timestart,month,timeend,reserveddate,facilityname from reservations where reserveddate > '" + DateTime.Now + "' and facilityname = '" + id + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }
        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(facilitycb.SelectedItem.ToString() == "Function Hall")
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
                    }
        public Boolean checkdateconflict(DateTime dt)
        {
            int count = 0;
            bool confirm = false;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select count(reservations.reserveddate) from reservations where reserveddate = '" + dt + "' and reservationstatus = 'Approved' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
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

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                DateTime datestart = dtpReservedDate.Value.Date + dtpTimeStart.Value.TimeOfDay;
                DateTime dateend = dtpReservedDate.Value.Date + dtpTimeEnd.Value.TimeOfDay;
            
                if (cmbstatus.Text == "Approved")
                {
                    try
                    {



                        if (checkdateconflict(dtpReservedDate.Value.Date) == true)
                        {

                            Connection.Connection.DB();
                            Functions.Functions.gen = "Select COUNT(*) from reservations where '" + datestart + "' between timestart and timestart and reservationstatus = 'Approved' or '" + dateend + "' between timestart and timeend and reservationstatus = 'Approved' and reservationstatus = 'Approved' or timestart between '" + datestart + "' and '" + dateend + "' and reservationstatus = 'Approved' or timeend between '" + datestart + "' and '" + dateend + "' and reservationstatus = 'Approved'";

                            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                            Functions.Functions.reader.Read();

                            loadedcount = Functions.Functions.reader.GetInt32(0);


                            Connection.Connection.conn.Close();
                            if (loadedcount > 0)
                            {


                                MessageBox.Show("Someone is using the facility within that time! \nCheck Calendar of Activities for approved schedules. ");

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }


