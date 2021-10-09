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
        private static string dbconnect = "Data Source=DAREDEV1L;Initial Catalog=uclmfacilitiesdatabase;Integrated Security=True";

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
