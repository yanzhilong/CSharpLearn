using CrRepairs.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyz.ibean.model;

namespace xyz.ibean.data.dao
{
    /// <summary>
    /// 数据接口
    /// </summary>
    interface IDataSource
    {
        /// <summary>
        /// 登陆用户
        /// </summary>
        /// <param name="location">要添加的地址实体</param>
        /// <returns></returns>
        Location addLocation(Location location);

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        bool deleteLocation(string locationId);

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        bool updateLocation(Location location);

        /// <summary>
        /// 获得所有的地址信息
        /// </summary>
        /// <returns></returns>
        List<Location> getLocations();

        /// <summary>
        /// 查询某一个地址
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        List<Location> getLocationById(string locationId);

        /// <summary>
        /// 查询某一个地址下面的所有子地址信息
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        List<Location> getLocationsById(string locationId);

        /// <summary>
        /// 根据关键字查询地址信息
        /// </summary>
        /// <param name="locationstr"></param>
        /// <returns></returns>
        List<Location> getLocationsByQuery(string locationstr);
    }
}
