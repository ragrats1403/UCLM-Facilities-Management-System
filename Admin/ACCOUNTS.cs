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
    public partial class ACCOUNTS : Form
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
        public ACCOUNTS()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void ACCOUNTS_Load(object sender, EventArgs e)
        {
            Filldata();
            
            lblfullname.Text = Form1.setfullname;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Filldata()
        {
            Functions.Functions.gen = "Select firstname AS [First Name], lastname AS [Last Name], dateregistered as [Date Registered], studentid as [Student ID], roleid AS [Role ID] from users";
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtfirstname.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtlastname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtdateregistered.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                txtstudentid.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txtroleid.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                //btnRegister.Enabled = false;
                //btnUpdate.Enabled = true;
                //btnDelete.Enabled = true;
              
                //lblroleid.Visible = true;
                txtroleid.Visible = true;
              
                this.tabControl1.SelectedIndex = 1;
                button8.Visible = true;

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
                Functions.Functions.gen = "UPDATE users SET roleid='" + txtroleid.Text + "' where studentid = '" + txtstudentid.Text + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "users", MessageBoxButtons.OK);

                Connection.Connection.conn.Close();
                ACCOUNTS acc = new ACCOUNTS();
                this.Close();
                acc.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
