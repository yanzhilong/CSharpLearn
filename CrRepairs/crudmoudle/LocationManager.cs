using CrRepairs.model;
using CrRepairs.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrRepairs.crudmoudle
{
    class LocationManager
    {
        private Hashtable locationsTB;
        private Hashtable locationsTVTB;
        private Hashtable locationIDTB;
        private List<Location> locations;

        public Hashtable LocationsTB
        {
            get
            {
                return locationsTB;
            }

            set
            {
                locationsTB = value;
            }
        }

        public Hashtable LocationsTVTB
        {
            get
            {
                return locationsTVTB;
            }

            set
            {
                locationsTVTB = value;
            }
        }

        public Hashtable LocationIDTB
        {
            get
            {
                return locationIDTB;
            }

            set
            {
                locationIDTB = value;
            }
        }

        public List<Location> Locations
        {
            get
            {
                return locations;
            }

            set
            {
                locations = value;
            }
        }

        public void initLocations(List<Location> locations)
        {
            this.Locations = locations;
            LocationsTB = new Hashtable();
            LocationsTVTB = new Hashtable();
            LocationIDTB = new Hashtable();
            initIdAndTB();//初始化ID 地址和ID PID表
            initLocationTVTB();//初始化地址树
        }


        /// <summary>
        /// 初始化地址ID和地址表格
        /// </summary>
        private void initIdAndTB()
        {
            foreach (Location location in Locations)
            {
                LocationIDTB.Add(location.LocationID, location.LocationPID);
                LocationsTB.Add(location.LocationID, location);
            }
        }

        /// <summary>
        /// 初始化地址树
        /// </summary>
        private void initLocationTVTB()
        {
            //遍历位置数据
            foreach (Location location in Locations)
            {
                //查找当前locationID的目录树ID列表
                string[] locationtree = getLocationIDTree(location.LocationID);
                if (locationtree == null)
                {
                    //一个断的分支，不添加
                    continue;
                }
                //添加到位置树中
                addLocationTree(LocationsTVTB, locationtree);
            }
        }


        private List<Location> updateNameLocations;//更新名字
        /// <summary>
        /// 更新Location名字,同时更改子级的FullName和LocationCode
        /// </summary>
        /// <param name="locationID"></param>
        /// <param name="locationName"></param>
        /// <returns></returns>
        public List<Location> updateLocationName(string locationID, string locationName)
        {
            updateNameLocations = new List<Location>();
            //查找当前locationID的目录树ID列表
            string[] locationtree = getLocationIDTree(locationID);
            //查找当前目录树

            Hashtable hashtable = findLocationTB(locationtree, LocationsTVTB);
            Location location = null;
            foreach (DictionaryEntry dict in hashtable)
            {
                location = (Location)locationsTB[(string)dict.Key];
            }
            //遍历更新
            if (location != null)
            {
                Location locationP = (Location)locationsTB[location.LocationPID];
                location.LocationName = locationName;
                location.LocationFullName = locationP == null ? location.LocationName : locationP.LocationFullName + "-" + location.LocationName;
                location.LocationCode = locationP == null ? StringUtil.GetSpellCode(location.LocationName) : locationP.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
                location.LocationLevel = locationP == null ? 0 : locationP.LocationLevel + 1;
                updateNameLocations.Add(location);
                updateLocationFullNameAndLocationCode(hashtable);
            }
            else
            {
                return null;
            }
            return updateNameLocations;
        }



        private Hashtable findLocationTB(string[] locationtree, Hashtable locationsTB)
        {
            if (locationtree.Length == 0)
            {
                throw new ArgumentOutOfRangeException("地址树至少需要一个节点");
            }
            Hashtable tmphashtable = (Hashtable)locationsTB[locationtree[0]];
            if (locationtree.Length > 1)
            {
                //去除当前父节点，继续遍历子节点
                string[] strarray = new string[locationtree.Length - 1];
                Array.Copy(locationtree, 1, strarray, 0, strarray.Length);
                return findLocationTB(strarray, tmphashtable);
            }
            Hashtable hashtable = new Hashtable();
            hashtable.Add(locationtree[0], tmphashtable);
            return hashtable;

        }


        /// <summary>
        /// 遍历更新LocationName和Code
        /// </summary>
        /// <param name="locationTVTB"></param>
        private void updateLocationFullNameAndLocationCode(Hashtable locationTVTB)
        {
            foreach (DictionaryEntry dict in locationTVTB)
            {
                Location location = (Location)LocationsTB[dict.Key];
                Location locationP = (Location)LocationsTB[location.LocationPID];
                location.LocationFullName = locationP == null ? location.LocationName : locationP.LocationFullName + "-" + location.LocationName;
                location.LocationCode = locationP == null ? StringUtil.GetSpellCode(location.LocationName) : locationP.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
                location.LocationLevel = locationP == null ? 0 : locationP.LocationLevel + 1;
                updateNameLocations.Add(location);
                //递归
                Hashtable hashtable = (Hashtable)dict.Value;
                updateLocationFullNameAndLocationCode(hashtable);
            }
        }

        /// <summary>
        /// 查询locationID的树ID结构
        /// </summary>
        /// <param name="locationID">需要查询的ID</param>
        /// <returns>返回按从树干到树支的ID列表，不包括根树干rootID</returns>
        private string[] getLocationIDTree(string locationID)
        {
            List<string> list = new List<string>();
            string locationId = locationID;
            //依次查询当前ID的父ID
            do
            {
                list.Add(locationId);
                locationId = (string)LocationIDTB[locationId];
                if (locationId == null)
                {
                    //这个分支断了，不添加
                    return null;
                }
            } while (!locationId.Equals(Guid.Empty.ToString()));
            string[] array = list.ToArray();
            //倒序，父级在前面
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// 循环将locationId列表中的第1个元素添加到指定的Hashtable中，如果已经存在就不添加
        /// </summary>
        /// <param name="locationtree"></param>
        private void addLocationTree(Hashtable hashtable, string[] locationtree)
        {
            Hashtable tmpHashtable = null;
            //判断第一父级是否存在，不存在就添加,存在就获取子级HashTable
            if (!hashtable.ContainsKey(locationtree[0]))
            {
                tmpHashtable = new Hashtable();
                hashtable.Add(locationtree[0], tmpHashtable);
            }
            else
            {
                tmpHashtable = (Hashtable)hashtable[locationtree[0]];
            }
            //遍历下一节点
            if (locationtree.Length > 1)
            {
                //去除当前父节点，继续遍历子节点
                string[] strarray = new string[locationtree.Length - 1];
                Array.Copy(locationtree, 1, strarray, 0, strarray.Length);
                addLocationTree(tmpHashtable, strarray);
            }
        }
    }
}
