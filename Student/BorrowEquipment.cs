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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BorrowEquipment_Load(object sender, EventArgs e)
        {

        }

        public void fillcmb()
        {

        }

        private void facilitycb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (facilitycb.SelectedItem.ToString() == "Function Hall")
                {
                    //MessageBox.Show("Debug Line for Functionhall selection Executed");|
                    
                    loadedeq = "equipments";
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
                    
                    loadedeq = "equipments";
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
                else if (facilitycb.SelectedItem.ToString() == "New AVR")
                {
                    //MessageBox.Show("Debug Line for New AVR Executed");
                    
                    loadedeq = "equipments";
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

                else if (facilitycb.SelectedItem.ToString() == "Old AVR")
                {

                    //MessageBox.Show("Debug Line for Old AVR Executed");
                    
                    loadedeq = "equipments";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void eqfill(String id)
        {

            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select equipments.equipmentname from equipments where facilityname = '" + facilitycb.SelectedItem.ToString() + "'";
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
                    cmbeq7.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq8.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq9.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq10.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq11.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    cmbeq12.Items.Add(Functions.Functions.reader["equipmentname"]).ToString();
                    
                }
                if (cmbeq1.Items.Count == 1)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = false;
                    cmbeq3.Visible = false;
                    cmbeq4.Visible = false;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = false;
                    lbleq3.Visible = false;
                    lbleq4.Visible = false;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    textBox3.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Visible = true;

                }
                if (cmbeq1.Items.Count == 2)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = false;
                    cmbeq4.Visible = false;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = false;
                    lbleq4.Visible = false;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    textBox3.Visible = false;
                    textBox2.Visible = true;
                    textBox1.Visible = true;

                }
                if (cmbeq1.Items.Count == 3)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = false;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = false;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 4)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = false;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = false;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 5)
                {

                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = false;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = false;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = false;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;

                }
                if (cmbeq1.Items.Count == 6)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = false;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = false;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = false;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 7)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = false;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = false;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = false;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 8)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = false;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = false;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = false;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 9)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = false;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = false;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = false;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 10)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = true;
                    cmbeq11.Visible = false;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = true;
                    lbleq11.Visible = false;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox8.Visible = false;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 11)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = true;
                    cmbeq11.Visible = true;
                    cmbeq12.Visible = false;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = true;
                    lbleq11.Visible = true;
                    lbleq12.Visible = false;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox8.Visible = true;
                    textBox7.Visible = false;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }
                if (cmbeq1.Items.Count == 11)
                {
                    cmbeq1.Visible = true;
                    cmbeq2.Visible = true;
                    cmbeq3.Visible = true;
                    cmbeq4.Visible = true;
                    cmbeq5.Visible = true;
                    cmbeq6.Visible = true;
                    cmbeq7.Visible = true;
                    cmbeq8.Visible = true;
                    cmbeq9.Visible = true;
                    cmbeq10.Visible = true;
                    cmbeq11.Visible = true;
                    cmbeq12.Visible = true;

                    lbleq1.Visible = true;
                    lbleq2.Visible = true;
                    lbleq3.Visible = true;
                    lbleq4.Visible = true;
                    lbleq5.Visible = true;
                    lbleq6.Visible = true;
                    lbleq7.Visible = true;
                    lbleq8.Visible = true;
                    lbleq9.Visible = true;
                    lbleq10.Visible = true;
                    lbleq11.Visible = true;
                    lbleq12.Visible = true;

                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox8.Visible = true;
                    textBox7.Visible = true;
                    textBox6.Visible = true;
                    textBox5.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Visible = true;
                }


                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string eqname = "";
            string quantity;
            string dequantity;
            string totalqty;
            var list = new List<String>();
            var name = Form1.setfirstname + " " + Form1.setlastname;

           

            string eqres1 = cmbeq1.Text.ToString() + "(" + textBox1.Text.ToString() + ")";
            string eqres2 = cmbeq2.Text.ToString() + "(" + textBox2.Text.ToString() + ")";
            string eqres3 = cmbeq3.Text.ToString() + "(" + textBox3.Text.ToString() + ")";
            string eqres4 = cmbeq4.Text.ToString() + "(" + textBox4.Text.ToString() + ")";
            string eqres5 = cmbeq5.Text.ToString() + "(" + textBox5.Text.ToString() + ")";
            string eqres6 = cmbeq6.Text.ToString() + "(" + textBox6.Text.ToString() + ")";
            string eqres7 = cmbeq7.Text.ToString() + "(" + textBox12.Text.ToString() + ")";
            string eqres8 = cmbeq8.Text.ToString() + "(" + textBox11.Text.ToString() + ")";
            string eqres9 = cmbeq9.Text.ToString() + "(" + textBox10.Text.ToString() + ")";
            string eqres10 = cmbeq10.Text.ToString() + "(" + textBox9.Text.ToString() + ")";
            string eqres11 = cmbeq11.Text.ToString() + "(" + textBox8.Text.ToString() + ")";
            string eqres12 = cmbeq12.Text.ToString() + "(" + textBox7.Text.ToString() + ")";
            var selectedequip = new List<string>();
            try
            {

                if (textBox1.Text != "")
                {
                    selectedequip.Add(eqres1);
                }
                if (textBox2.Text != "")
                {
                    selectedequip.Add(eqres2);
                }
                if (textBox3.Text != "")
                {
                    selectedequip.Add(eqres3);
                }
                if (textBox4.Text != "")
                {
                    selectedequip.Add(eqres4);
                }
                if (textBox5.Text != "")
                {
                    selectedequip.Add(eqres5);
                }
                if (textBox6.Text != "")
                {
                    selectedequip.Add(eqres6);
                }
                if (textBox12.Text != "")
                {
                    selectedequip.Add(eqres7);
                }
                if (textBox11.Text != "")
                {
                    selectedequip.Add(eqres8);
                }
                if (textBox10.Text != "")
                {
                    selectedequip.Add(eqres9);
                }
                if (textBox9.Text != "")
                {
                    selectedequip.Add(eqres10);
                }
                if (textBox8.Text != "")
                {
                    selectedequip.Add(eqres11);
                }
                if (textBox7.Text != "")
                {
                    selectedequip.Add(eqres12);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string allequip = string.Join(", ", selectedequip);
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select availableqty,totalqty from equipments where facilityname = '"+facilitycb.SelectedItem.ToString()+"'";
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
    }
}
