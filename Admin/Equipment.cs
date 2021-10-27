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
    public partial class Equipment : Form
    {
        public static string idname;
        public string loadedid;
        public string loadedeq;

        public Equipment()
        {
            InitializeComponent();
            cbstyleset();
        }
        public void cbstyleset()
        {
            facilitycb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void Fillfhequipmentdata()
        {
            idname = "fhequipments";
            Functions.Functions.gen = "Select * from fhequipments";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Fillaudequipmentdata()
        {
            idname = "audequipments";
            Functions.Functions.gen = "Select * from audequipments";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Fillnaequipmentdata()
        {
            idname = "naequipments";
            Functions.Functions.gen = "Select * from naequipments";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);



        }
        public void Filloaequipmentdata()
        {
            idname = "oaequipments";
            Functions.Functions.gen = "Select * from oaequipments";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);

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

        private void Equipment_Load(object sender, EventArgs e)
        {
            
            lblfullname.Text = Form1.setfullname;
        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtequipmentid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtequipmentname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtquantity.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                txtDefective.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txttotalqty.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                this.tabControl1.SelectedIndex = 1;
                label13.Visible = true;
                txtequipmentid.Visible = true;
                txtequipmentid.Enabled = false;
                txtequipmentname.Enabled = false;
                button8.Visible = true;
                button9.Visible = true;
                button5.Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string eq = txtequipmentname.Text;
            string defect = txtDefective.Text;
            string total = txttotalqty.Text;
            string avail = txtquantity.Text;
            int def = Int32.Parse(defect);
            int to = Int32.Parse(total);

            int av = Int32.Parse(avail);
            try
            {
                Connection.Connection.DB(); 
                Functions.Functions.gen = "UPDATE " + loadedeq + " SET availableqty = " + av + ", totalqty = " + totalqty(av,def) + ",defectiveqty = "+Int32.Parse(txtDefective.Text)+" where equipmentname = '" + txtequipmentname.Text + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated Equipments Status!", "Equipments", MessageBoxButtons.OK);

                Connection.Connection.conn.Close();
                Equipment equip = new Equipment();
                this.Close();
                equip.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool chkdup(string eqname)
        {

            int dupcount = 0;
            Connection.Connection.DB();
            // Connection.Connection.conn.Open();
            if (Connection.Connection.conn.State == System.Data.ConnectionState.Open)
            {
                Functions.Functions.gen = "Select * from "+loadedeq +" where equipmentname='" + txtequipmentname.Text + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.Connection = Connection.Connection.conn;
                Functions.Functions.command.CommandType = System.Data.CommandType.Text;
                Functions.Functions.command.Parameters.AddWithValue("equipmentname", eqname);
                dupcount = Convert.ToInt32(Functions.Functions.command.ExecuteScalar());
                Connection.Connection.conn.Close();
            }

            if (dupcount > 0)
                return true;


            return false;
        }
        public int subtractqty(int total, int defect)
        {

            return total - defect;
        }

        public int totalqty(int avail, int defect)
        {

            return avail + defect;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string eq = txtequipmentname.Text;
           
            try
            {
                
                
                

                if (chkdup(eq))
                {
                   
                    MessageBox.Show("Equipment already exists with Equipment Name: " + txtequipmentname.Text, "" + loadedeq, MessageBoxButtons.OK);
                    this.Close();
                    Equipment equ = new Equipment();
                    equ.Show();
                    this.tabControl1.SelectedIndex = 1;
                }
                else
                {
                    
                    Connection.Connection.DB();
                    Functions.Functions.gen = "Insert Into " + loadedeq + "(equipmentname,defectiveqty,availableqty,totalqty)values('" + txtequipmentname.Text + "'," +Int32.Parse(txtDefective.Text)+ ","+Int32.Parse(txtquantity.Text)+"," + totalqty(Int32.Parse(txtquantity.Text),Int32.Parse(txtDefective.Text)) + ")";
                    Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);

                    Functions.Functions.command.ExecuteNonQuery();
                    MessageBox.Show("Equipment Added!", "fhequipments", MessageBoxButtons.OK);

                    Connection.Connection.conn.Close();
                    this.Close();
                    Equipment equ = new Equipment();
                    equ.Show();
                    this.tabControl1.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                Connection.Connection.DB();
                var gen = MessageBox.Show("Are you sure you want to delete this Equipment?", "Delete equipment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (gen == DialogResult.Yes)
                {
                    Functions.Functions.gen = "Delete from " + loadedeq + " where equipmentname ='" + txtequipmentname.Text + "'";
                    Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                    Functions.Functions.command.ExecuteNonQuery();
                    Connection.Connection.conn.Close();
                    MessageBox.Show("Equipment Removed!", "fhequipments", MessageBoxButtons.OK);
                    this.Close();
                    Equipment equ = new Equipment();
                    equ.Show();
                    this.tabControl1.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtquatity_Click(object sender, EventArgs e)
        {

        }

        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");
                    Fillfhequipmentdata();
                    loadedid = idname;
                    loadedeq = "fhequipments";
                }
                else if (facilitycb.SelectedItem.ToString() == "Auditorium")
                {

                    //MessageBox.Show("Debug Line for Auditorium Executed");
                    Fillaudequipmentdata();
                    loadedid = idname;
                    loadedeq = "audequipments";
                }
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    Fillnaequipmentdata();
                    loadedid = idname;

                    loadedeq = "naequipments";
                }

                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    Filloaequipmentdata();
                    loadedid = idname;
                    loadedeq = "oaequipments";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtequipmentname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotalqty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
