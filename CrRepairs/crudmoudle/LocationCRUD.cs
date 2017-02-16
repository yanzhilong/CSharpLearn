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
    class LocationCRUD : CRUDBase , CRUDEvent,TreeViewEvent
    {

        private Repository repository;
        private LocationManager locationManager;
        private TreeViewNode selectTreeViewNode;
        private Hashtable treeviewLocation;

        private MySqlModule mySqlModule;
        //private string sql;//查询用的sql数据
        //private Hashtable titles;//数据的列名和显示
        //private List<CrudItem> updates;//要更新数据的时候允许更改的字段列表
        //private List<CrudItem> adds;//要添加数据的时候允许增加的数据列表
        //private CRUDEvent crudEvent;//按钮事件
        public LocationCRUD()
        {

            repository = Repository.newInstance();
            mySqlModule = new MySqlModule();
            this.TreeViewEvent = this;
            this.DisplayType = CRUDBase.TREEVIEW;
            treeviewLocation = new Hashtable();
            //获取地址列表
            List<Location> locations = repository.getLocations();

            TreeViewManager treeviewManager = new TreeViewManager();

            List<TreeViewNode> treeviewNodes = new List<TreeViewNode>();
            foreach(Location location in locations)
            {
                TreeViewNode treeviewNode = new TreeViewNode();
                treeviewNode.Id = location.LocationID;
                treeviewNode.Name = location.LocationName;
                treeviewNode.Pid = location.LocationPID;
                treeviewLocation.Add(location.LocationID,location);
            }

            treeviewManager.initTreeView(treeviewNodes);

            this.HashtableTree = treeviewManager.TreeViewIDAndTreeViewNode;
            this.TreeViewNodeTable = treeviewManager.TreeViewIDAndTreeViewNode;

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
            add_location_Type.Combovalue = new string[] {"同级","子级"};
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

            List<Company> companys = new List<Company>();
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
            List<string> companyarray = new List<string>();
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

            this.Adds = adds;


            ////初始化更新数据项
            //List<CrudItem> updates = new List<CrudItem>();

            ////更新公司编号
            //CrudItem update_company_ID = new CrudItem();
            //update_company_ID.IsbeNull = false;
            //update_company_ID.Enable = false;
            //update_company_ID.Lable = "公司编号:";
            //update_company_ID.Value = "";
            //update_company_ID.ValueType = CrudItem.TEXTBOX;
            //update_company_ID.Valuekey = "CompanyID";
            //updates.Add(update_company_ID);

            ////更新公司名称
            //CrudItem update_company_Name = new CrudItem();
            //update_company_Name.IsbeNull = false;
            //update_company_Name.Enable = true;
            //update_company_Name.Lable = "公司名称:";
            //update_company_Name.Value = "";
            //update_company_Name.ValueType = CrudItem.TEXTBOX;
            //update_company_Name.Valuekey = "CompanyName";
            //updates.Add(update_company_Name);



            //this.Updates = updates;

            this.CrudEvent = this;
        }

        



        public class TreeViewManager
        {
            Hashtable treeViewID;//保存树ID
            Hashtable treeViewIDAndTreeViewNode;//保存树ID

            public Hashtable TreeViewID
            {
                get
                {
                    return treeViewID;
                }

                set
                {
                    treeViewID = value;
                }
            }

            public Hashtable TreeViewIDAndTreeViewNode
            {
                get
                {
                    return treeViewIDAndTreeViewNode;
                }

                set
                {
                    treeViewIDAndTreeViewNode = value;
                }
            }

            /// <summary>
            /// 初始化目录数据
            /// </summary>
            /// <param name="treeviewtable">原始表格数据:key(uuid),value(puuid)</param>
            /// <param name="treeviewName">原始表格数据:key(uuid),value(name)</param>
            public void initTreeView(List<TreeViewNode> treeviewnodes)
            {

                //保存Id和Pid的Hash表
                Hashtable treeviewIdtable = new Hashtable();
                //保存Id和TreeViewNode的Hash表 
                TreeViewIDAndTreeViewNode = new Hashtable();
                TreeViewID = new Hashtable();

                foreach (TreeViewNode treeviewNode in treeviewnodes)
                {
                    treeviewIdtable.Add(treeviewNode.Id, treeviewNode.Pid);
                    TreeViewIDAndTreeViewNode.Add(treeviewNode.Id, treeviewNode);
                }

                //遍历id数据，生成id树
                foreach (DictionaryEntry de in treeviewIdtable)
                {
                    string[] treeviewidarray = getTreeViewIdArray((string)de.Key, treeviewIdtable);
                    if (treeviewidarray == null)
                    {
                        //一个断的分支，不添加
                        continue;
                    }
                    //添加到位置树中
                    addTreeViewID(TreeViewID, treeviewidarray);
                }
            }


            /// <summary>
            /// 循环将id层次数组添加到id树中
            /// </summary>
            /// <param name="hashtable">id树存放目录</param>
            /// <param name="treeviewidarray">id层次数组</param>
            private void addTreeViewID(Hashtable hashtable, string[] treeviewidarray)
            {
                Hashtable tmpHashtable = null;
                //判断第一父级是否存在，不存在就添加,存在就获取子级HashTable
                if (!hashtable.ContainsKey(treeviewidarray[0]))
                {
                    tmpHashtable = new Hashtable();
                    hashtable.Add(treeviewidarray[0], tmpHashtable);
                }
                else
                {
                    tmpHashtable = (Hashtable)hashtable[treeviewidarray[0]];
                }
                //遍历下一节点
                if (treeviewidarray.Length > 1)
                {
                    //去除当前父节点，继续遍历子节点
                    string[] strarray = new string[treeviewidarray.Length - 1];
                    Array.Copy(treeviewidarray, 1, strarray, 0, strarray.Length);
                    addTreeViewID(tmpHashtable, strarray);
                }
            }

            /// <summary>
            /// 查询某一ID的目录层次数组
            /// </summary>
            /// <param name="treeviewId">需要查询的id</param>
            /// <param name="treeviewIdtable">内有当前id和父id的源数据</param>
            /// <returns></returns>
            private string[] getTreeViewIdArray(string treeviewId,Hashtable treeviewIdtable)
            {
                List<string> list = new List<string>();
                string MtreeviewID = treeviewId;
                //依次查询当前ID的父ID
                do
                {
                    list.Add(MtreeviewID);
                    MtreeviewID = (string)treeviewIdtable[MtreeviewID];
                    if (MtreeviewID == null)
                    {
                        //这个分支断了，不添加
                        return null;
                    }
                } while (!MtreeviewID.Equals(Guid.Empty.ToString()));
                string[] array = list.ToArray();
                //倒序，父级在前面
                Array.Reverse(array);
                return array;
            }


        }


        

        public void add(Hashtable hashtable)
        {
            
            Location locationP = (Location)locationManager.LocationsTB[selectLocation.LocationPID];

            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
            location.LocationName = (string)hashtable["location_Name"];
            if (selectTreeViewNode == null)
            {
                //添加根节点
                location.LocationPID = Guid.Empty.ToString();
                location.LocationFullName = location.LocationName;
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
                    location.LocationFullName = locationpreant.LocationName + "-" + location.LocationName;
                    location.LocationCode = locationpreant.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
                    location.LocationLevel = locationcurrent.LocationLevel;
                }
                else
                {
                    location.LocationPID = selectTreeViewNode.Id;
                    //添加名称和code
                    location.LocationFullName = locationcurrent.LocationName + "-" + location.LocationName;
                    location.LocationCode = locationcurrent.LocationCode + "-" + StringUtil.GetSpellCode(location.LocationName);
                    location.LocationLevel = locationcurrent.LocationLevel + 1;
                }
            }
            //
            location.CompanyID = "";
            
            
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
            //UPDATE company SET `CompanyName`= 'sdfg444' WHERE `CompanyID`= 'e90c790c-4a12-4f3e-927e-625b5d65e509';
            //UPDATE `location`.`company` SET `CompanyName`= 'sdfg444' WHERE `CompanyID`= 'e90c790c-4a12-4f3e-927e-625b5d65e509';
            string sqlbase = "UPDATE company SET {0} WHERE CompanyID = '{1}'";
            StringBuilder updates = new StringBuilder();
            foreach (DictionaryEntry de in hashtable)
            {
                if((string)de.Key == "CompanyID")
                {
                    continue;
                }

                updates.Append((string)de.Key);
                updates.Append("=");

                updates.Append("'");
                updates.Append((string)de.Value);
                updates.Append("'");
                updates.Append(",");
            }
            string updatestr = updates.ToString().Remove(updates.ToString().Length - 1);
            string sql = String.Format(sqlbase, updatestr, hashtable["CompanyID"]);
            mySqlModule.query(sql);
        }

        public Hashtable loadTreeViewData()
        {
            throw new NotImplementedException();
        }

        public DataTable loadGridViewData()
        {
            throw new NotImplementedException();
        }

        public void TreeViewSelect(TreeViewNode treeviewNode)
        {

            selectTreeViewNode = treeviewNode;
        }
    }


    /// <summary>
    /// 自定义的节点类
    /// </summary>
    public class TreeViewNode
    {
        private string id;//当前节点的编号
        private string name;//显示树中的名字
        private string pid;//当前父节点的编号

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Pid
        {
            get
            {
                return pid;
            }

            set
            {
                pid = value;
            }
        }
    }
}
