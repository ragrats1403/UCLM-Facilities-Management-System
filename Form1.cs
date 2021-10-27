using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Function_Hall_Reservation_System
{
    public partial class Form1 : Form
    {
        public static string setfirstname = "";
        public static string setlastname = "";
        public static string setstudentid = "";
        public static string setfullname = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration.Registration registration = new Registration.Registration();
            this.Visible = false;
            registration.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            int roleid;
            try
            {
                Connection.Connection.DB();
                Functions.Functions.gen = "Select * from users where studentid='" + txtusername.Text + "' AND password='" + txtpassword.Text + "'";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, Connection.Connection.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

                if (Functions.Functions.reader.HasRows)
                {
                    Functions.Functions.reader.Read();
                    roleid = Convert.ToInt32(Functions.Functions.reader["roleid"]);

                  


                        //1=1?
                        if (roleid == 1)
                        {
                            txtusername.Text = Functions.Functions.reader["studentid"].ToString();
                            txtpassword.Text = Functions.Functions.reader["password"].ToString();

                            setfirstname = Functions.Functions.reader["firstname"].ToString();
                            setlastname = Functions.Functions.reader["lastname"].ToString();
                            setstudentid = txtusername.Text;
                            var name = setfirstname + " " + setlastname;
                            setfullname = name;
                            //open the next form
                            Student.StudentCalendar student = new Student.StudentCalendar();
                            this.Visible = false;//closing the form
                            student.Show();//shows the next form

                        }
                        else if (roleid == 2)
                        {
                            txtusername.Text = Functions.Functions.reader["studentid"].ToString();
                            txtpassword.Text = Functions.Functions.reader["password"].ToString();

                            setfirstname = Functions.Functions.reader["firstname"].ToString();
                            setlastname = Functions.Functions.reader["lastname"].ToString();
                            //open the next form
                            var name = setfirstname + " " + setlastname;
                            setfullname = name;
                            WorkingStudent.CalendarOfActivities moderator = new WorkingStudent.CalendarOfActivities();
                            this.Visible = false;//closing the form
                            moderator.Show();//shows the next form


                        }
                        else if (roleid == 3)
                        {
                            txtusername.Text = Functions.Functions.reader["studentid"].ToString();
                            txtpassword.Text = Functions.Functions.reader["password"].ToString();

                            setfirstname = Functions.Functions.reader["firstname"].ToString();
                            setlastname = Functions.Functions.reader["lastname"].ToString();
                            //open the next form
                            var name = setfirstname + " " + setlastname;
                            setfullname = name;
                            Admin.CalendarOfActivities admin = new Admin.CalendarOfActivities();
                            this.Visible = false;//closing the form
                            admin.Show();//shows the next form
                        }
                        else
                        {
                            MessageBox.Show("Wrong Credentials!");

                        }
                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("See you next time!");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Guest.StudentCalendar guest = new Guest.StudentCalendar();
            this.Visible = false;
            guest.Show();
        }
    }
    }
