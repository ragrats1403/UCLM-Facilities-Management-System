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
        public int count = 0;
        private String loadedid;
        public static int availableqty;
        public static string loadedeqid = "";
        public String loadedeq;
        public string dateval = "";
        public int loadedcount = 0;
        public string newval = "";
        public Reservation()
        {
            InitializeComponent();
        }

        public void filltxtbox()
        {
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select count(*) from fhequipments";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    count = Functions.Functions.reader.GetInt32(0);

                }


                Connection.Connection.conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

            fillstudnameid();
            filldata();
            timestart();
            timeend();
            date();
            lblfullname.Text = Form1.setfullname;
            //chkboxfill();
            cbstyleset();
            filltxtbox();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker3.Format = DateTimePickerFormat.Time;

        }
        public void eqfill(String id)
        {
            int eqid;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select " + loadedeq + ".equipmentname from " + loadedeq + "";
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


                }
                if (cmbeq1.Items.Count <= 6)
                {
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                }
                else
                {
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = true;
                    cmbeq11.Visible = true;
                    cmbeq12.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = true;
                    lbleq11.Visible = true;
                    lbleq12.Visible = true;
                }

                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /* public void chkboxfill()
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
         }*/
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

       /* public void CheckConflict()
        {

            
            
            
            Functions.Functions.gen = "Select * FROM reservation WHERE timestart >= '" + dateTimePicker1.Value + "' AND timeend <= '" + dateTimePicker3.Value + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView2);

        }

        */

        private void btnrequest_Click(object sender, EventArgs e)
        {

            var list = new List<String>();
            var name = Form1.setfirstname + " " + Form1.setlastname;

            string month = "";


            string loadedstr = "";
            string timestart = "";
            string timeend = "";
            string eqres1 = cmbeq1.Text.ToString() + "-" + lbleq1.Text.ToString();
            string eqres2 = cmbeq2.Text.ToString() + "-" + lbleq2.Text.ToString();
            string eqres3 = cmbeq3.Text.ToString() + "-" + lbleq3.Text.ToString();
            string eqres4 = cmbeq4.Text.ToString() + "-" + lbleq4.Text.ToString();
            string eqres5 = cmbeq5.Text.ToString() + "-" + lbleq5.Text.ToString();
            string eqres6 = cmbeq6.Text.ToString() + "-" + lbleq6.Text.ToString();
            
            var selectedequip = new List<string>();
            try
            {


                selectedequip.Add(eqres1);
                selectedequip.Add(eqres2);
                selectedequip.Add(eqres3);
                selectedequip.Add(eqres4);
                selectedequip.Add(eqres5);
                selectedequip.Add(eqres6);

                string allequip = string.Join(", ", selectedequip);
                month = dateTimePicker2.Value.ToString("MMMM");
                dateval = dateTimePicker2.Value.ToString("MM/dd/yyyy");
                

                try
                {
                    Connection.Connection.DB();
                    Functions.Functions.gen = "select " + loadedid + ".reserveddate from "+loadedid+"";
                    Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                    Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                    Functions.Functions.reader.Read();
                   
                   while(Functions.Functions.reader.Read())
                    {
                        loadedstr = Functions.Functions.reader.GetString(0);
                        list.Add(loadedstr);
                    }

                    Connection.Connection.conn.Close();

                       
                       
                    foreach (var item in list)
                    {
                        if (item.Equals(dateval))
                        {
                            newval = item;
                        }
                    }
                    
                    //Connection.Connection.conn.Close();
                    
                    if (newval.Equals(dateval))
                    {
                       
                        Connection.Connection.DB();
                        Functions.Functions.gen = "Select count(*) from "+loadedid+" where '" + dateTimePicker1.Value + "' between timestart and timestart or '" + dateTimePicker3.Value + "' between timestart and timeend  or timestart between '" + dateTimePicker1.Value + "' and '" + dateTimePicker3.Value + "'or timeend between '" + dateTimePicker1.Value + "' and '" + dateTimePicker3.Value + "'"; Functions.Functions.gen = "Select * from "+loadedid+" where '" + dateTimePicker1.Value + "' between timestart and timestart or '" + dateTimePicker3.Value + "' between timestart and timeend  or timestart between '" + dateTimePicker1.Value + "' and '" + dateTimePicker3.Value + "'or timeend between '" + dateTimePicker1.Value + "' and '" + dateTimePicker3.Value + "'";
                        Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                        Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                        Functions.Functions.reader.Read();
                        
                            loadedcount = Functions.Functions.reader.GetInt32(0);
                           
                        
                        Connection.Connection.conn.Close();
                        if (loadedcount > 0)
                        {
                           
                            MessageBox.Show("Someone is using the facility within that time! Number of Conflicts: " + loadedcount);
                        }
                        else
                        {
                            MessageBox.Show("Reserving..");
                            Connection.Connection.DB();
                            Functions.Functions.gen = "Insert Into " + loadedid + "(eventname,reservedby,reservationstatus,datereserved,checkedby,studentid,studentname,reservedequipments,approvedby,timestart,month,timeend,reserveddate,facilityname)values('" + txtEventname.Text + "','" + name + "','Pending','" + DateTime.Now.ToString() + "','N/A','" + txtStudentid.Text + "','" + txtStudentName.Text + "','" + allequip + "','N/A','" + dateTimePicker1.Value + "','" + month + " ','" + dateTimePicker3.Value + "','" + dateval + "','" + facilitycb.SelectedItem.ToString() + "')";
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
                        Functions.Functions.gen = "Insert Into " + loadedid + "(eventname,reservedby,reservationstatus,datereserved,checkedby,studentid,studentname,reservedequipments,approvedby,timestart,month,timeend,reserveddate,facilityname)values('" + txtEventname.Text + "','" + name + "','Pending','" + DateTime.Now.ToString() + "','N/A','" + txtStudentid.Text + "','" + txtStudentName.Text + "','" + allequip + "','N/A','" + dateTimePicker1.Value + "','" + month + " ','" + dateTimePicker3.Value + "','" + dateval + "','" + facilitycb.SelectedItem.ToString() + "')";
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
            cmbeq1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbeq6.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");|
                    loadedid = "fhreservation";
                    loadedeq = "fhequipments";
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
                    loadedeq = "audequipments";
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
                    loadedid = "nareservations";
                    loadedeq = "naequipments";
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
                    loadedid = "oareservations";
                    loadedeq = "oaequipments";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                while (Functions.Functions.reader.Read())
                {
                    eqhandler = Functions.Functions.reader.GetInt32(0);
                    lbleq1.Text = eqhandler.ToString();

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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
                Functions.Functions.gen = "Select " + loadedeq + ".availableqty from " + loadedeq + " where equipmentname = '" + loadedeqid + "'";
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
            
        }
    }

}
