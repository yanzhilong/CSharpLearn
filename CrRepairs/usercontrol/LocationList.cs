using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyz.ibean.data;
using CrRepairs.model;
using System.Collections;
using CrRepairs.util;

namespace CrRepairs
{
    public partial class LocationList : UserControl
    {
        private Repository repository;
        private LocationManager locationManager;
        //private Hashtable hashtableID = new Hashtable();//存放当前LocationID和父LocationID
        //private Hashtable hashtableLocations = new Hashtable();//存放当前LocationID和对应的Location实体
        //private Hashtable hashtableTreeView = new Hashtable();//存放目录树结构key是locationID，value是子的Hashtable....
        private Location selectLocation;//当前选中的地址实体
        public LocationList()
        {
            InitializeComponent();
        }

        private void LocationList_Load(object sender, EventArgs e)
        {
            repository = Repository.newInstance();
            //设置最大化
            this.Dock = DockStyle.Fill;
            treeView1.Nodes.Clear();
            treeView1.Dock = DockStyle.Left;
            treeView1.HideSelection = false;
            //获取地址列表
            List<Location> locations = repository.getLocations();
            locationManager = new LocationManager();
            locationManager.initLocations(locations);
            //添加到TreeView中
            locationManager.addTreeNode(treeView1.Nodes,locationManager.LocationsTVTB);
            //refreshTreeView(locations);//刷新列表

            


            //for (int i = 0; i < locations.Count; i++)
            //{
            //    TreeNode tn1 = treeView1.Nodes.Add(locations[i].LocationName);
            //}
            //TreeNode tn1 = treeView1.Nodes.Add("报修模块");
            //TreeNode Ntn1 = new TreeNode("位置管理");
            //TreeNode Ntn2 = new TreeNode("设备点管理");
            //TreeNode Ntn3 = new TreeNode("报修位置管理");
            //TreeNode Ntn4 = new TreeNode("故障描述管理");
            //TreeNode Ntn5 = new TreeNode("故障分类管理");
            //TreeNode Ntn6 = new TreeNode("报修申请");
            //TreeNode Ntn7 = new TreeNode("报修列表管理");

            //tn1.Nodes.Add(Ntn1);
            //tn1.Nodes.Add(Ntn2);
            //tn1.Nodes.Add(Ntn3); 
            //tn1.Nodes.Add(Ntn4);
            //tn1.Nodes.Add(Ntn5);
            //tn1.Nodes.Add(Ntn6);
            //tn1.Nodes.Add(Ntn7);

        }

        private void refreslRightButton()
        {
            //右侧按钮初始化
            addWithLocation.Enabled = false;
            addChildLocation.Enabled = false;
            locationNameTB.Enabled = false;
            selectLocationNameTB.Text = "";//当前地址
            updateLocation.Enabled = false;//更新按钮
            editLocationName.Enabled = false;//
            deleteLocation.Enabled = false;
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectLocation = (Location)e.Node.Tag;
            addWithLocation.Enabled = true;
            addChildLocation.Enabled = true;
            locationNameTB.Enabled = true;
            selectLocationNameTB.Text = e.Node.Text;//当前地址
            updateLocation.Enabled = false;//更新按钮
            editLocationName.Enabled = true;//
            deleteLocation.Enabled = true;
            
        }

        /// <summary>
        /// 刷新位置树
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        //private void refreshTreeView(List<Location> locations)
        //{
        //    parseLocations(locations);
        //    hashtableTreeView.Clear();
        //    //遍历位置数据
        //    foreach (DictionaryEntry dict in hashtableLocations)
        //    {
        //        string locationID = (string)dict.Key;
        //        Location location = (Location)dict.Value;
        //        //查找当前locationID的目录树ID列表
        //        string[] locationtree = parseLocationID(hashtableID,locationID);
        //        pasrseLocationTree(hashtableTreeView,locationtree);
        //    }
        //    //循环添加位置
        //    addTreeNode(treeView1.Nodes, hashtableTreeView);
        //}

