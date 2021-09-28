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
    public partial class StudentCalendar : Form
    {
        public StudentCalendar()
        {
            InitializeComponent();
        }

        private void StudentCalendar_Load(object sender, EventArgs e)
        {
            filldata();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservation reserve = new Reservation();
            this.Visible = false;
            reserve.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        public void filldata()
        {
            lblfullname.Text = Form1.setfullname;   
           // dataGridView1.Columns[2].Width = 108;
            Functions.Functions.gen = "Select reservation.eventname as [Event Name],reservation.reserveddate as [Date],reservation.timestart as [Time Start], reservation.timeend as [Time End] from reservation where reservation.reservationstatus = 'Approved'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
            
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 110;
        }

    }
}
