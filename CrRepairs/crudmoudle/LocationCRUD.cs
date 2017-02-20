using CrRepairs.crudmoudle;
using CrRepairs.usercontrol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyz.ibean.model;
using System.Data;
using xyz.ibean.data;
using CrRepairs.model;
using MySql.Data.MySqlClient;
using CrRepairs.util;
using System.Windows.Forms;

namespace CrRepairs.crudmoudle
{
    class LocationCRUD : CrudTreeViewBase
    {
        private Repository repository;
        private LocationManager locationManager;
        private Hashtable treeviewLocation;

        TreeViewManager treeviewManager;
        List<Company> companys;//
        List<string> companyarray;//公司列表 

        private MySqlModule mySqlModule;
        public LocationCRUD()
        {

            repository = Repository.newInstance();
            mySqlModule = new MySqlModule();
            treeviewLocation = new Hashtable();


            refreshData();

            //locationManager = new LocationManager();
            //locationManager.initLocations(locations);
            ////添加到TreeView中
            //locationManager.addTreeNode(treeView1.Nodes, locationManager.LocationsTVTB);



            //mySqlModule = new MySqlModule();
            ////初始化标题
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("CompanyID", "公司编号");
            //hashtable.Add("CompanyName", "公司名称");
            //this.Titles = hashtable;

            ////初始化sql
            //this.Sql = "SELECT * FROM location.company";





        }

        //public void add(Hashtable hashtable)
        //{

        //    //Location locationP = (Location)locationManager.LocationsTB[selectLocation.LocationPID];

        //    Repository repository = Repository.newInstance();
        //    Location location = new Location();
        //    location.LocationID = Guid.NewGuid().ToString();
        //    location.LocationName = (string)hashtable["location_Name"];
        //    if (selectTreeViewNode == null)
        //    {
        //        //添加根节点
        //        location.LocationPID = Guid.Empty.ToString();
        //        location.LocationFullName = location.LocationName;
        //        location.LocationCode = StringUtil.GetSpellCode(location.LocationName);
        //    }
        //    else
        //    {
        //        //得到当前的Location
        //        Location locationcurrent = (Location)treeviewLocation[selectTreeViewNode.Id];
        //        //得到父的Location
        //        Location locationpreant = (Location)treeviewLocation[selectTreeViewNode.Pid];
        //        //判断是子节点还是同级
        //        if ((string)hashtable["addType"] == "同级")
        //        {
        //            location.LocationPID = selectTreeViewNode.Pid;
        //            //添加名称和code
        //            if(locationpreant == null)
        //            {
        //                location.LocationFullName = location.LocationName;
        //            }
        //            else
        //            {
        //                location.LocationFullName = locationpreant.LocationFullName + "-" + location.LocationName;
        //            }
        //            location.LocationCode = StringUtil.GetSpellCode(location.LocationFullName);
        //            location.LocationLevel = locationcurrent.LocationLevel;
        //        }
        //        else
        //        {
        //            location.LocationPID = selectTreeViewNode.Id;
        //            //添加名称和code
        //            location.LocationFullName = locationcurrent.LocationFullName + "-" + location.LocationName;
        //            location.LocationCode = StringUtil.GetSpellCode(location.LocationFullName);
        //            location.LocationLevel = locationcurrent.LocationLevel + 1;
        //        }
        //    }
        //    //查找公司ID 
        //    foreach(Company com in companys)
        //    {
        //        if(com.CompanyName == (string)hashtable["company_ID"])
        //        {
        //            location.CompanyID = com.CompanyID;
        //            break;
        //        }
        //    }

        //    repository.addLocation(location);
        //}

        //public void delete(Hashtable hashtable)
        //{

        //    string sqlbase = "DELETE FROM company WHERE CompanyID = '{0}'";
        //    string sql = String.Format(sqlbase,hashtable["CompanyID"]);
        //    mySqlModule.query(sql);
        //}

        //public void update(Hashtable hashtable)
        //{


        //    Location updatelocation = (Location)treeviewLocation[selectTreeViewNode.Id];
        //    updatelocation.LocationName = (string)hashtable["LocationName"];

        //    //查找当前地址下面的所有Location
        //    Repository repository = Repository.newInstance();
        //    List<Location> locations = repository.getLocations();
        //    //locations.Add(updatelocation);
        //    LocationManager locationManager = new LocationManager();
        //    locationManager.initLocations(locations);
        //    List<Location> updateLocations = locationManager.updateLocationName(updatelocation.LocationID, updatelocation.LocationName);

