using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyz.ibean.model;
using CrRepairs.model;
using System.Data;
using System.Collections;
using System.Diagnostics;
using CrRepairs.util;

namespace xyz.ibean.data.dao
{
    class MySqlDataSource : IDataSource
    {
        private MySqlModule mySqlModule;

        public MySqlDataSource()
        {
            mySqlModule = new MySqlModule();
        }

        public Location addLocation(Location location)
        {
            //String sql = "select * from tb_Login where Name='" + user.Name + "' and Pass='" + user.Password + "'";
            String sql = "insert into location values(" + 
                "'" + location.LocationID + "'," + 
                "'" + location.LocationPID + "'," + 
                "'" + location.LocationName + "'," + 
                "'" + location.LocationCode + "'," + 
                "'" + location.LocationFullName + "'," +
                "'" + location.LocationLevel + "'," +
                "'" + location.CompanyID + "'" +
                ")";
            MySqlConnection MySqlconn = mySqlModule.openConnection();
            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
            try
            {
                int i = Convert.ToInt32(cmd.ExecuteNonQuery());
                return i > 0 ? location : null;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                mySqlModule.closeConnection(MySqlconn);
            }
            return null;
        }

        public bool deleteLocation(string locationId)
        {
            String sql = "delete from location where LocationID = '" + locationId + "'";
            MySqlConnection MySqlconn = mySqlModule.openConnection();
            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
            try
            {
                int i = Convert.ToInt32(cmd.ExecuteNonQuery());
                return i > 0 ? true : false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                mySqlModule.closeConnection(MySqlconn);
            }
            return false;
        }

        public Location getLocationById(string locationId)
        {
            throw new NotImplementedException();
        }

        public List<Location> getLocations()
        {
            List<Location> locations = new List<Location>();
            String sql = "select * from location";
            MySqlConnection MySqlconn = mySqlModule.openConnection();
            try
            {
                if (MySqlconn.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                    MySqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Location location = new Location();
                        location.LocationID = sdr.GetString(0);
                        location.LocationPID = sdr.GetString(1);
                        location.LocationName = sdr.GetString(2);
                        location.LocationCode = sdr.GetString(3);
                        location.LocationFullName = sdr.GetString(4);
                        location.LocationLevel = sdr.GetInt32(5);
                        locations.Add(location);
                    }
                    sdr.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                mySqlModule.closeConnection(MySqlconn);
            }
            return locations;
        }

        public List<Location> getLocationsById(string locationId)
        {
            List<Location> locations = new List<Location>();
            String sql = "select * from location where LocationPID = " + "'" + locationId + "'";
            MySqlConnection MySqlconn = mySqlModule.openConnection();
            try
            {
                if (MySqlconn.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                    MySqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Location location = new Location();
                        location.LocationID = sdr.GetString(0);
                        location.LocationPID = sdr.GetString(1);
                        location.LocationName = sdr.GetString(2);
                        location.LocationCode = sdr.GetString(3);
                        location.LocationFullName = sdr.GetString(4);
                        location.LocationLevel = sdr.GetInt32(5);
                        locations.Add(location);
                    }
                    sdr.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                mySqlModule.closeConnection(MySqlconn);
            }
            return locations;
        }

        public List<Location> getLocationsByQuery(string locationstr)
        {
            String sql = "";
            //判断是中文还是英文 
            if (StringUtil.containCN(locationstr))
            {
                sql = "select * from location where LocationFullName like " + "'%" + locationstr + "%'";
            }
            else
            {
                sql = "select * from location where LocationCode like " + "'%" + locationstr + "%'";
            }
            List<Location> locations = new List<Location>();
            MySqlConnection MySqlconn = mySqlModule.openConnection();
            try
            {
                if (MySqlconn.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
                    MySqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Location location = new Location();
                        location.LocationID = sdr.GetString(0);
                        location.LocationPID = sdr.GetString(1);
                        location.LocationName = sdr.GetString(2);
                        location.LocationCode = sdr.GetString(3);
                        location.LocationFullName = sdr.GetString(4);
                        location.LocationLevel = sdr.GetInt32(5);
                        locations.Add(location);
                    }
                    sdr.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                mySqlModule.closeConnection(MySqlconn);
            }
            return locations;
        }

        public bool updateLocation(Location location)
        {
            String sql = "update location set " +
                "LocationPID = " + "'" + location.LocationPID + "'," +
                "LocationName = " + "'" + location.LocationName + "'," +
                "LocationCode = " + "'" + location.LocationCode + "'," +
                "LocationFullName = " + "'" + location.LocationFullName + "'," +
                "LocationLevel = " + "'" + location.LocationLevel + "'" +
                "where LocationID = " + "'" + location.LocationID + "'" ;

            MySqlConnection MySqlconn = mySqlModule.openConnection();
            MySqlCommand cmd = new MySqlCommand(sql, MySqlconn);
            try
            {
                int i = Convert.ToInt32(cmd.ExecuteNonQuery());
                return i > 0 ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine("测试异常");
                Console.WriteLine(e.Message);
            }
            finally
            {
                mySqlModule.closeConnection(MySqlconn);
            }
            return false;
        }

        public bool updateLocations(List<Location> locations)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Location location in locations)
            {
                sb.Append("'" + location.LocationID + "'" + ",");
            }
            //此处去掉拼接处最后一个","
            string locationids = sb.ToString().Remove(sb.ToString().Length - 1);
            String sql = string.Format("select * from location where LocationID in ({0})", locationids);

            DataTable dt = mySqlModule.queryDataTable(sql);
            //循环修改值
            foreach (Location location in locations)
            {
                for(int j = 0; j < dt.Rows.Count; j++)
                {
                    if(dt.Rows[j]["LocationID"].ToString() == location.LocationID)
                    {
                        dt.Rows[j]["LocationName"] = location.LocationName;
                        dt.Rows[j]["LocationFullName"] = location.LocationFullName;
                        dt.Rows[j]["LocationCode"] = location.LocationCode;
                    }
                }
            }
            int i = mySqlModule.update(sql, dt);
            return i > 0 ? true : false;
        }
    }
}
