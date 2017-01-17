using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class ConnectionDatabaseForm : Form
    {
        public ConnectionDatabaseForm()
        {
            InitializeComponent();
        }

        private void ConnectionDatabaseForm_Load(object sender, EventArgs e)
        {

            string connStr = "server=localhost;user=root;database=Taoge;port=3306;password=tiger;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
    }
}
