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
    public partial class BorrowEquipment : Form
    {
        private static string loadedeq = "";
        public BorrowEquipment()
        {
            InitializeComponent();
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

        private int subtractqty()
        {
            int currentqty = Convert.ToInt32(txtAvailqty.Text);
            int borrowedqty = Convert.ToInt32(txtBorrowedqty.Text);

            return currentqty = borrowedqty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int subtractedqty = subtractqty();
            int currentqty = Convert.ToInt32(txtAvailqty.Text);
            int borrowedqty = Convert.ToInt32(txtBorrowedqty.Text);
            int oldbqty;
            int newbqty;
            String tempoldbqty;
            int quantity;
            

            try
            {

                //first query(save info to borrowedequipment table)
                Connection.Connection.DB();
                Functions.Functions.gen = "Insert into borrowedequipment (borrowedeq,studentid,studentname,borrowedfacilityname,addedfacilityname,eventname)values('"+txtEqname.Text+"','"+Form1.setstudentid+"','"+Form1.setfullname+"','"+txtStoredFacility.Text+"','"+Reservation.setfacilityname+"','"+Reservation.seteventname+"')";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Stored Information to BorrowedEquipments!", "Borrow Successful", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();

                //second query(getting borrowedqty values from deducted facility equipment)
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipmentname,borrowedqty from equipments where facilityname = '"+txtStoredFacility.Text+"' and equipmentname = '"+txtEqname.Text+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                Functions.Functions.reader.Read();
                tempoldbqty = Functions.Functions.reader["borrowedqty"].ToString();
                oldbqty = Convert.ToInt32(tempoldbqty);
                newbqty = oldbqty + borrowedqty;
                Connection.Connection.conn.Close();

                //third query(update info for borrowed facility)
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE equipments SET borrowedqty='" + newbqty + "', where equipmentname = '" + txtEqname.Text + "' and facilityname = '"+txtStoredFacility.Text+"'";
                /*Functions.Functions.gen = "UPDATE fhreservation SET fhreservationstatus='" + cmbstatus.Text + "',approvedby = '"+Form1.setfullname+"' where reservationid= '"+txtreservationid.Text+"'";*/
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "fhreservation", MessageBoxButtons.OK);
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
