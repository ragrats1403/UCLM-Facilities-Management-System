﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Function_Hall_Reservation_System.WorkingStudent
{
    public partial class Equipments : Form
    {
        public static string cureqname;
        public Equipments()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filldata();
            lblfullname.Text = Form1.setfullname;
        }
        public void Filldata()
        {
            Functions.Functions.gen = "Select * from Equipments";
            Functions.Functions.fill(Functions.Functions.gen, dataGridView1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendarOfActivities calendar = new CalendarOfActivities();
            this.Visible = false;
            calendar.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            this.Visible = false;
            reservation.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Accounts accounts = new Accounts();
            this.Visible = false;
            accounts.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Equipments equipments = new Equipments();
            this.Visible = false;
            equipments.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            GenerateReports report = new GenerateReports();
            this.Visible = false;
            report.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtequipmentid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtequipmentname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                cmbstatus.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                this.tabControl1.SelectedIndex = 1;
                label13.Visible = true;
                txtequipmentid.Visible = true;
                txtequipmentid.Enabled = false;
                txtequipmentname.Enabled = false;
                button8.Visible = true;
                button9.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "UPDATE Equipments SET equipmentstatus='"+cmbstatus.Text+"' WHERE equipmentname='"+txtequipmentname.Text+"'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated Equipments Status!", "Equipments", MessageBoxButtons.OK);

                Connection.Connection.conn.Close();
                this.Close();
                Equipments eq = new Equipments();
                eq.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Logged out!", "Logout", MessageBoxButtons.OK);
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        public bool chkdup(string eqname)
        {
           
            int dupcount = 0;
            Connection.Connection.DB();
           // Connection.Connection.conn.Open();
            if (Connection.Connection.conn.State == System.Data.ConnectionState.Open)
            {
                Functions.Functions.gen = "Select * from Equipments where equipmentname='" + txtequipmentname.Text + "'";
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

        private void button7_Click(object sender, EventArgs e)
        {

            string eq = txtequipmentname.Text;
            try
            {


                if (chkdup(eq))
                {
                    MessageBox.Show("Equipment already exists with Equipment Name: " + txtequipmentname.Text, "Equipments", MessageBoxButtons.OK);
                    this.Close();
                    Equipments equ = new Equipments();
                    equ.Show();
                    this.tabControl1.SelectedIndex = 1;
                }
                else
                {

                    Connection.Connection.DB();
                    Functions.Functions.gen = "Insert Into Equipments(equipmentname,equipmentstatus)values('" + txtequipmentname.Text + "','" + cmbstatus.Text + "')";
                    Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);

                    Functions.Functions.command.ExecuteNonQuery();
                    MessageBox.Show("Equipment Added!", "Equipments", MessageBoxButtons.OK);

                    Connection.Connection.conn.Close();
                    this.Close();
                    Equipments equ = new Equipments();
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
                    Functions.Functions.gen = "Delete from Equipments where equipmentname ='" + txtequipmentname.Text + "'";
                    Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                    Functions.Functions.command.ExecuteNonQuery();
                    Connection.Connection.conn.Close();
                    MessageBox.Show("Equipment Removed!", "Equipments", MessageBoxButtons.OK);
                    this.Close();
                    Equipments equ = new Equipments();
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