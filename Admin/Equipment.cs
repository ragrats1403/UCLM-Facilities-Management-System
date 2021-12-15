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
    public partial class Equipment : Form
    {
        public static string idname;
        public string loadedid;
        public string loadedeq;

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
        public Equipment()
        {
            InitializeComponent();
            cbstyleset();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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
                /*txtequipmentid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtequipmentname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                //cmbstatus.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                this.tabControl1.SelectedIndex = 1;
                label13.Visible = true;
                txtequipmentid.Visible = true;
                txtequipmentid.Enabled = false;
                txtequipmentname.Enabled = false;
                button8.Visible = true;
                button9.Visible = true;
                button7.Visible = false;*/
                txtequipmentname.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtavailability.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtquantity.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                txtDefective.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txttotalqty.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                txtfacname.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                this.tabControl1.SelectedIndex = 1;
                label13.Visible = true;
                btnSave.Enabled = false;
                btnSave.Visible = false;
                btnremove.Enabled = false;
                btnremove.Visible = false;
                txtequipmentname.Enabled = false;
                txtavailability.Enabled = false;
                txtDefective.Enabled = false;
                txtfacname.Enabled = false;
                txttotalqty.Visible = true;
                txttotalqty.Enabled = true;
                txttotalqty.Enabled = false;
                txtquantity.Enabled = false;
                btnaddneweq.Visible = false;
                btnaddneweq.Enabled = false;
                btnsaveneweq.Enabled = false;
                btnsaveneweq.Visible = false;
                btnEditEquip.Visible = true;
                btnEditEquip.Enabled = true;
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
        public void filldata(String id)
        {
            Functions.Functions.gen = "Select equipmentname AS [Equipment Name], equipmentstatus AS [Availability], availableqty AS [Available Quantity], defectiveqty AS [Defective Quantity], totalqty AS [Total Quantity], facilityname AS [Stored In],borrowedqty AS [Added Quantity To Other Facility],addedqty AS [Borrowed quantity from other Facility] from equipments where facilityname = '" + id + "'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }
        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    filldata("Function Hall");
                    txtfacname.Text = "Function Hall";
                }
                else if (facilitycb.SelectedItem.ToString() == "Auditorium")
                {
                    filldata("Auditorium");
                    txtfacname.Text = "Auditorium";
                }
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    filldata("New AVR");

                    txtfacname.Text = "New AVR";
                }
                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    filldata("Old AVR");

                    txtfacname.Text = "Old AVR";
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.Visible = false;
            btnremove.Enabled = false;
            btnremove.Visible = false;
            btnaddneweq.Visible = true;
            btnaddneweq.Enabled = true;
            btnsaveneweq.Enabled = false;
            btnsaveneweq.Visible = false;
            btnEditEquip.Visible = true;
            btnEditEquip.Enabled = true;
            txtavailability.Text = "";
            txtDefective.Text = "";
            txtquantity.Text = "";
            txttotalqty.Text = "";
            txtequipmentname.Text = "";
            txtfacname.Text = "";
        }

        private void btnEditEquip_Click(object sender, EventArgs e)
        {
            txtequipmentname.Enabled = true;
            txtequipmentname.Visible = true;
            txtquantity.Enabled = true;
            txtquantity.Visible = true;
            txttotalqty.Enabled = true;
            txttotalqty.Visible = true;
            txtDefective.Enabled = true;
            txtDefective.Visible = true;
            txtfacname.Enabled = false;
            txtavailability.Enabled = false;
            txtfacname.Visible = true;
            txtavailability.Visible = true;
            btnsaveneweq.Enabled = false;
            btnsaveneweq.Visible = false;
            btnaddneweq.Enabled = false;
            btnaddneweq.Visible = false;
            btnremove.Visible = true;
            btnremove.Enabled = true;
            btnSave.Enabled = true;
            btnSave.Visible = true;
            btnEditEquip.Enabled = false;
        }

        private void btnaddneweq_Click(object sender, EventArgs e)
        {
            txtequipmentname.Enabled = true;
            txtequipmentname.Visible = true;
            txtquantity.Enabled = true;
            txtquantity.Visible = true;
            label69.Enabled = false;
            label69.Visible = false;
            txttotalqty.Enabled = false;
            txttotalqty.Visible = false;
            txtDefective.Enabled = true;
            txtDefective.Visible = true;
            txtfacname.Enabled = false;
            txtavailability.Enabled = false;
            txtfacname.Visible = true;
            txtavailability.Visible = true;
            btnEditEquip.Visible = true;
            btnEditEquip.Enabled = false;
            btnaddneweq.Enabled = false;
            btnaddneweq.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string defect = txtDefective.Text;
            string total = txttotalqty.Text;
            string avail = txtquantity.Text;
            int def = Int32.Parse(defect);
            int to = Int32.Parse(total);

            int av = Int32.Parse(avail);
            string temp;
            string temp2;
            int currentavailqty;
            int currentoriginalqty;
            int neworigqty;
            int afterloopval = 0;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select availableqty,originalqty from equipments where equipmentname = '" + txtequipmentname.Text + "' and facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();
                Functions.Functions.reader.Read();
                temp = Functions.Functions.reader["availableqty"].ToString();
                temp2 = Functions.Functions.reader["originalqty"].ToString();
                currentoriginalqty = Convert.ToInt32(temp2);
                currentavailqty = Convert.ToInt32(temp);

                Connection.Connection.conn.Close();

                int f = 0;
                if (currentavailqty < av)
                {
                    for (int i = currentavailqty; i < av; i++)
                    {
                        f = f + 1;
                    }
                    afterloopval = f;
                }
                else if (currentavailqty > av)
                {
                    for (int i = currentavailqty; i > av; i--)
                    {
                        f = f - 1;
                    }
                    afterloopval = f;
                }
                neworigqty = currentoriginalqty + afterloopval;

                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE equipments SET availableqty = " + av + ", totalqty = " + totalqty(av, def) + ",defectiveqty = " + Int32.Parse(txtDefective.Text) + ",equipmentstatus = '" + txtavailability.Text + "',originalqty = '" + neworigqty + "' where equipmentname = '" + txtequipmentname.Text + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Edited Equipments Status!", "equipments", MessageBoxButtons.OK);

                Connection.Connection.conn.Close();
                this.Close();


                Equipment eq = new Equipment();
                eq.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                var gen = MessageBox.Show("Are you sure you want to delete this Equipment?", "Delete equipment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (gen == DialogResult.Yes)
                {
                    Functions.Functions.gen = "Delete from equipments where equipmentname ='" + txtequipmentname.Text + "'";
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
    }
}
