using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Function_Hall_Reservation_System.Connection
{
    class Connection
    {
        public static SqlConnection conn;
        private static string dbconnect = "Data Source=WIN-8IJEV42BG6T\\SQLEXPRESS;Initial Catalog=FunctionHallReservation;Integrated Security=True";

        public static void DB()
        {

            try
            {
                conn = new SqlConnection(dbconnect);
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
