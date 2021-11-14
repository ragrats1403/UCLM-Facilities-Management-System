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

namespace Function_Hall_Reservation_System.Admin
{
    public partial class ViewReservationList : Form
    {
        public static string idname;
        public string loadedid;
        public ViewReservationList()
        {
            InitializeComponent();
        }

        public void Fillfhreservationdata()
        {
            idname = "fhreservation";
            Functions.Functions.gen = "Select * from fhreservation";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }
        public void Fillaudreservationdata()
        {
            idname = "audreservation";
            Functions.Functions.gen = "Select * from audreservations";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Fillnareservationdata()
        {
            idname = "nareservations";
            Functions.Functions.gen = "Select * from nareservations";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Filloareservationdata()
        {
            idname = "oareservations";
            Functions.Functions.gen = "Select * from oareservations";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



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
            try
            {
                txtreservationid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txteventname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtreservedby.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                cmbstatus.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txtdatereserved.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                txtcheckedby.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                txtapprovedby.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                //txtstudentid.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                // txtstudentname.Text = dataGridView1[8, e.RowIndex].Value.ToString();
                txtreservedequipments.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                txttimestart.Text = dataGridView1[8, e.RowIndex].Value.ToString();
                txtreservedate.Text = dataGridView1[9, e.RowIndex].Value.ToString();
                txttimeend.Text = dataGridView1[10, e.RowIndex].Value.ToString();
                /*txtreservationid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txteventname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtreservedby.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                cmbstatus.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txtdatereserved.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                txtcheckedby.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                txtapprovedby.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                //txtstudentid.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                //txtstudentname.Text = dataGridView1[8, e.RowIndex].Value.ToString();
                txtreservedequipments.Text = dataGridView1[9, e.RowIndex].Value.ToString();
                //txtreservedate.Text = dataGridView1[10, e.RowIndex].Value.ToString();
                txttimestart.Text = dataGridView1[10, e.RowIndex].Value.ToString();
                txttimeend.Text = dataGridView1[12, e.RowIndex].Value.ToString();
                txtreservedate.Text = dataGridView1[13, e.RowIndex].Value.ToString();*/

                this.tabControl1.SelectedIndex = 1;

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
                Functions.Functions.gen = "UPDATE " + loadedid + " SET reservationstatus='" + cmbstatus.Text + "',approvedby='" + Form1.setfullname + "' where reservationid = '" + txtreservationid.Text + "'";
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

        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");
                    Fillfhreservationdata();
                    loadedid = idname;
                }
                else if (facilitycb.SelectedItem.ToString() == "Auditorium")
                {

                    //MessageBox.Show("Debug Line for Auditorium Executed");
                    Fillaudreservationdata();
                    loadedid = idname;
                }
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    Fillnareservationdata();
                    loadedid = idname;
                }

                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    Filloareservationdata();
                    loadedid = idname;
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
    }
}
