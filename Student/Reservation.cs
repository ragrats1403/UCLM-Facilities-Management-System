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
    public partial class Reservation : Form
    {
        public static string status = "";
        public static string equipmentname = "";
        public static string tempdate = "";
        public static string temptimestart = "";
        public static string temptimeend = "";
        private String loadedid;

        public Reservation()
        {
            InitializeComponent();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

            fillstudnameid();
            filldata();
            timestart();
            timeend();
            date();
            lblfullname.Text = Form1.setfullname;
            chkboxfill();
            cbstyleset();
        }
        public void chkboxfill()
        {
            Connection.Connection.DB();
            Functions.Functions.gen = "Select equipmentname from fhequipments where equipmentstatus = 'Available'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
            while (Functions.Functions.reader.Read())
            {
                string fill = Functions.Functions.reader.GetString(0);
                checkedListBox1.Items.Add(fill);
            }


            Connection.Connection.conn.Close();
        }
        public void timestart()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
        }
        public void date()
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
        }
        public void timeend()
        {
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.ShowUpDown = true;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentCalendar calendar = new StudentCalendar();
            this.Visible = false;
            calendar.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnrequest_Click(object sender, EventArgs e)
        {
            var name = Form1.setfirstname + " " + Form1.setlastname;

            string month = "";
            string dateval = "";


            string timestart = "";
            string timeend = "";

            var selectedequip = new List<string>();
            try
            {

                foreach (var sel in checkedListBox1.CheckedItems)
                {
                    selectedequip.Add(sel.ToString());
                }
                string allequip = string.Join(", ", selectedequip);
                month = dateTimePicker2.Value.ToString("MMMM");

                try
                {
                    Connection.Connection.DB();
                    Functions.Functions.gen = "Select * from fhreservation";
                    Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                    Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                    Functions.Functions.reader.Read();

                    dateval = dateTimePicker2.Value.ToString("MM/dd/yyyy");
                    timestart = dateTimePicker1.Value.ToString("hh:mm:tt");
                    timeend = dateTimePicker3.Value.ToString("hh:mm:tt");
                    Connection.Connection.conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }





                Connection.Connection.DB();
                Functions.Functions.gen = "Insert Into " + loadedid + "(eventname,reservedby,reservationstatus,datereserved,checkedby,studentid,studentname,reservedequipments,approvedby,timestart,month,timeend,reserveddate)values('" + txtEventname.Text + "','" + name + "','Pending','" + DateTime.Now.ToString() + "','N/A','" + txtStudentid.Text + "','" + txtStudentName.Text + "','" + allequip + "','N/A','" + timestart + "','" + month + " ','" + timeend + "','" + dateval + "')";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);

                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Requested for Reservation!", "reservation", MessageBoxButtons.OK);

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
        public void filldata()
        {
            Functions.Functions.gen = "Select * from fhreservation where studentid = '" + Form1.setstudentid + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }

        public void fillstudnameid()
        {
            var name = Form1.setfirstname + " " + Form1.setlastname;
            var id = Form1.setstudentid;
            txtStudentName.Text = name;
            txtStudentid.Text = id;

        }




        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void chkProjector_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }
        public void cbstyleset()
        {

            facilitycb.DropDownStyle = ComboBoxStyle.DropDownList;
            facilitycb2.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");|
                    loadedid = "fhreservation";

                }
                else if (facilitycb.SelectedItem.ToString() == "Auditorium")
                {

                    //MessageBox.Show("Debug Line for Auditorium Executed");
                    loadedid = "audreservations";

                }
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    loadedid = "nareservations";

                }

                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    loadedid = "oareservations";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            StudentDashboard sd = new StudentDashboard();
            this.Visible = false;
            sd.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Reservation re = new Reservation();
            this.Visible = false;
            re.Show();
        }
    }

}
