using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Function_Hall_Reservation_System.Functions
{
    class Functions
    {
        public static string gen = ""; //variable to hold SQL Statements
        //public static SqlConnection conn;
        public static SqlCommand command; //process the sql statements

        public static SqlDataReader reader; //retrieve data from the database

        public static void fill(string q, DataGridView dgv)
        {
            try
            {
                Connection.Connection.DB();
                DataTable dt = new DataTable();
                SqlDataAdapter data = null;
                SqlCommand command = new SqlCommand(q, Connection.Connection.conn);
                data = new SqlDataAdapter(command);
                data.Fill(dt);
                dgv.DataSource = dt;//retrieve all the records and display it
                //in  the datagridview
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
