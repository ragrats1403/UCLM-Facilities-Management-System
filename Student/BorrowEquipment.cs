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
    public partial class BorrowEquipment : Form
    {

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

        private static string loadedeq = "";
        public BorrowEquipment()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }



        private void BorrowEquipment_Load(object sender, EventArgs e)
        {

        }

        public void filldatasearch()
        {

        }

        
        

        private void button2_Click(object sender, EventArgs e)
        {
            string eqname = "";
            string quantity;
            string dequantity;
            string totalqty;
            
            try
            {
                Connection.Connection.DB();
                //Functions.Functions.gen = "Select availableqty,totalqty from equipments where facilityname = '"+facilitycb.SelectedItem.ToString()+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                Functions.Functions.reader.Read();

                //test = Functions.Functions.reader.GetInt32(0);

                quantity = Functions.Functions.reader["availableqty"].ToString();
                totalqty = Functions.Functions.reader["totalqty"].ToString();
                

                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Functions.Functions.gen = "Select equipmentname AS [Equipment Name],equipmentstatus AS [Availability],availableqty AS [Available Quantity],defectiveqty AS[Defective Quantity],totalqty AS[Total Quantity],facilityname AS[Stored Facility] from equipments where equipmentname LIKE '"+txtSearcheq.Text+"%' Except Select equipmentname AS [Equipment Name],equipmentstatus AS [Availability],availableqty AS [Available Quantity],defectiveqty AS[Defective Quantity],totalqty AS[Total Quantity],facilityname AS[Stored Facility] from equipments where facilityname = '"+Reservation.setfacilityname+"'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtEqname.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtAvailability.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtAvailqty.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                txtDefectqty.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txtTotalqty.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                txtStoredFacility.Text = dataGridView1[5, e.RowIndex].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private int subtractavailqty()
        {
            int currentqty = Convert.ToInt32(txtAvailqty.Text);
            int borrowedqty = Convert.ToInt32(txtBorrowedqty.Text);

            return currentqty - borrowedqty;
        }
        private int subtracttotalqty()
        {
            int currenttotal = Convert.ToInt32(txtTotalqty.Text);
            int newcurrenttotal = currenttotal - Convert.ToInt32(txtBorrowedqty.Text);

            return newcurrenttotal;
        }

        private int addedavailqty()
        {
            int borrowedqty = Convert.ToInt32(txtBorrowedqty.Text);
            int oldaddedqty;
            String temporaryqty;
            int newaddedqty;
            Connection.Connection.DB();
            Functions.Functions.gen = "Select equipmentname,addedqty from equipments where facilityname = '" + Reservation.setfacilityname + "' and equipmentname = '" + txtEqname.Text + "'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
            Functions.Functions.reader.Read();
            temporaryqty = Functions.Functions.reader["addedqty"].ToString();
            oldaddedqty = Convert.ToInt32(temporaryqty);
            Connection.Connection.conn.Close();
            newaddedqty = oldaddedqty + borrowedqty;
            return newaddedqty;
        }
        public void autoupdatetotalqty()
        {

            int total = 0;
            int available = 0;
            int defective = 00;
            String t = "";
            String a = "";
            String d = "";
            //1st query for designated facility equipment auto update
            MessageBox.Show("First query");
            Connection.Connection.DB();
            Functions.Functions.gen = "Select equipmentname,availableqty,defectiveqty from equipments where facilityname = '"+Reservation.setfacilityname+"' and equipmentname = '"+txtEqname.Text+"'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
            Functions.Functions.reader.Read();
            a = Functions.Functions.reader["availableqty"].ToString();
            d = Functions.Functions.reader["defectiveqty"].ToString();

            available = Convert.ToInt32(a);
            defective = Convert.ToInt32(d);

            total = available + defective;
            Connection.Connection.conn.Close();
            //2nd query for designated facility equipment auto update
            MessageBox.Show("2nd query");
            Connection.Connection.DB();
            Functions.Functions.gen = "UPDATE equipments SET availableqty='" + available + "',defectiveqty = '" + defective + "',totalqty = '" + total + "' where equipmentname = '" + txtEqname.Text + "' and facilityname = '" + Reservation.setfacilityname + "'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.command.ExecuteNonQuery();
            Connection.Connection.conn.Close();
            //1st query for borrowed facility equipment auto update
            MessageBox.Show("3rd query");
            Connection.Connection.DB();
            Functions.Functions.gen = "Select equipmentname,availableqty,defectiveqty from equipments where facilityname = '" + txtStoredFacility.Text + "' and equipmentname = '" + txtEqname.Text + "'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
            Functions.Functions.reader.Read();
            a = Functions.Functions.reader["availableqty"].ToString();
            d = Functions.Functions.reader["defectiveqty"].ToString();

            available = Convert.ToInt32(a);
            defective = Convert.ToInt32(d);

            total = available + defective;
            Connection.Connection.conn.Close();
            //2nd query for designated facility equipment auto update
            MessageBox.Show("4th query");
            Connection.Connection.DB();
            Functions.Functions.gen = "UPDATE equipments SET availableqty='" + available + "',defectiveqty = '" + defective + "',totalqty = '" + total + "' where equipmentname = '" + txtEqname.Text + "' and facilityname = '" + txtStoredFacility.Text + "'";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
            Functions.Functions.command.ExecuteNonQuery();
            Connection.Connection.conn.Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            int subtractedqty = subtractavailqty();
            int newtotalqty = subtracttotalqty();
            int currentqty = Convert.ToInt32(txtAvailqty.Text);
            int borrowedqty = Convert.ToInt32(txtBorrowedqty.Text);
            int oldbqty;
            int newbqty;
            String tempoldbqty;
            
            String tempexorigqty;
            String tempexaddedqty;
            int newavailval;
            int newtotalval;
            int newaddedval;


            try
            {

                //first query(save info to borrowedequipment table)
               // MessageBox.Show("First query");
                Connection.Connection.DB();
                Functions.Functions.gen = "Insert into borrowedequipment (borrowedeq,studentid,studentname,borrowedfacilityname,addedfacilityname,eventname,borrowedqty)values('" + txtEqname.Text + "','" + Form1.setstudentid + "','" + Form1.setfullname + "','" + txtStoredFacility.Text + "','" + Reservation.setfacilityname + "','" + Reservation.seteventname + "','" + borrowedqty + "')";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Stored Information to BorrowedEquipments!", "Borrow Successful", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();

                //second query(getting borrowedqty values from deducted facility equipment)
               // MessageBox.Show("2nd query");
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipmentname,borrowedqty,availableqty,totalqty from equipments where facilityname = '" + txtStoredFacility.Text + "' and equipmentname = '" + txtEqname.Text + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                Functions.Functions.reader.Read();
                tempoldbqty = Functions.Functions.reader["borrowedqty"].ToString();
                oldbqty = Convert.ToInt32(tempoldbqty);
                newbqty = oldbqty + borrowedqty;
                Connection.Connection.conn.Close();

                //third query(update info for borrowed facility)
               // MessageBox.Show("3rd query");
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE equipments SET borrowedqty='" + newbqty + "',availableqty = '" + subtractedqty + "' where equipmentname = '" + txtEqname.Text + "' and facilityname = '" + txtStoredFacility.Text + "'";                
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                // MessageBox.Show("Successfully Updated!", "equipments", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();
                newaddedval = addedavailqty();
                //fourth query(get exising values for availableqty and total qty to desired facility)
                //MessageBox.Show("4th query");
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipmentname,originalqty from equipments where facilityname = '" + Reservation.setfacilityname + "' and equipmentname = '" + txtEqname.Text + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                Functions.Functions.reader.Read();
                tempexorigqty = Functions.Functions.reader["originalqty"].ToString();
                
                newavailval = Convert.ToInt32(tempexorigqty) + newaddedval;
                
                Connection.Connection.conn.Close();

                //fifth query(update new values to designated facility)

              //  MessageBox.Show("5th query");
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE equipments SET availableqty='" + newavailval + "',addedqty = '" + newaddedval + "' where equipmentname = '" + txtEqname.Text + "' and facilityname = '" +Reservation.setfacilityname+ "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "equipments", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();
                autoupdatetotalqty();
                Student.Reservation r = new Student.Reservation();
                r.Refresh();
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
