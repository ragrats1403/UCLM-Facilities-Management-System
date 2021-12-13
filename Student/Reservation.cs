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
    public partial class Reservation : Form
    {
        public static string status = "";
        public static string equipmentname = "";
        public static string tempdate = "";
        public static string temptimestart = "";
        public static string temptimeend = "";
        public int count = 0;
        public String loadedid = "";
        public static int availableqty;
        public static string loadedeqid = "";
        public String loadedeq;
        public string dateval = "";
        public static int loadedcount = 0;
        public string newval = "";
        public string cbval = "";
        public static string name = Form1.setfullname;
        public static string setfacilityname = "";
        public static string seteventname = "";


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
        public String getfacilityname()
        {
            return setfacilityname;
        }

        public Reservation()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public Boolean checkdateconflict(DateTime dt)
        {
            int count = 0;
            bool confirm = false;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select count(reservations.reserveddate) from reservations where reserveddate = '" + dt + "' and reservationstatus = 'Approved' and facilityname = '"+facilitycb.SelectedItem.ToString()+"'";
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

                //MessageBox.Show(""+count);

                Connection.Connection.conn.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return confirm;
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

            fillstudnameid();

            timestart();
            timeend();
            date();
            lblfullname.Text = Form1.setfullname;
            //chkboxfill();
            cbstyleset();
            //filltxtbox();
            //dateTimePicker1.CustomFormat = "YYYY-MM-DD hh:mm:ss";
            //dateTimePicker3.Format = DateTimePickerFormat.Time;
            Checkapprove();


        }
        public void eqfill(String id)
        {
            
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.equipmentname from equipments where facilityname = '"+facilitycb.SelectedItem.ToString()+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

                while (Functions.Functions.reader.Read())
                {
                    cmbeq1.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq2.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq3.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq4.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq5.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq6.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq7.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq8.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq9.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq10.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq11.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq12.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                }
                if (cmbeq1.Items.Count == 1)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = false;
                    cmbeq3.Visible = false;
                    cmbeq4.Visible = false;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = false;
                    lbleq3.Visible = false;
                    lbleq4.Visible = false;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    textBox3.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Visible = true;

                }
                if (cmbeq1.Items.Count == 2)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = false;
                    cmbeq4.Visible = false;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = false;
                    lbleq4.Visible = false;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    textBox3.Visible = false;
                    textBox2.Visible = true;
                    textBox1.Visible = true;

                }
                if (cmbeq1.Items.Count == 3)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = false;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = false;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 4)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 5)
                {
                    
                        cmbeq1.Visible = true;
                        cmbeq2.Visible = true;
                        cmbeq3.Visible = true;
                        cmbeq4.Visible = true;
                        cmbeq5.Visible = true;
                        cmbeq6.Visible = false;
                        cmbeq7.Visible = false;
                        cmbeq8.Visible = false;
                        cmbeq9.Visible = false;
                        cmbeq10.Visible = false;
                        cmbeq11.Visible = false;
                        cmbeq12.Visible = false;

                        lbleq1.Visible = true;
                        lbleq2.Visible = true;
                        lbleq3.Visible = true;
                        lbleq4.Visible = true;
                        lbleq5.Visible = true;
                        lbleq6.Visible = false;
                        lbleq7.Visible = false;
                        lbleq8.Visible = false;
                        lbleq9.Visible = false;
                        lbleq10.Visible = false;
                        lbleq11.Visible = false;
                        lbleq12.Visible = false;

                        textBox12.Visible = false;
                        textBox11.Visible = false;
                        textBox10.Visible = false;
                        textBox9.Visible = false;
                        textBox8.Visible = false;
                        textBox7.Visible = false;
                        textBox6.Visible = false;
                        textBox5.Visible = true;
                        textBox4.Visible = true;
                        textBox3.Visible = true;
                        textBox2.Visible = true;
                        textBox1.Visible = true;

                }
                if (cmbeq1.Items.Count == 6)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 7)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 8)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 9)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 10)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = true;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = true;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 11)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = true;
                    cmbeq11.Visible = true;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = true;
                    lbleq11.Visible = true;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox8.Visible = true;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 11)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = true;
                    cmbeq11.Visible = true;
                    cmbeq12.Visible = true;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = true;
                    lbleq11.Visible = true;
                    lbleq12.Visible = true;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox8.Visible = true;
                    textBox7.Visible = true;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }


                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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




        public int ComputeDifference()
        {
            TimeSpan diff = DateTime.Now - dateTimePicker2.Value;
            int temp = diff.Days - 1;
            int days = temp * -1;
            return days;
        }

        
        private void btnrequest_Click(object sender, EventArgs e)
        {
            
            
            var list = new List<String>();
            var name = Form1.setfirstname + " " + Form1.setlastname;

            string month = "";

            string eqres1 = cmbeq1.Text.ToString() + "(" + textBox1.Text.ToString() + ")";
            string eqres2 = cmbeq2.Text.ToString() + "(" + textBox2.Text.ToString() + ")";
            string eqres3 = cmbeq3.Text.ToString() + "(" + textBox3.Text.ToString() + ")";
            string eqres4 = cmbeq4.Text.ToString() + "(" + textBox4.Text.ToString() + ")";
            string eqres5 = cmbeq5.Text.ToString() + "(" + textBox5.Text.ToString() + ")";
            string eqres6 = cmbeq6.Text.ToString() + "(" + textBox6.Text.ToString() + ")";
            string eqres7 = cmbeq7.Text.ToString() + "(" + textBox12.Text.ToString() + ")";
            string eqres8 = cmbeq8.Text.ToString() + "(" + textBox11.Text.ToString() + ")";
            string eqres9 = cmbeq9.Text.ToString() + "(" + textBox10.Text.ToString() + ")";
            string eqres10 = cmbeq10.Text.ToString() + "(" + textBox9.Text.ToString() + ")";
            string eqres11 = cmbeq11.Text.ToString() + "(" + textBox8.Text.ToString() + ")";
            string eqres12 = cmbeq12.Text.ToString() + "(" + textBox7.Text.ToString() + ")";
            var selectedequip = new List<string>();
            try
            {

                if (textBox1.Text != "")
                {
                    selectedequip.Add(eqres1);
                }
                if (textBox2.Text != "")
                {
                    selectedequip.Add(eqres2);
                }
                if (textBox3.Text != "")
                {
                    selectedequip.Add(eqres3);
                }
                if (textBox4.Text != "")
                {
                    selectedequip.Add(eqres4);
                }
                if (textBox5.Text != "")
                {
                    selectedequip.Add(eqres5);
                }
                if (textBox6.Text != "")
                {
                    selectedequip.Add(eqres6);
                }
                if (textBox12.Text != "")
                {
                    selectedequip.Add(eqres7);
                }
                if (textBox11.Text != "")
                {
                    selectedequip.Add(eqres8);
                }
                if (textBox10.Text != "")
                {
                    selectedequip.Add(eqres9);
                }
                if (textBox9.Text != "")
                {
                    selectedequip.Add(eqres10);
                }
                if (textBox8.Text != "")
                {
                    selectedequip.Add(eqres11);
                }
                if (textBox7.Text != "")
                {
                    selectedequip.Add(eqres12);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string allequip = string.Join(", ", selectedequip);






                month = dateTimePicker2.Value.ToString("MMMM");
                dateval = dateTimePicker2.Value.ToString("MM/dd/yyyy");

                if (ComputeDifference() < 4)
                {
                    MessageBox.Show("Please Note that you need to reserve 3 days before the desired reservation day\nReservation Day Count: " + ComputeDifference() + " Day(s) Away.");
                }
                else
                {
                    MessageBox.Show("Schedule is open");
                }


            try
            {

                DateTime datestart = dateTimePicker2.Value.Date + dateTimePicker1.Value.TimeOfDay;
                DateTime dateend = dateTimePicker2.Value.Date + dateTimePicker3.Value.TimeOfDay;
                

                if (checkdateconflict(dateTimePicker2.Value.Date) == true)
                {
                    int test = 0;


                    Connection.Connection.DB();
                    Functions.Functions.gen = "Select COUNT(*) from reservations where '"+datestart+"' between timestart and timestart and reservationstatus = 'Approved' or '"+dateend+"' between timestart and timeend and reservationstatus = 'Approved' and reservationstatus = 'Approved' or timestart between '"+datestart+"' and '"+dateend+"' and reservationstatus = 'Approved' or timeend between '"+datestart+"' and '"+dateend+"' and reservationstatus = 'Approved'";
                    Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                    Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                    Functions.Functions.reader.Read();

                    test = Functions.Functions.reader.GetInt32(0);

                    debugcount.Text = test.ToString();
                    Connection.Connection.conn.Close();
                    
                        if (test > 0)
                        {
                            

                            MessageBox.Show("Someone is using the facility within that time! \nCheck Calendar of Activities for approved schedules. ");
                        }
                        else
                        {
                            
                            Connection.Connection.DB();
                            Functions.Functions.gen = "Insert Into reservations (eventname,reservedby,reservationstatus,datereserved,checkedby,reservedequipments,approvedby,timestart,month,timeend,reserveddate,facilityname,readstatus,studentid)values('" + txtEventname.Text + "','" + name + "','Pending','" + DateTime.Now.ToShortDateString() + "','N/A','" + allequip + "','N/A','" + datestart + "','" + month + " ','" + dateend + "','" + dateTimePicker2.Value.Date + "','" + facilitycb.SelectedItem.ToString() + "',0,'"+ Form1.setstudentid + "')";
                            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);

                            Functions.Functions.command.ExecuteNonQuery();
                            MessageBox.Show("Successfully Requested for Reservation!", "reservation", MessageBoxButtons.OK);

                            Connection.Connection.conn.Close();
                            Reservation res = new Reservation();
                            this.Close();
                            res.Show();
                            
                        }

                    }
                    else
                    {
                        
                        MessageBox.Show("Reserving..");
                        Connection.Connection.DB();
                        Functions.Functions.gen = "Insert Into reservations (eventname,reservedby,reservationstatus,datereserved,checkedby,reservedequipments,approvedby,timestart,month,timeend,reserveddate,facilityname,readstatus,studentid)values('" + txtEventname.Text + "','" + name + "','Pending','" + DateTime.Now.ToShortDateString() + "','N/A','" + allequip + "','N/A','" + datestart + "','" + month + " ','" + dateend + "','" + dateTimePicker2.Value.Date + "','" + facilitycb.SelectedItem.ToString() +"',0,'"+Form1.setstudentid+"')";
                        Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);

                        Functions.Functions.command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Requested for Reservation!", "reservation", MessageBoxButtons.OK);

                        Connection.Connection.conn.Close();
                        Reservation res = new Reservation();
                        this.Close();
                        res.Show();
                        
                    }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }









            
            
        }
        public void filldata(String id)
        {
            Functions.Functions.gen = "Select * from reservations where studentid = '" + Form1.setstudentid + "' and facilityname = '"+id+"'";
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
            cmbeq1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq6.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq7.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq8.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq9.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq10.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq11.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq12.DropDownStyle = ComboBoxStyle.DropDownList;


        }
        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");|
                    setfacilityname = facilitycb.SelectedItem.ToString();
                    loadedid = "fhreservation";
                    loadedeq = "equipments";
                    cmbeq1.Items.Clear();
                    cmbeq2.Items.Clear();
                    cmbeq3.Items.Clear();
                    cmbeq4.Items.Clear();
                    cmbeq5.Items.Clear();
                    cmbeq6.Items.Clear();
                    cmbeq7.Items.Clear();
                    cmbeq8.Items.Clear();
                    cmbeq9.Items.Clear();
                    cmbeq10.Items.Clear();
                    cmbeq11.Items.Clear();
                    cmbeq12.Items.Clear();

                    eqfill(loadedeq);
                    lbleq1.Text = "";
                    lbleq2.Text = "";
                    lbleq3.Text = "";
                    lbleq4.Text = "";
                    lbleq5.Text = "";
                    lbleq6.Text = "";
                    lbleq7.Text = "";
                    lbleq8.Text = "";
                    lbleq9.Text = "";
                    lbleq10.Text = "";
                    lbleq11.Text = "";
                    lbleq12.Text = "";

                }
                else if (facilitycb.SelectedItem.ToString() == "Auditorium")
                {

                    //MessageBox.Show("Debug Line for Auditorium Executed");
                    loadedid = "audreservations";
                    loadedeq = "equipments";
                    setfacilityname = facilitycb.SelectedItem.ToString();
                    cmbeq1.Items.Clear();
                    cmbeq2.Items.Clear();
                    cmbeq3.Items.Clear();
                    cmbeq4.Items.Clear();
                    cmbeq5.Items.Clear();
                    cmbeq6.Items.Clear();
                    eqfill(loadedeq);
                    lbleq1.Text = "";
                    lbleq2.Text = "";
                    lbleq3.Text = "";
                    lbleq4.Text = "";
                    lbleq5.Text = "";
                    lbleq6.Text = "";

                }
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    setfacilityname = facilitycb.SelectedItem.ToString();
                    loadedid = "nareservations";
                    loadedeq = "equipments";
                    cmbeq1.Items.Clear();
                    cmbeq2.Items.Clear();
                    cmbeq3.Items.Clear();
                    cmbeq4.Items.Clear();
                    cmbeq5.Items.Clear();
                    cmbeq6.Items.Clear();
                    eqfill(loadedeq);
                    lbleq1.Text = "";
                    lbleq2.Text = "";
                    lbleq3.Text = "";
                    lbleq4.Text = "";
                    lbleq5.Text = "";
                    lbleq6.Text = "";

                }

                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    setfacilityname = facilitycb.SelectedItem.ToString();
                    loadedid = "oareservations";
                    loadedeq = "equipments";
                    cmbeq1.Items.Clear();
                    cmbeq2.Items.Clear();
                    cmbeq3.Items.Clear();
                    cmbeq4.Items.Clear();
                    cmbeq5.Items.Clear();
                    cmbeq6.Items.Clear();
                    eqfill(loadedeq);
                    lbleq1.Text = "";
                    lbleq2.Text = "";
                    lbleq3.Text = "";
                    lbleq4.Text = "";
                    lbleq5.Text = "";
                    lbleq6.Text = "";


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

        private void cmbeq1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq1.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty,equipments.equipmentstatus from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq1.Text = eqhandler.ToString();
                    label15.Text = Functions.Functions.reader["equipmentstatus"].ToString();

                }

                if (label15.Text == "Available")
                {
                    textBox1.Enabled = true;
                }
                else
                {
                    textBox1.Enabled = false;
                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbeq2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq2.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq2.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbeq3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq3.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq3.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void cmbeq5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq5.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq5.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbeq4_SelectedIndexChanged(object sender, EventArgs e)
        {

            int eqhandler;
            try
            {
                loadedeqid = cmbeq4.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq4.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbeq6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq6.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '"+facilitycb.SelectedItem.ToString()+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq6.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbeq7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq7.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq7.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbeq8_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq8.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq8.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbeq9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq9.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq9.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbeq10_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq10.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq10.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbeq11_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq11.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq11.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbeq12_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eqhandler;
            try
            {
                loadedeqid = cmbeq12.SelectedItem.ToString();
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.availableqty from equipments where equipmentname = '" + loadedeqid + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq12.Text = eqhandler.ToString();

                }


                Connection.Connection.conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void checkconflictevent()
        {



        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int txt1 = 0;
            int lbl1 = 0;
            if (textBox1.Text == "" && lbleq1.Text == "")
            {

            }
            if(textBox1.Text != "" && lbleq1.Text != "")
            {
                txt1 = Int32.Parse(textBox1.Text);
                lbl1 = Int32.Parse(lbleq1.Text);
            }
            
            if (txt1 > lbl1)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void facilitycb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (facilitycb2.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");

                    cbval = "Function Hall";
                    filldata(cbval);
                }
                else if (facilitycb2.SelectedItem.ToString() == "Auditorium")
                {

                    //MessageBox.Show("Debug Line for Auditorium Executed");
                    cbval = "Auditorium";
                    filldata(cbval);
                }
                else if (facilitycb2.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    cbval = "New AVR";
                    filldata(cbval);
                }

                else if (facilitycb2.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    cbval = "Old AVR";
                    filldata(cbval);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Reservation reserve = new Reservation();
            this.Visible = false;
            reserve.Show();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            StudentDashboard sd = new StudentDashboard();
            this.Close();
            sd.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

                        var gen = MessageBox.Show("Your reservation was approved!\nReservation Name and Date: "+tempeventname+" "+tempdate+"\nFacility: "+tempfac+"\nMark Notification as Read?", "Delete equipment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (gen == DialogResult.Yes)
                        {

                            Connection.Connection.DB();
                            Functions.Functions.gen = "UPDATE "+facid+" SET readstatus = 1 where reservationstatus = 'Approved' and reservedby = '"+name+"'";
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                    }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox2.Text == "" && lbleq2.Text == "")
            {

            }
            if (textBox2.Text != "" && lbleq2.Text != "")
            {
                txt = Int32.Parse(textBox2.Text);
                lbl = Int32.Parse(lbleq2.Text);
            }
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox3.Text == "" && lbleq3.Text == "")
            {

            }
            if (textBox3.Text != "" && lbleq3.Text != "")
            {
                txt = Int32.Parse(textBox3.Text);
                lbl = Int32.Parse(lbleq3.Text);
            }
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox4.Text == "" && lbleq4.Text == "")
            {

            }
            if (textBox4.Text != "" && lbleq4.Text != "")
            {
                txt = Int32.Parse(textBox4.Text);
                lbl = Int32.Parse(lbleq4.Text);
            }
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox5.Text == "" && lbleq5.Text == "")
            {

            }
            if (textBox5.Text != "" && lbleq5.Text != "")
            {
                txt = Int32.Parse(textBox5.Text);
                lbl = Int32.Parse(lbleq5.Text);
            }
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox6.Text == "" && lbleq6.Text == "")
            {

            }
            if (textBox6.Text != "" && lbleq6.Text != "")
            {
                txt = Int32.Parse(textBox6.Text);
                lbl = Int32.Parse(lbleq6.Text);
            }
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox12.Text == "" && lbleq7.Text == "")
            {

            }
            if (textBox12.Text != "" && lbleq7.Text != "")
            {
                txt = Int32.Parse(textBox12.Text);
                lbl = Int32.Parse(lbleq7.Text);
            }
            
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox11.Text == "" && lbleq8.Text == "")
            {

            }
            if (textBox11.Text != "" && lbleq8.Text != "")
            {
                txt = Int32.Parse(textBox11.Text);
                lbl = Int32.Parse(lbleq8.Text);
            }
            
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox10.Text == "" && lbleq9.Text == "")
            {

            }
            if (textBox10.Text != "" && lbleq9.Text != "")
            {
                txt = Int32.Parse(textBox10.Text);
                lbl = Int32.Parse(lbleq9.Text);
            }
            
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox9.Text == "" && lbleq10.Text == "")
            {

            }
            if (textBox9.Text != "" && lbleq10.Text != "")
            {
                txt = Int32.Parse(textBox9.Text);
                lbl = Int32.Parse(lbleq10.Text);
            }
            
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox8.Text == "" && lbleq11.Text == "")
            {

            }
            if (textBox8.Text != "" && lbleq11.Text != "")
            {
                txt = Int32.Parse(textBox8.Text);
                lbl = Int32.Parse(lbleq11.Text);
            }
            
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int txt = 0;
            int lbl = 0;
            if (textBox7.Text == "" && lbleq12.Text == "")
            {

            }
            if (textBox7.Text != "" && lbleq12.Text != "")
            {
                txt = Int32.Parse(textBox7.Text);
                lbl = Int32.Parse(lbleq12.Text);
            }
            //
            if (txt > lbl)
            {
                MessageBox.Show("The quantity you're trying to input\nexceed the maximum amount of available equipment!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            seteventname = txtEventname.Text;
            setfacilityname = facilitycb.SelectedItem.ToString();
            Student.BorrowEquipment be = new Student.BorrowEquipment();
            this.Visible = true;
            be.Show();
        }
    }
}
