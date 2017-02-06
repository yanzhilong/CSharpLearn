using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyz.ibean.config;

namespace xyz.ibean.model
{
    /// <summary>
    /// MySql数据库操作类
    /// </summary>
    class MySqlModule
    {
        //private MySqlConnection MySqlconn = null;//MySql连接
        private MySqlDataAdapter mySqlDataAdapter;//适配器

        /// <summary>
        /// 连接数据库
        /// </summary>
        public MySqlConnection openConnection()
        {
            MySqlConnection MySqlconn = new MySqlConnection(ApplicationConfig.mysql_connection);   //创建连接
            MySqlconn.Open();  //打开数据库连接
            return MySqlconn;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void closeConnection(MySqlConnection MySqlconn)
        {
            if (MySqlconn != null && MySqlconn.State == ConnectionState.Open)   //判断是否打开与数据库的连接
            {
                MySqlconn.Close();   //关闭数据库的连接
                MySqlconn.Dispose();   //释放My_con变量的所有空间
            }
        }

        /// <summary>
        /// 普通的增删改查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int query(String sql)
        {
            MySqlConnection MySqlconn = openConnection();
            int result = 0;
            openConnection();   //打开与数据库的连接
            if (MySqlconn.State == ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                closeConnection(MySqlconn);
            }
            return result;
        }

        /// <summary>
        /// 请求查询sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public MySqlDataReader queryData(String sql, MySqlConnection MySqlconn)
        {
            if (MySqlconn.State == ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                MySqlDataReader sdr = cmd.ExecuteReader();
                return sdr;
            }
            return null;
        }

        /// <summary>
        /// 连接数据库，并放入表信息
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet queryData(String sql,String tableName, MySqlConnection MySqlconn)
        {
            openConnection();   //打开与数据库的连接
            if (MySqlconn.State == ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                MySqlDataAdapter mysqlda = new MySqlDataAdapter();
                mysqlda.SelectCommand = cmd;
                DataSet ds = new DataSet(); //创建DataSet对象
                mysqlda.Fill(ds, tableName);
                closeConnection(MySqlconn);//这里可以关闭数据库
                return ds;
            }
            return null;
        }
    }
}
