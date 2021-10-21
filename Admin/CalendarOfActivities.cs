﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Function_Hall_Reservation_System.Admin
{
    public partial class CalendarOfActivities : Form
    {
        public static string idname;
        public string loadedid;
        public CalendarOfActivities()
        {
            InitializeComponent();
            cbstyleset();
        }

        public void cbstyleset()
        {
            facilitycb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void Fillfhreservationsdata()
        {
            idname = "fhereservation";
            Functions.Functions.gen = "Select * from fhreservation";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }
        public void Fillaudreservationsdata()
        {
            idname = "audreservations";
            Functions.Functions.gen = "Select * from audreservations";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }
        public void Fillnareservationsdata()
        {
            idname = "nareservations";
            Functions.Functions.gen = "Select * from nareservations";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }
        public void Filloareservationsdata()
        {
            idname = "oareservations";
            Functions.Functions.gen = "Select * from oareservations";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void filldata()
        {

            // dataGridView1.Columns[2].Width = 108;
            Functions.Functions.gen = "Select fhreservation.eventname as [Event Name],fhreservation.reserveddate as [Date],fhreservation.timestart as [Time Start], fhreservation.timeend as [Time End] from fhreservation where fhreservation.reservationstatus = 'Approved'";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
        }

        private void CalendarOfActivities_Load(object sender, EventArgs e)
        {
            filldata();
            lblfullname.Text = Form1.setfullname;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");
                    Fillfhreservationsdata();
                    loadedid = idname;
                }
                else if (facilitycb.SelectedItem.ToString() == "Auditorium")
                {

                    //MessageBox.Show("Debug Line for Auditorium Executed");
                    Fillaudreservationsdata();
                    loadedid = idname;
                }
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    Fillnareservationsdata();
                    loadedid = idname;
                }

                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    Filloareservationsdata();
                    loadedid = idname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