        //    bool result = repository.updateLocations(updateLocations);
        //}

        public Hashtable loadTreeViewData()
        {
            throw new NotImplementedException();
        }

        public DataTable loadGridViewData()
        {
            throw new NotImplementedException();
        }

        //public void TreeViewSelect(TreeViewNode treeviewNode)
        //{

        //    selectTreeViewNode = treeviewNode;
        //    CrudItem crudItem = this.Updates[0];
        //    crudItem.Value = selectTreeViewNode.Name;
        //}


        public override void Add(List<CrudItem> crudItems, TreeViewNode treeViewNode)
        {
            Repository repository = Repository.newInstance();

            //得到当前选中的地址
            Location selectLocation = treeViewNode != null ? (Location)treeviewLocation[treeViewNode.Id] : null;
            Location locationpreant = treeViewNode != null ? (Location)treeviewLocation[treeViewNode.Pid] : null;
            
            bool isSameNode = false;//是否是添加同级
            foreach(CrudItem crudItem in crudItems)
            {
                if(crudItem.Valuekey == "addType")
                {
                    if(crudItem.Value == "同级")
                    {
                        isSameNode = true;
                    }
                    break;
                }
            }

            //提取输入信息
            Location inputLocation = new Location();
            foreach (CrudItem crudItem in crudItems)
            {
                switch (crudItem.Valuekey)
                {
                    case "location_Name":
                        inputLocation.LocationName = crudItem.Value;
                        break;

                    case "company_ID":
                        foreach (Company com in companys)
                        {
                            if (com.CompanyName == (string)crudItem.Value)
                            {
                                inputLocation.CompanyID = com.CompanyID;
                                break;
                            }
                        }
                        break;
                    default:
                        break;

                }
            }

            //设置添加信息
            Location addLocation = new Location();
            addLocation.LocationID = Guid.NewGuid().ToString();
            addLocation.CompanyID = inputLocation.CompanyID;
            addLocation.LocationName = inputLocation.LocationName;

            //判断是否是根节点
            if (selectLocation == null)
            {
                //添加根节点
                addLocation.LocationPID = Guid.Empty.ToString();
                addLocation.LocationFullName = addLocation.LocationName;
                addLocation.LocationCode = StringUtil.GetSpellCode(addLocation.LocationName);
            }
            else
            {
                //判断是子节点还是同级
                if (isSameNode)
                {
                    addLocation.LocationPID = selectLocation.LocationPID;
                    //添加名称和code
                    if (locationpreant == null)
                    {
                        addLocation.LocationFullName = addLocation.LocationName;
                    }
                    else
                    {
                        addLocation.LocationFullName = locationpreant.LocationFullName + "-" + addLocation.LocationName;
                    }
                    addLocation.LocationCode = StringUtil.GetSpellCode(addLocation.LocationFullName);
                    addLocation.LocationLevel = selectLocation.LocationLevel;
                }
                else
                {
                    addLocation.LocationPID = selectLocation.LocationID;
                    //添加名称和code
                    addLocation.LocationFullName = selectLocation.LocationFullName + "-" + addLocation.LocationName;
                    addLocation.LocationCode = StringUtil.GetSpellCode(addLocation.LocationFullName);
                    addLocation.LocationLevel = selectLocation.LocationLevel + 1;
                }
            }
            repository.addLocation(addLocation);
        }

        public override void Update(List<CrudItem> crudItems, TreeViewNode treeViewNode)
        {
            Location updatelocation = (Location)treeviewLocation[treeViewNode.Id];

            //提取输入信息
            Location inputLocation = new Location();
            foreach (CrudItem crudItem in crudItems)
            {
                switch (crudItem.Valuekey)
                {
                    case "location_Name":
                        updatelocation.LocationName = crudItem.Value;
                        break;
                    default:
                        break;
                }
            }

            //查找当前地址下面的所有Location
            Repository repository = Repository.newInstance();
            List<Location> locations = repository.getLocations();
            //locations.Add(updatelocation);
            LocationManager locationManager = new LocationManager();
            locationManager.initLocations(locations);
            List<Location> updateLocations = locationManager.updateLocationName(updatelocation.LocationID, updatelocation.LocationName);

            bool result = repository.updateLocations(updateLocations);
        }