        //private void addTreeNode(TreeNodeCollection treeNodeCollection,Hashtable hashtable)
        //{
        //    //遍历
        //    foreach (DictionaryEntry dict in hashtable)
        //    {
        //        Location location = (Location)hashtableLocations[dict.Key];
        //        TreeNode treenode = treeNodeCollection.Add(location.LocationName);
        //        treenode.Tag = location;//将Location添加到TAG中
        //        Hashtable tmpHashtable = (Hashtable)dict.Value;
        //        //递归添加
        //        addTreeNode(treenode.Nodes, tmpHashtable);
        //    }
            
        //}

        /// <summary>
        /// 循环将locationId列表中的第1个元素添加到指定的Hashtable中，如果已经存在就不添加
        /// </summary>
        /// <param name="hashtable"></param>
        /// <param name="locationtree"></param>
        //private void pasrseLocationTree(Hashtable hashtable,string[] locationtree)
        //{
        //    Hashtable tmpHashtable = null;
        //    if (!hashtable.ContainsKey(locationtree[0]))
        //    {
        //        tmpHashtable = new Hashtable();
        //        hashtable.Add(locationtree[0], tmpHashtable);
        //    }else
        //    {
        //        tmpHashtable = (Hashtable)hashtable[locationtree[0]];
        //    }
        //    //遍历下一节点
        //    if(locationtree.Length > 1)
        //    {
        //        string[] strarray = new string[locationtree.Length - 1];
        //        Array.Copy(locationtree, 1, strarray, 0, strarray.Length);
        //        pasrseLocationTree(tmpHashtable, strarray);
        //    }
        //}



        /// <summary>
        /// 解析位置列表
        /// </summary>
        /// <param name="locations"></param>
        //private void parseLocations(List<Location> locations)
        //{
        //    hashtableID.Clear();
        //    hashtableLocations.Clear();
        //    foreach (Location location in locations)
        //    {
        //        hashtableID.Add(location.LocationID,location.LocationPID);
        //        hashtableLocations.Add(location.LocationID,location);
        //    }
        //}

        /// <summary>
        /// 查询locationID的树ID结构
        /// </summary>
        /// <param name="hashtable">存放有当前地址ID和父ID的hash表</param>
        /// <param name="locationID">需要查询的ID</param>
        /// <returns>返回按从树干到树支的ID列表，不包括根树干rootID</returns>
        //private string[] parseLocationID(Hashtable hashtable,string locationID)
        //{
        //    List<string> list = new List<string>();
        //    string locationId = locationID;
        //    do
        //    {
        //        list.Add(locationId);
        //        locationId = (string)hashtable[locationId];
        //    } while (!locationId.Equals(Guid.Empty.ToString()));
        //    string[] array = list.ToArray();
        //    Array.Reverse(array);
        //    return array;
        //}

        private void addLocation_Click(object sender, EventArgs e)
        {
            Location locationP = (Location)locationManager.LocationsTB[selectLocation.LocationPID];

            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
            //if(selectLocation.LocationLevel == 0)
            //{

            //}
            location.LocationPID = selectLocation.LocationPID;
            location.LocationName = locationNameTB.Text;
            location.LocationFullName = selectLocation.LocationFullName + "-" + location.LocationName;
            if(locationP != null)
            {
                location.LocationCode = locationP.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
            }else
            {
                location.LocationCode = StringUtil.GetSpellCode("项目名称-" + location.LocationName);
            }
            location.LocationLevel = selectLocation.LocationLevel;
            repository.addLocation(location);
            loadData();
        }

        private void addChildLocation_Click(object sender, EventArgs e)
        {

            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
            location.LocationPID = selectLocation.LocationID;
            location.LocationName = locationNameTB.Text;
            location.LocationFullName = selectLocation.LocationFullName + "-" + location.LocationName;
            location.LocationCode = selectLocation.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);

