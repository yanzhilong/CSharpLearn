using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    enum DatabaseType
    {
        MYSQL,
        SQLSERVER
    }

    public partial class ConnectionDatabaseForm : Form
    {

        private string userstr = "";
        private string passwrodstr = "";
        private string serverstr = "";
        private string databasestr = "";
        private string portstr = "";
        private DatabaseType databasetypeenum;

        private StringBuilder result = new StringBuilder();
        MySqlConnection MySqlconn = null;//MySql连接
        SqlConnection SqlServerconn = null;//SqlServer连接
        public ConnectionDatabaseForm()
        {
            InitializeComponent();
        }

        private void ConnectionDatabaseForm_Load(object sender, EventArgs e)
        {

            //初始化数据库项数据
            databasttype.Items.Add("Sql Server");
            databasttype.Items.Add("MySql");
            databasttype.SelectedIndex = 0;//设置初始
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkoutInput())
            {
                return;
            }
            
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:
                    connectionMySql();
                    break;
                case DatabaseType.SQLSERVER:
                    connectionSqlServer();
                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// 检测输入数据
        /// </summary>
        /// <returns></returns>
        private bool checkoutInput()
        {
            if (database.Text == "" || server.Text == "" || user.Text == "" || password.Text == "")
            {
                MessageBox.Show("请输入数据");
                return false;
            }else{
                userstr = user.Text.Trim();
                passwrodstr = password.Text.Trim();
                serverstr = server.Text.Trim();
                databasestr = database.Text.Trim();
                portstr = port.Text.Trim();
                databasetypeenum = databasttype.SelectedIndex == 0 ? DatabaseType.SQLSERVER : DatabaseType.MYSQL;
                }
            return true;
        }

        /// <summary>
        /// 连接MySql数据库
        /// </summary>
        private void connectionMySql()
        {
            string conStr = 
                "server=" + serverstr + ";" + 
                "port=" + portstr + ";" +
                "database=" + databasestr + ";"+
                "user=" + userstr + ";"+
                "password=" + passwrodstr;
            //string conStr = "server=localhost;user=root;database=Mysql;port=3306;password=tiger;";
            MySqlconn = new MySqlConnection(conStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                MySqlconn.Open();

                if (MySqlconn.State == ConnectionState.Open)
                {
                    result.Append("数据库【" + databasestr + "】已经连接并打开\n");
                    refreshMessage();
                }
                // Perform database operations

                string sql = "SELECT count(*) FROM user";
                MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("共有数据" + i + "条");
                //MySqlDataReader rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 连接SqlServer
        /// </summary>
        private void connectionSqlServer()
        {
            try
            {
                string ConStr = "server=" + serverstr + ";database=" + databasestr + ";uid=" + userstr + ";pwd=" + passwrodstr;
                SqlServerconn = new SqlConnection(ConStr);
                SqlServerconn.Open();
                if (SqlServerconn.State == ConnectionState.Open)
                {
                    result.Append("数据库【" + databasestr + "】已经连接并打开\n");
                    refreshMessage();
                }
            }
            catch
            {
                result.Append("连接数据库失败\n");
                refreshMessage();
            }
        }

        /// <summary>
        /// 更新输出信息
        /// </summary>
        private void refreshMessage()
        {
            connectionresult.Text = result.ToString();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        private void closeDatabase()
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:
                    if(MySqlconn != null)
                    {
                        MySqlconn.Close();
                        if (MySqlconn.State == ConnectionState.Closed)
                        {
                            result.Append("数据库已经成功关闭\n");
                        }
                    }
                    break;
                case DatabaseType.SQLSERVER:
                    if (SqlServerconn != null)
                    {
                        SqlServerconn.Close();
                        if (SqlServerconn.State == ConnectionState.Closed)
                        {
                            result.Append("数据库已经成功关闭\n");
                        }
                    }
                    break;
                default:
                    break;
            }
            refreshMessage();
        }

        /// <summary>
        /// 释放连接
        /// </summary>
        private void disposeDatabase()
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:
                    if (MySqlconn != null && MySqlconn.State == ConnectionState.Open || MySqlconn.State == ConnectionState.Closed)
                    {
                        MySqlconn.Dispose();
                        result.Append("数据库释放\n");
                    }
                    break;
                case DatabaseType.SQLSERVER:
                    if (SqlServerconn != null && SqlServerconn.State == ConnectionState.Open || SqlServerconn.State == ConnectionState.Closed)
                    {
                        SqlServerconn.Dispose();
                        result.Append("数据库释放\n");
                    }
                    break;
                default:
                    break;
            }
            refreshMessage();
        }

        /// <summary>
        /// 重新打开
        /// </summary>
        private void openDatabaseAgain()
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:
                    try
                    {
                        MySqlconn.Open();
                        if (MySqlconn.State == ConnectionState.Open)
                        {
                            result.Append("数据库【" + databasestr + "】已经连接并打开\n");
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                    }
                    
                    break;
                case DatabaseType.SQLSERVER:
                    try
                    {
                        SqlServerconn.Open();
                        if (SqlServerconn.State == ConnectionState.Open)
                        {
                            result.Append("数据库【" + databasestr + "】已经连接并打开\n");
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                    }
                    break;
                default:
                    break;
            }
            refreshMessage();
        }


        private void databasttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("下拉改变");
            port.Text = databasttype.SelectedIndex == 0 ? "1433" : "3306";
        }

        
        private void close_Click(object sender, EventArgs e)
        {
            closeDatabase();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            disposeDatabase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openDatabaseAgain();
        }

        private void selectCount_Click(object sender, EventArgs e)
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                   

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || tablename.Text != "")
                        {
                            string sql = "SELECT count(*) FROM " + tablename.Text.Trim(); ;
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                            int i = Convert.ToInt32(cmd.ExecuteScalar());
                            result.Append("数据表中共有：" + i.ToString() + "条数据\n");
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                        refreshMessage();
                    }

                    break;
                case DatabaseType.SQLSERVER:

                    try
                    {
                        if (SqlServerconn.State == ConnectionState.Open || tablename.Text != "")
                        {
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = SqlServerconn;
                            sqlcmd.CommandText = "select count(*) from " + tablename.Text.Trim();
                            sqlcmd.CommandType = CommandType.Text;
                            int i = Convert.ToInt32(sqlcmd.ExecuteScalar());
                            result.Append("数据表中共有：" + i.ToString() + "条数据\n");
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message+"\n");
                        refreshMessage();
                    }

                    break;
                default:
                    break;
            }
            refreshMessage();
        }

        private void nonquery_Click(object sender, EventArgs e)
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || nonsql.Text != "")
                        {
                            string sql = nonsql.Text.Trim(); ;
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                            int i = Convert.ToInt32(cmd.ExecuteNonQuery());
                            result.Append("受影响的行数:" + i.ToString() + "\n");
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                        refreshMessage();
                    }

                    break;
                case DatabaseType.SQLSERVER:

                    try
                    {
                        if (SqlServerconn.State == ConnectionState.Open || nonsql.Text != "")
                        {
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = SqlServerconn;
                            sqlcmd.CommandText = nonsql.Text.Trim();
                            sqlcmd.CommandType = CommandType.Text;
                            int i = Convert.ToInt32(sqlcmd.ExecuteNonQuery());
                            result.Append("受影响的行数:" + i.ToString() + "\n");
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                        refreshMessage();
                    }

                    break;
                default:
                    break;
            }
            refreshMessage();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void readerquery_Click(object sender, EventArgs e)
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || readersql.Text != "")
                        {
                            string sql = readersql.Text.Trim(); ;
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                            MySqlDataReader sdr = cmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                result.Append(sdr[1].ToString() + "\n");
                            }
                            sdr.Close();
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                        refreshMessage();
                    }

                    break;
                case DatabaseType.SQLSERVER:

                    try
                    {
                        if (SqlServerconn.State == ConnectionState.Open || readersql.Text != "")
                        {
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = SqlServerconn;
                            sqlcmd.CommandText = readersql.Text.Trim();
                            sqlcmd.CommandType = CommandType.Text;

                            SqlDataReader sdr = sqlcmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                result.Append(sdr[1].ToString() + "\n");
                            }
                            sdr.Close();
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                        refreshMessage();
                    }

                    break;
                default:
                    break;
            }
            refreshMessage();
        }

        private void havevalue_Click(object sender, EventArgs e)
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || readersql.Text != "")
                        {
                            string sql = readersql.Text.Trim(); ;
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                            MySqlDataReader sdr = cmd.ExecuteReader();
                            sdr.Read();
                            if (sdr.HasRows)
                            {
                                result.Append("数据表中有值\n");
                                refreshMessage();
                            }
                            else
                            {
                                result.Append("数据表中没有任何数据\n");
                            }
                            sdr.Close();
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                        refreshMessage();
                    }

                    break;
                case DatabaseType.SQLSERVER:

                    try
                    {
                        if (SqlServerconn.State == ConnectionState.Open || readersql.Text != "")
                        {
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = SqlServerconn;
                            sqlcmd.CommandText = readersql.Text.Trim();
                            sqlcmd.CommandType = CommandType.Text;

                            SqlDataReader sdr = sqlcmd.ExecuteReader();
                            sdr.Read();
                            if (sdr.HasRows)
                            {
                                result.Append("数据表中有值\n");
                                refreshMessage();
                            }
                            else
                            {
                                result.Append("数据表中没有任何数据\n");
                            }
                            sdr.Close();
                            refreshMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Append(ex.Message + "\n");
                        refreshMessage();
                    }

                    break;
                default:
                    break;
            }
            refreshMessage();
        }
    }
}