        public override void Delete(TreeViewNode treeViewNode)
        {
            Repository repository = Repository.newInstance();
            //查看是否有子地址
            List<Location> locations = repository.getLocationsById(treeViewNode.Id);
            if (locations.Count > 0)
            {
                MessageBox.Show("包含地址数据，无法删除");
                return;
            }
            repository.deleteLocation(treeViewNode.Id);
            refreshData();
        }

        public override List<CrudItem> getAdds()
        {
            //初始化添加数据项
            List<CrudItem> adds = new List<CrudItem>();

            //地址提示
            CrudItem add_location_Lable = new CrudItem();
            add_location_Lable.IsbeNull = false;
            add_location_Lable.Enable = true;
            add_location_Lable.Lable = "如未选中节点，默认添加到根节点";
            add_location_Lable.Value = "";
            add_location_Lable.Combovalue = new string[] { "同级", "子级" };
            add_location_Lable.ValueType = CrudItem.TIP;
            adds.Add(add_location_Lable);

            //地址级别
            CrudItem add_location_Type = new CrudItem();
            add_location_Type.IsbeNull = false;
            add_location_Type.Enable = true;
            add_location_Type.Lable = "添加类别:";
            add_location_Type.Value = "";
            add_location_Type.Combovalue = new string[] { "同级", "子级" };
            add_location_Type.ValueType = CrudItem.RADIOBUTTON;
            add_location_Type.Valuekey = "addType";
            adds.Add(add_location_Type);

            //地址名称
            CrudItem add_location_Name = new CrudItem();
            add_location_Name.IsbeNull = false;
            add_location_Name.Enable = true;
            add_location_Name.Lable = "地址名称:";
            add_location_Name.Value = "";
            add_location_Name.ValueType = CrudItem.TEXTBOX;
            add_location_Name.Valuekey = "location_Name";
            adds.Add(add_location_Name);


            //查找公司
            MySqlConnection mc = mySqlModule.openConnection();
            MySqlDataReader mysqldr = mySqlModule.queryData("SELECT * FROM location.company", mc);


            companys = new List<Company>();
            while (mysqldr.Read())
            {
                Company company = new Company();
                company.CompanyID = mysqldr.GetString(0);
                company.CompanyName = mysqldr.GetString(1);
                companys.Add(company);
            }
            mysqldr.Close();
            mySqlModule.closeConnection(mc);

            //得到数缓组
            companyarray = new List<string>();
            foreach (Company c in companys)
            {
                companyarray.Add(c.CompanyName);
            }
            string[] companyArray = companyarray.ToArray();

            //公司选择
            CrudItem add_location_companyID = new CrudItem();
            add_location_companyID.IsbeNull = false;
            add_location_companyID.Enable = true;
            add_location_companyID.Lable = "公司:";
            add_location_companyID.Combovalue = companyArray;
            add_location_companyID.ValueType = CrudItem.COMBOBOX;
            add_location_companyID.Valuekey = "company_ID";
            adds.Add(add_location_companyID);

            return adds;
        }

        public override List<CrudItem> getUpdates()
        {
            //初始化更新数据项
            List<CrudItem> updates = new List<CrudItem>();

            //更新公司编号
            CrudItem update_location_Name = new CrudItem();
            update_location_Name.IsbeNull = false;
            update_location_Name.Enable = true;
            update_location_Name.Lable = "地址名称:";
            update_location_Name.Value = "";
            update_location_Name.ValueType = CrudItem.TEXTBOX;
            update_location_Name.Valuekey = "location_Name";
            updates.Add(update_location_Name);

            return updates;
        }

        public override Hashtable getTreeViewData()
        {
            
            return treeviewManager.TreeViewID;
        }

        public override Hashtable getTreeViewNode()
        {

            return treeviewManager.TreeViewIDAndTreeViewNode;
        }

        public override void refreshData()
        {

            

            treeviewLocation.Clear();
            //获取地址列表
            List<Location> locations = repository.getLocations();

            //初始化id,Pid和TreeViewNode
            treeviewManager = new TreeViewManager();
            List<TreeViewNode> treeviewNodes = new List<TreeViewNode>();
            foreach (Location location in locations)
            {
                TreeViewNode treeviewNode = new TreeViewNode();
                treeviewNode.Id = location.LocationID;
                treeviewNode.Name = location.LocationName;
                treeviewNode.Pid = location.LocationPID;
                treeviewLocation.Add(location.LocationID, location);
                treeviewNodes.Add(treeviewNode);
            }
            treeviewManager.initTreeView(treeviewNodes);
        }
    }
}