            location.LocationLevel = selectLocation.LocationLevel + 1;
            Location addLocation = repository.addLocation(location);
            loadData();
        }

        private void editLocationName_Click(object sender, EventArgs e)
        {
            selectLocationNameTB.Enabled = true;
            updateLocation.Enabled = true;
            editLocationName.Enabled = false;
        }

        private void updateLocation_Click(object sender, EventArgs e)
        {
            selectLocationNameTB.Enabled = false;
            editLocationName.Enabled = true;
            updateLocation.Enabled = false;
            Location updatelocation = selectLocation;
            updatelocation.LocationName = selectLocationNameTB.Text;
            
            //查找当前地址下面的所有Location
            Repository repository = Repository.newInstance();
            List<Location> locations = repository.getLocationsById(updatelocation.LocationID);
            locations.Add(updatelocation);
            LocationManager locationManager = new LocationManager();
            locationManager.initLocations(locations);
            List<Location> updateLocations = locationManager.updateLocationName(updatelocation.LocationID, updatelocation.LocationName);

            //locations.Add(updatelocation);
            //Hashtable locationsTB = new Hashtable();

            //foreach (Location location in locations)
            //{
            //    locationsTB.Add(location.LocationID,location);

            //    String tmpFuulName = location.LocationFullName;
            //    int i = 0;
            //    int indexLeft = 0;
            //    while((indexLeft = tmpFuulName.IndexOf("-")) != -1)
            //    {
            //        if(i == updatelocation.LocationLevel)
            //        {
            //            break;
            //        }
            //        i++;
            //    }




            //    if (location.LocationLevel == 0)
            //    {
            //        location.LocationFullName = location.LocationName;
            //    }else
            //    {
            //        //string tmpFuulName = location.LocationFullName;
            //        //String Str = tmpFuulName;
            //        //int i = Str.LastIndexOf("-");
            //        //tmpFuulName = tmpFuulName.Remove(i);
            //        //location.LocationFullName = tmpFuulName + "-" + location.LocationName;

            //    }
            //    location.LocationCode = StringUtil.GetSpellCode(location.LocationFullName);
            //}

            //foreach (Location location in locations)
            //{
            //    if(location.LocationID != updatelocation.LocationID)
            //    {
            //        location.LocationFullName = selectLocation.LocationFullName + "-" + location.LocationName;
            //        location.LocationCode = selectLocation.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);

            //        location.LocationLevel = selectLocation.LocationLevel + 1;
            //    }
            //}

            bool result = repository.updateLocations(updateLocations);
            loadData();

        }

        private void loadData()
        {
            TreeViewUtil.GetTreeNodesStatus(treeView1.Nodes);
            LocationList_Load(null, null);
            TreeNode selectTreeNode = TreeViewUtil.SetTreeNodesStatus(treeView1.Nodes);
            refreslRightButton();
        }

        private void deleteLocation_Click(object sender, EventArgs e)
        {
            Repository repository = Repository.newInstance();
            //查看是否有子地址
            List<Location> locations = repository.getLocationsById(selectLocation.LocationID);
            if(locations.Count  > 0)
            {
                MessageBox.Show("包含地址数据，无法删除");
                return;
            }
            repository.deleteLocation(selectLocation.LocationID);
            loadData();
        }

        private void addLocation_Click_1(object sender, EventArgs e)
        {
            if(locationNameTB.Text == "")
            {
                MessageBox.Show("请输入地址信息");
                return;
            }
            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
            location.LocationPID = Guid.Empty.ToString();
            location.LocationName = locationNameTB.Text;
            location.LocationFullName = location.LocationName;
            location.LocationCode = StringUtil.GetSpellCode(location.LocationName);
            location.LocationLevel = 0;
            repository.addLocation(location);
            loadData();
        }

