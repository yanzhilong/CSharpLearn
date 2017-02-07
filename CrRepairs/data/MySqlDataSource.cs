﻿using MySql.Data.MySqlClient;
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
                "'" + location.LocationPath + "'" +
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

        public List<Location> getLocationById(string locationId)
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
                        location.LocationPath = sdr.GetString(6);
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
            throw new NotImplementedException();
        }

        public List<Location> getLocationsByQuery(string locationstr)
        {
            throw new NotImplementedException();
        }

        public bool updateLocation(Location location)
        {
            String sql = "update location set" +
                "LocationPID = " + "'" + location.LocationPID + "'," +
                "LocationName = " + "'" + location.LocationName + "'," +
                "LocationCode = " + "'" + location.LocationCode + "'," +
                "LocationFullName = " + "'" + location.LocationFullName + "'," +
                "LocationLevel = " + "'" + location.LocationLevel + "'," +
                "LocationPath = " + "'" + location.LocationPath +
                "')";

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
    }
}