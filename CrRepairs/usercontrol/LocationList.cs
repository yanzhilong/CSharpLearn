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

        private Hashtable hashtableID = new Hashtable();//存放当前LocationID和父LocationID
        private Hashtable hashtableLocations = new Hashtable();//存放当前LocationID和对应的Location实体
        private Hashtable hashtableTreeView = new Hashtable();//存放目录树结构key是locationID，value是子的Hashtable....
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
            treeView1.Dock = DockStyle.Left;
            //获取地址列表
            List<Location> locations = repository.getLocations();

            refreshTreeView(locations);//刷新列表

            

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectLocation = (Location)e.Node.Tag;
            addLocation.Enabled = true;
            addChildLocation.Enabled = true;
            locationNameTB.Enabled = true;
            selectLocationNameTB.Text = e.Node.Text;//当前地址
            updateLocation.Enabled = false;//更新按钮
            editLocationName.Enabled = true;//
            
        }

        /// <summary>
        /// 刷新位置树
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        private void refreshTreeView(List<Location> locations)
        {
            parseLocations(locations);
            //遍历位置数据
            foreach (DictionaryEntry dict in hashtableLocations)
            {
                string locationID = (string)dict.Key;
                Location location = (Location)dict.Value;
                //查找当前locationID的目录树ID列表
                string[] locationtree = parseLocationID(hashtableID,locationID);
                pasrseLocationTree(hashtableTreeView,locationtree);
            }
            //循环添加位置
            addTreeNode(treeView1.Nodes, hashtableTreeView);


        }

        private void addTreeNode(TreeNodeCollection treeNodeCollection,Hashtable hashtable)
        {
            //遍历
            foreach (DictionaryEntry dict in hashtable)
            {
                Location location = (Location)hashtableLocations[dict.Key];
                TreeNode treenode = treeNodeCollection.Add(location.LocationName);
                treenode.Tag = location;//将Location添加到TAG中
                Hashtable tmpHashtable = (Hashtable)dict.Value;
                //递归添加
                addTreeNode(treenode.Nodes, tmpHashtable);
            }
            
        }

        /// <summary>
        /// 循环将locationId列表中的第1个元素添加到指定的Hashtable中，如果已经存在就不添加
        /// </summary>
        /// <param name="hashtable"></param>
        /// <param name="locationtree"></param>
        private void pasrseLocationTree(Hashtable hashtable,string[] locationtree)
        {
            Hashtable tmpHashtable = null;
            if (!hashtable.ContainsKey(locationtree[0]))
            {
                tmpHashtable = new Hashtable();
                hashtable.Add(locationtree[0], tmpHashtable);
            }else
            {
                tmpHashtable = (Hashtable)hashtable[locationtree[0]];
            }
            //遍历下一节点
            if(locationtree.Length > 1)
            {
                string[] strarray = new string[locationtree.Length - 1];
                Array.Copy(locationtree, 1, strarray, 0, strarray.Length);
                pasrseLocationTree(tmpHashtable, strarray);
            }
        }



        /// <summary>
        /// 解析位置列表
        /// </summary>
        /// <param name="locations"></param>
        private void parseLocations(List<Location> locations)
        {
            hashtableID.Clear();
            hashtableLocations.Clear();
            foreach (Location location in locations)
            {
                hashtableID.Add(location.LocationID,location.LocationPID);
                hashtableLocations.Add(location.LocationID,location);
                //将根位置编码存入root这个key中,因为根只有一个，所以只存一次
                if (!hashtableID.ContainsKey("root"))
                {
                    if(location.LocationLevel == 0)
                    {
                        hashtableID.Add("root",location.LocationPID);
                    }
                }
            }
        }

        /// <summary>
        /// 查询locationID的树ID结构
        /// </summary>
        /// <param name="hashtable">存放有当前地址ID和父ID的hash表</param>
        /// <param name="locationID">需要查询的ID</param>
        /// <returns>返回按从树干到树支的ID列表，不包括根树干rootID</returns>
        private string[] parseLocationID(Hashtable hashtable,string locationID)
        {
            List<string> list = new List<string>();
            string locationId = locationID;
            do
            {
                list.Add(locationId);
                locationId = (string)hashtable[locationId];
            } while (locationId != (string)hashtable["root"]);
            string[] array = list.ToArray();
            Array.Reverse(array);
            return array;
        }

        private void addLocation_Click(object sender, EventArgs e)
        {
            Location locationP = (Location)hashtableLocations[selectLocation.LocationPID];

            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
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
            location.LocationPath = location.LocationCode;
            repository.addLocation(location);
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
            location.LocationPath = location.LocationCode;
            Location addLocation = repository.addLocation(location);

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
        }
    }
}