        private void querystring_TextChanged(object sender, EventArgs e)
        {
            string querystr = querystring.Text;
            queryresult.Items.Clear();
            Repository repository = Repository.newInstance();
            List<Location> locations = repository.getLocationsByQuery(querystr);
            foreach (Location location in locations)
            {
                queryresult.Items.Add(location.LocationFullName);
            }
        }

        private void queryresult_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }


    public class LocationManager
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
                //添加到位置树中
                addLocationTree(LocationsTVTB, locationtree);
            }
        }


        /// <summary>
        /// 将指定地址树添加到TreeNodeCollection中
        /// </summary>
        /// <param name="treeNodeCollection"></param>
        /// <param name="locationTB"></param>
        public void addTreeNode(TreeNodeCollection treeNodeCollection, Hashtable locationTB)
        {
            //遍历
            foreach (DictionaryEntry dict in locationTB)
            {
                Location location = (Location)LocationsTB[dict.Key];
                TreeNode treenode = treeNodeCollection.Add(location.LocationName);
                treenode.Tag = location;//将Location添加到TAG中
                Hashtable tmpHashtable = (Hashtable)dict.Value;
                //递归将子地址树添加到TreeNodeCollection的子集合中
                addTreeNode(treenode.Nodes, tmpHashtable);
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
            //遍历更新
            Hashtable hashtable = findLocationTB(LocationsTVTB, locationID);
            Location location = null;
            foreach (DictionaryEntry dict in hashtable)
            {
                location = (Location)locationsTB[(string)dict.Key];
            }
            if(location != null)
            {
                updateLocationFullNameAndLocationCode(hashtable);
                //Location locationP = (Location)locationsTB[location.LocationPID];
                //location.LocationName = locationName;
                //location.LocationFullName = locationP == null ? "" :locationP.LocationFullName + "-" + location.LocationName;
                //location.LocationCode = locationP == null ? "" : locationP.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
                //location.LocationLevel = locationP == null ? 0 : locationP.LocationLevel + 1;
                //updateNameLocations.Add(location);
            }else
            {
                return null;
            }
            
            //foreach (DictionaryEntry dict in LocationsTVTB)
            //{
                
            //    Location location = (Location)LocationsTB[dict.Key];
            //    Location locationP = (Location)LocationsTB[location.LocationPID];
            //    location.LocationFullName = locationP.LocationFullName + "-" + location.LocationName;
            //    location.LocationCode = locationP.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
            //    location.LocationLevel = locationP.LocationLevel + 1;
            //    updateNameLocations.Add(location);
            //    //递归
            //    Hashtable hashtable = (Hashtable)dict.Value;
            //    updateLocationFullNameAndLocationCode(hashtable);
            //}
            return updateNameLocations;
        }

        private Hashtable findLocationTB(Hashtable locationsTB,string LocationID)
        {
            Hashtable hashtable = null;
            //遍历更新
            foreach (DictionaryEntry dict in locationsTB)
            {
                string locationID = (string)dict.Key;
                if(locationID == LocationID)
                {
                    hashtable = new Hashtable();
                    hashtable.Add(dict.Key,dict.Value);
                    break;
                }else
                {
                    return findLocationTB((Hashtable)dict.Value, LocationID);
                }
            }
            return hashtable;
        }


        /// <summary>
        /// 遍历更新LocationName和Code
        /// </summary>
        /// <param name="locationTVTB"></param>
        private void updateLocationFullNameAndLocationCode(Hashtable locationTVTB)
        {
            foreach(DictionaryEntry dict in locationTVTB)
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
        private string[] getLocationIDTree( string locationID)
        {
            List<string> list = new List<string>();
            string locationId = locationID;
            //依次查询当前ID的父ID
            do
            {
                list.Add(locationId);
                locationId = (string)LocationIDTB[locationId];
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
        private void addLocationTree(Hashtable hashtable,string[] locationtree)
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
