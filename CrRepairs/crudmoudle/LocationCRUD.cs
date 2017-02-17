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
            //获取地址列表
            List<Location> locations = repository.getLocations();

            //初始化id,Pid和TreeViewNode
            treeviewManager = new TreeViewManager();
            List<TreeViewNode> treeviewNodes = new List<TreeViewNode>();
            foreach(Location location in locations)
            {
                TreeViewNode treeviewNode = new TreeViewNode();
                treeviewNode.Id = location.LocationID;
                treeviewNode.Name = location.LocationName;
                treeviewNode.Pid = location.LocationPID;
                treeviewLocation.Add(location.LocationID,location);
                treeviewNodes.Add(treeviewNode);
            }
            treeviewManager.initTreeView(treeviewNodes);

            

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
        
        public void add(Hashtable hashtable)
        {
            
            //Location locationP = (Location)locationManager.LocationsTB[selectLocation.LocationPID];

            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
            location.LocationName = (string)hashtable["location_Name"];
            if (selectTreeViewNode == null)
            {
                //添加根节点
                location.LocationPID = Guid.Empty.ToString();
                location.LocationFullName = location.LocationName;
                location.LocationCode = StringUtil.GetSpellCode(location.LocationName);
            }
            else
            {
                //得到当前的Location
                Location locationcurrent = (Location)treeviewLocation[selectTreeViewNode.Id];
                //得到父的Location
                Location locationpreant = (Location)treeviewLocation[selectTreeViewNode.Pid];
                //判断是子节点还是同级
                if ((string)hashtable["addType"] == "同级")
                {
                    location.LocationPID = selectTreeViewNode.Pid;
                    //添加名称和code
                    if(locationpreant == null)
                    {
                        location.LocationFullName = location.LocationName;
                    }
                    else
                    {
                        location.LocationFullName = locationpreant.LocationFullName + "-" + location.LocationName;
                    }
                    location.LocationCode = StringUtil.GetSpellCode(location.LocationFullName);
                    location.LocationLevel = locationcurrent.LocationLevel;
                }
                else
                {
                    location.LocationPID = selectTreeViewNode.Id;
                    //添加名称和code
                    location.LocationFullName = locationcurrent.LocationFullName + "-" + location.LocationName;
                    location.LocationCode = StringUtil.GetSpellCode(location.LocationFullName);
                    location.LocationLevel = locationcurrent.LocationLevel + 1;
                }
            }
            //查找公司ID 
            foreach(Company com in companys)
            {
                if(com.CompanyName == (string)hashtable["company_ID"])
                {
                    location.CompanyID = com.CompanyID;
                    break;
                }
            }
            
            
            
            //if (locationP != null)
            //{
            //    location.LocationCode = locationP.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
            //}
            //else
            //{
            //    location.LocationCode = StringUtil.GetSpellCode("项目名称-" + location.LocationName);
            //}
            //location.LocationLevel = selectLocation.LocationLevel;
            repository.addLocation(location);
            //loadData();
        }

        public void delete(Hashtable hashtable)
        {
            
            string sqlbase = "DELETE FROM company WHERE CompanyID = '{0}'";
            string sql = String.Format(sqlbase,hashtable["CompanyID"]);
            mySqlModule.query(sql);
        }
        
        public void update(Hashtable hashtable)
        {


            Location updatelocation = (Location)treeviewLocation[selectTreeViewNode.Id];
            updatelocation.LocationName = (string)hashtable["LocationName"];

            //查找当前地址下面的所有Location
            Repository repository = Repository.newInstance();
            List<Location> locations = repository.getLocations();
            //locations.Add(updatelocation);
            LocationManager locationManager = new LocationManager();
            locationManager.initLocations(locations);
            List<Location> updateLocations = locationManager.updateLocationName(updatelocation.LocationID, updatelocation.LocationName);
            
            bool result = repository.updateLocations(updateLocations);
        }

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
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
            location.LocationName = (string)hashtable["location_Name"];
            if (selectTreeViewNode == null)
            {
                //添加根节点
                location.LocationPID = Guid.Empty.ToString();
                location.LocationFullName = location.LocationName;
                location.LocationCode = StringUtil.GetSpellCode(location.LocationName);
            }
            else
            {
                //得到当前的Location
                Location locationcurrent = (Location)treeviewLocation[selectTreeViewNode.Id];
                //得到父的Location
                Location locationpreant = (Location)treeviewLocation[selectTreeViewNode.Pid];
                //判断是子节点还是同级
                if ((string)hashtable["addType"] == "同级")
                {
                    location.LocationPID = selectTreeViewNode.Pid;
                    //添加名称和code
                    if (locationpreant == null)
                    {
                        location.LocationFullName = location.LocationName;
                    }
                    else
                    {
                        location.LocationFullName = locationpreant.LocationFullName + "-" + location.LocationName;
                    }
                    location.LocationCode = StringUtil.GetSpellCode(location.LocationFullName);
                    location.LocationLevel = locationcurrent.LocationLevel;
                }
                else
                {
                    location.LocationPID = selectTreeViewNode.Id;
                    //添加名称和code
                    location.LocationFullName = locationcurrent.LocationFullName + "-" + location.LocationName;
                    location.LocationCode = StringUtil.GetSpellCode(location.LocationFullName);
                    location.LocationLevel = locationcurrent.LocationLevel + 1;
                }
            }
            //查找公司ID 
            foreach (Company com in companys)
            {
                if (com.CompanyName == (string)hashtable["company_ID"])
                {
                    location.CompanyID = com.CompanyID;
                    break;
                }
            }



            //if (locationP != null)
            //{
            //    location.LocationCode = locationP.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
            //}
            //else
            //{
            //    location.LocationCode = StringUtil.GetSpellCode("项目名称-" + location.LocationName);
            //}
            //location.LocationLevel = selectLocation.LocationLevel;
            repository.addLocation(location);
            //loadData();
        }

        public override void Update(List<CrudItem> crudItems, TreeViewNode treeViewNode)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TreeViewNode treeViewNode)
        {
            throw new NotImplementedException();
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
            add_location_Lable.Valuekey = "addType";
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
            update_location_Name.Valuekey = "LocationName";
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
    }
}
