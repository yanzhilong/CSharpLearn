using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrRepairs.model;
using xyz.ibean.data.dao;
using xyz.ibean.model;

namespace xyz.ibean.data
{
    /// <summary>
    /// 数据仓库
    /// </summary>
    public class Repository : IDataSource
    {
        private IDataSource MyIdataSource;

        private static String Lock = "lock";
        private static Repository repositore;
        public static Repository newInstance()
        {
            Monitor.Enter(Lock);						//锁定当前线程
            if (repositore == null)
            {
                repositore = new Repository();
            }
            Monitor.Exit(Lock);
            return repositore;
        }

        private Repository()
        {
            //这里根据不同的实现来实例化相应的实现类，可以通过读取配置文件
            MyIdataSource = new MySqlDataSource();
        }

        public Location addLocation(Location location)
        {
            return MyIdataSource.addLocation(location);
        }

        public bool deleteLocation(string locationId)
        {
            return MyIdataSource.deleteLocation(locationId);
        }

        public bool updateLocation(Location location)
        {
            return MyIdataSource.updateLocation(location);
        }

        public List<Location> getLocations()
        {
            return MyIdataSource.getLocations();
        }

        public List<Location> getLocationById(string locationId)
        {
            throw new NotImplementedException();
        }

        public List<Location> getLocationsById(string locationId)
        {
            throw new NotImplementedException();
        }

        public List<Location> getLocationsByQuery(string locationstr)
        {
            throw new NotImplementedException();
        }
    }
}
