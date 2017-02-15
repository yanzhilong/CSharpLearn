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

        MySqlDataAdapter mysqlda;
        SqlDataAdapter sda;
        DataSet ds;
        private void loaddata_Click(object sender, EventArgs e)
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || loadsql.Text != "")
                        {
                            string sql = loadsql.Text.Trim(); ;
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                            mysqlda = new MySqlDataAdapter();
                            mysqlda.SelectCommand = cmd;
                            ds = new DataSet();
                            mysqlda.Fill(ds, "cs");
                            dataGridView1.DataSource = ds.Tables[0];
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
                        if (SqlServerconn.State == ConnectionState.Open || loadsql.Text != "")
                        {
                            SqlCommand sqlcmd = new SqlCommand(loadsql.Text.Trim(), SqlServerconn);
                            sda = new SqlDataAdapter();
                            sda.SelectCommand = sqlcmd;
                            ds = new DataSet();
                            sda.Fill(ds, "cs");
                            dataGridView1.DataSource = ds.Tables[0];
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idtb.Text = dataGridView1.SelectedCells[0].Value.ToString();
            nametb.Text = dataGridView1.SelectedCells[1].Value.ToString();
            agetb.Text = dataGridView1.SelectedCells[2].Value.ToString();
            //dataGridView1.SelectedRows[0].Cells[""].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:
                    DataTable dtmysql = ds.Tables["cs"];
                    mysqlda.FillSchema(dtmysql, SchemaType.Mapped);//把表结构加载到表中
                    DataRow drmysql = dtmysql.Rows.Find(idtb.Text);//创建行，传入id
                    drmysql["name"] = nametb.Text.Trim();//设置值
                    drmysql["age"] = agetb.Text.Trim();
                    //将表数据更新到数据库中
                    MySqlCommandBuilder cmdbuidermysql = new MySqlCommandBuilder(mysqlda);
                    mysqlda.Update(dtmysql);

                    break;
                case DatabaseType.SQLSERVER:

                    DataTable dtsql = ds.Tables["cs"];
                    sda.FillSchema(dtsql, SchemaType.Mapped);//把表结构加载到表中
                    DataRow dr = dtsql.Rows.Find(idtb.Text);//创建行，传入id
                    dr["name"] = nametb.Text.Trim();//设置值
                    dr["age"] = agetb.Text.Trim();
                    //将表数据更新到数据库中
                    SqlCommandBuilder cmdbuider = new SqlCommandBuilder(sda);
                    sda.Update(dtsql);
                    break;
                default:
                    break;
            }

            
        }

        DataSet ds1;
        private void button6_Click(object sender, EventArgs e)
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || loadsqlnew.Text != "")
                        {
                            string sql = loadsqlnew.Text.Trim(); ;
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                            mysqlda = new MySqlDataAdapter();
                            mysqlda.SelectCommand = cmd;
                            ds1 = new DataSet();
                            mysqlda.Fill(ds1, "cs");
                            dataGridView1.DataSource = ds1.Tables[0];
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
                        if (SqlServerconn.State == ConnectionState.Open || loadsqlnew.Text != "")
                        {
                            SqlCommand sqlcmd = new SqlCommand(loadsqlnew.Text.Trim(), SqlServerconn);
                            sda = new SqlDataAdapter();
                            sda.SelectCommand = sqlcmd;
                            ds1 = new DataSet();
                            sda.Fill(ds1, "cs");
                            dataGridView1.DataSource = ds1.Tables[0];
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.Merge(ds1, true, MissingSchemaAction.AddWithKey);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ds1 = ds.Copy();
            dataGridView1.DataSource = ds1.Tables[0];
        }

        MySqlDataAdapter mysqlAdapter;
        SqlDataAdapter sqlAdapter;
        int maxIndex = 0;
        private void button11_Click(object sender, EventArgs e)
        {
            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || tabletb.Text != "")
                        {
                            string sql = "select * from " + tabletb.Text.Trim();
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);

                            MySqlCommand cmdcount = new MySqlCommand("select count(*) from " + tabletb.Text, MySqlconn);
                            maxIndex = int.Parse(cmdcount.ExecuteScalar().ToString());

                            mysqlAdapter = new MySqlDataAdapter();
                            mysqlAdapter.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            mysqlAdapter.Fill(ds, "cs");
                            dataGridView2.DataSource = ds.Tables[0];

                            
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
                        if (SqlServerconn.State == ConnectionState.Open || tabletb.Text != "")
                        {
                            string sql = "select * from " + tabletb.Text.Trim();
                            SqlCommand sqlcmd = new SqlCommand(sql, SqlServerconn);

                            SqlCommand cmdcount = new SqlCommand("select count(*) from " + tabletb.Text, SqlServerconn);
                            maxIndex = int.Parse(cmdcount.ExecuteScalar().ToString());

                            sqlAdapter = new SqlDataAdapter();
                            sqlAdapter.SelectCommand = sqlcmd;
                            DataSet ds = new DataSet();
                            sqlAdapter.Fill(ds, "cs");
                            dataGridView2.DataSource = ds.Tables[0];
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
            //设置标题不显示
            dataGridView2.RowHeadersVisible = false;
            //循环设置列宽
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.Columns[i].Width = 84;
            }
            //设置第一列只读不可更改
            dataGridView2.Columns[0].ReadOnly = true;


            refreshMessage();
        }

        //取一条数据
        public void dsResult(int currentIndex)
        {
            
            DataSet dataSet = new DataSet("cs");

            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    mysqlAdapter.Fill(dataSet, currentIndex, 1, "cs");

                    break;
                case DatabaseType.SQLSERVER:

                    sqlAdapter.Fill(dataSet, currentIndex, 1, "cs");

                    break;
                default:
                    break;
            }
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        int i = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            i = 0;
            dsResult(i);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            i -= 1;
            if (i < 0)
            {
                i += 1;
            }
            dsResult(i);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            i += 1;
            if (i > (maxIndex - 1))
            {
                i -= 1;
            }
            dsResult(i);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            i = maxIndex - 1;
            dsResult(i);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string msg = String.Format("第{0}行,第{1}列", dataGridView2.CurrentCell.RowIndex,
dataGridView2.CurrentCell.ColumnIndex);
            result.Append(msg + "\n");
            refreshMessage();
        }
        int intindex = 0;
        private void button13_Click(object sender, EventArgs e)
        {
            //string strSql = "select * from tb_emp";
            //DataTable dtUpdate = new DataTable();
            //dtUpdate = this.dbconn(strSql);
            //DataTable dtShow = new DataTable();
            //dtShow = (DataTable)this.dataGridView1.DataSource;
            //dtUpdate.ImportRow(dtShow.Rows[intindex]);
            //SqlCommandBuilder CommandBuiler;
            //CommandBuiler = new SqlCommandBuilder(this.adapter);
            //this.adapter.Update(dtUpdate);
            //dtUpdate.AcceptChanges();


            switch (databasetypeenum)
            {
                case DatabaseType.MYSQL:

                    try
                    {
                        if (MySqlconn.State == ConnectionState.Open || tabletb.Text != "")
                        {
                            //选获取数据库的值
                            string sql = "select * from " + tabletb.Text.Trim();
                            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);

                            mysqlAdapter = new MySqlDataAdapter();
                            mysqlAdapter.SelectCommand = cmd;
                            DataTable dtUpdate = new DataTable();
                            mysqlAdapter.Fill(dtUpdate);
                            //共聚当前列表行的值
                            DataTable dtShow = new DataTable();
                            dtShow = (DataTable)this.dataGridView2.DataSource;
                            //修改多行
                            for(int i = 0; i < dtShow.Rows.Count; i++)
                            {
                                dtUpdate.ImportRow(dtShow.Rows[i]);
                            }
                            //修改单行
                            //dtUpdate.ImportRow(dtShow.Rows[intindex]);
                            //可以在这里打开连接
                            MySqlCommandBuilder CommandBuiler;
                            CommandBuiler = new MySqlCommandBuilder(mysqlAdapter);
                            mysqlAdapter.Update(dtUpdate);
                            //可以在这里关闭连接
                            dtUpdate.AcceptChanges();

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
                        if (SqlServerconn.State == ConnectionState.Open || tabletb.Text != "")
                        {
                            //string sql = "select * from " + tabletb.Text.Trim();
                            //SqlCommand sqlcmd = new SqlCommand(sql, SqlServerconn);

                            //sqlAdapter = new SqlDataAdapter();
                            //sqlAdapter.SelectCommand = sqlcmd;
                            //DataSet ds = new DataSet();
                            //sqlAdapter.Fill(ds, "cs");
                            //dataGridView2.DataSource = ds.Tables[0];


                            //选获取数据库的值
                            string sql = "select * from " + tabletb.Text.Trim();
                            SqlCommand sqlcmd = new SqlCommand(sql, SqlServerconn);

                            sqlAdapter = new SqlDataAdapter();
                            sqlAdapter.SelectCommand = sqlcmd;
                            DataTable dtUpdate = new DataTable();
                            sqlAdapter.Fill(dtUpdate);

                            DataTable dtShow = new DataTable();
                            dtShow = (DataTable)this.dataGridView2.DataSource;

                            //修改多行
                            for (int i = 0; i < dtShow.Rows.Count; i++)
                            {
                                dtUpdate.ImportRow(dtShow.Rows[i]);
                            }
                            //修改单行
                            //dtUpdate.ImportRow(dtShow.Rows[intindex]);
                            //可以在这里打开连接
                            SqlCommandBuilder cmdbuider = new SqlCommandBuilder(sqlAdapter);
                            sqlAdapter.Update(dtUpdate);
                            //可以在这里关闭连接
                            dtUpdate.AcceptChanges();
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intindex = e.RowIndex;//得到当前行
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // 指定DataGridView控件显示的列数
            dataGridView2.ColumnCount = 4;
            dataGridView2.ColumnHeadersVisible = true;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //设置DataGridView控件的标题列名
            dataGridView2.Columns[0].Name = "编号";
            dataGridView2.Columns[1].Name = "姓名";
            dataGridView2.Columns[2].Name = "年龄";
            dataGridView2.Columns[3].Name = "性别";
            // Populate the rows.
            string[] row1 = new string[] { "0001", "小吕", "28",
        "男" };
            string[] row2 = new string[] { "0002", "小张",
        "27", "男" };
            string[] row3 = new string[] { "0003", "小郭",
        "24", "女" };
            string[] row4 = new string[] { "0004", "小贯",
        "21", "女" };
            string[] row5 = new string[] { "0005", "小陈",
        "20", "女" };
            string[] row6 = new string[] { "0006", "小梁",
        "23", "男" };
            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };
            foreach (string[] rowArray in rows)
            {
                dataGridView2.Rows.Add(rowArray);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn comboboxColumn = new DataGridViewComboBoxColumn();
            comboboxColumn.Name = "学生编号";
            this.dataGridView2.Columns.Add(comboboxColumn);
            //SqlConnection con = new SqlConnection("server=.;uid=sa;pwd=;database=db_16");
            //con.Open();
            //SqlCommand com = new SqlCommand("select * from tb_teacher", con);
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboboxColumn.Items.Add(dr[0].ToString());
            //}
            //dr.Close();
            //con.Close();
            comboboxColumn.Items.Add("abcd");
            comboboxColumn.Items.Add("abcd");
            comboboxColumn.Items.Add("abcd");
            comboboxColumn.Items.Add("abcd");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
