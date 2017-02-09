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

        /// <summary>
        /// 连接数据库，并放入表信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable queryDataTable(String sql)
        {
            MySqlConnection MySqlconn = openConnection();   //打开与数据库的连接
            if (MySqlconn.State == ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                MySqlDataAdapter mysqlda = new MySqlDataAdapter();
                mysqlda.SelectCommand = cmd;
                DataTable dt = new DataTable(); //创建DataSet对象
                mysqlda.Fill(dt);
                closeConnection(MySqlconn);//这里可以关闭数据库
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 批量更新表数据
        /// </summary>
        /// <param name="seleceSql"></param>
        /// <param name="dtUpdate"></param>
        /// <returns></returns>
        public int update(string seleceSql, DataTable dtUpdate)
        {
            int result = 0;
            using (MySqlConnection MySqlconn = openConnection())
            {
                //使用加强读写锁事务 
                MySqlTransaction tran = MySqlconn.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    //选获取数据库的值
                    MySqlCommand cmd = new MySqlCommand(seleceSql, MySqlconn);

                    MySqlDataAdapter mysqlAdapter = new MySqlDataAdapter();
                    mysqlAdapter.SelectCommand = cmd;
                    DataTable dtSource = new DataTable();
                    mysqlAdapter.Fill(dtSource);
                    //共聚当前列表行的值
                    //DataTable dtShow = new DataTable();
                    //dtShow = (DataTable)this.dataGridView2.DataSource;
                    //修改多行
                    for (int i = 0; i < dtUpdate.Rows.Count; i++)
                    {
                        dtSource.ImportRow(dtUpdate.Rows[i]);
                    }
                    //修改单行
                    //dtUpdate.ImportRow(dtShow.Rows[intindex]);
                    //可以在这里打开连接
                    MySqlCommandBuilder CommandBuiler;
                    CommandBuiler = new MySqlCommandBuilder(mysqlAdapter);
                    mysqlAdapter.Update(dtSource);
                    //可以在这里关闭连接
                    dtSource.AcceptChanges();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
                finally
                {
                    MySqlconn.Dispose();
                    MySqlconn.Close();
                }
            }
            return result;
        }





        /// <param name="table">准备更新的DataTable新数据</param>
        /// <param name="TableName">对应要更新的数据库表名</param>
        /// <param name="primaryKeyName">对应要更新的数据库表的主键名</param>
        /// <param name="columnsName">对应要更新的列的列名集合</param>
        /// <param name="limitColumns">需要在ＳＱＬ的ＷＨＥＲＥ条件中限定的条件字符串，可为空。</param>
        /// <param name="onceUpdateNumber">每次往返处理的行数</param>
        /// <returns>返回更新的行数</returns>
        public int Update(DataTable table, string TableName, string primaryKeyName, string[] columnsName, string limitWhere, int onceUpdateNumber)
        {
            if (string.IsNullOrEmpty(TableName)) return 0;
            if (string.IsNullOrEmpty(primaryKeyName)) return 0;
            if (columnsName == null || columnsName.Length <= 0) return 0;
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            int result = 0;
            
            using (MySqlConnection MySqlconn = openConnection())
            {

                //使用加强读写锁事务 
                MySqlTransaction tran = MySqlconn.BeginTransaction(IsolationLevel.ReadCommitted);
                //SqlTransaction tran = sqlconn.BeginTransaction();
                try
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //所有行设为修改状态   
                        dr.SetModified();
                    }
                    //为Adapter定位目标表   
                    //SqlCommand cmd = new SqlCommand(string.Format("select * from {0} where {1}", TableName, limitWhere), sqlconn, tran);

                    string sql = string.Format("select * from {0} where {1}", TableName, limitWhere);
                    MySqlCommand cmd = new MySqlCommand(sql, MySqlconn,tran);
                    MySqlDataAdapter mysqlda = new MySqlDataAdapter();
                    mysqlda.SelectCommand = cmd;

                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(da);
                    //da.AcceptChangesDuringUpdate = false;

                    MySqlCommandBuilder mysqlCmdBuilder = new MySqlCommandBuilder(mysqlda);
                    mysqlda.AcceptChangesDuringUpdate = false;

                    string columnsUpdateSql = "";
                    //SqlParameter[] paras = new SqlParameter[columnsName.Length];

                    MySqlParameter[] paras = new MySqlParameter[columnsName.Length];
                    //需要更新的列设置参数是,参数名为"@+列名"
                    for (int i = 0; i < columnsName.Length; i++)
                    {
                        //此处拼接要更新的列名及其参数值
                        columnsUpdateSql += ("[" + columnsName[i] + "]" + "=@" + columnsName[i] + ",");
                        paras[i] = new MySqlParameter("@" + columnsName[i], columnsName[i]);
                    }
                    if (!string.IsNullOrEmpty(columnsUpdateSql))
                    {
                        //此处去掉拼接处最后一个","
                        columnsUpdateSql = columnsUpdateSql.Remove(columnsUpdateSql.Length - 1);
                    }
                    //此处生成where条件语句
                    string limitSql = ("[" + primaryKeyName + "]" + "=@" + primaryKeyName);
                    //SqlCommand updateCmd = new SqlCommand(string.Format(" UPDATE [{0}] SET {1} WHERE {2} ", TableName, columnsUpdateSql, limitSql));

                    string updateSql = string.Format(" UPDATE [{0}] SET {1} WHERE {2} ", TableName, columnsUpdateSql, limitSql);
                    MySqlCommand updateCmd = new MySqlCommand(updateSql);
                    //不修改源DataTable   
                    updateCmd.UpdatedRowSource = UpdateRowSource.None;
                    mysqlda.UpdateCommand = updateCmd;
                    mysqlda.UpdateCommand.Parameters.AddRange(paras);
                    mysqlda.UpdateCommand.Parameters.AddWithValue("@" + primaryKeyName, primaryKeyName);
                    //每次往返处理的行数
                    mysqlda.UpdateBatchSize = onceUpdateNumber;
                    result = mysqlda.Update(ds, TableName);
                    ds.AcceptChanges();
                    tran.Commit();

                }
                catch
                {
                    tran.Rollback();
                }
                finally
                {
                    MySqlconn.Dispose();
                    MySqlconn.Close();
                }


            }
            return result;
        }
    }
}
