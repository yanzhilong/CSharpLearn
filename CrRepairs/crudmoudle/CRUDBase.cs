using CrRepairs.usercontrol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.crudmoudle
{
    public abstract class CRUDBase
    {
        public const int GRIDVIEW = 0;//显示表格数据
        public const int TREEVIEW = 1;//显示目录树数据

        private int displayType;//展示类型
        private string sql;//查询用的sql数据
        private Hashtable titles;//数据的列名和显示
        private Hashtable hashtableTree;//目录树数据
        private Hashtable treeViewNodeTable;//id和TreeViewNode数据
        private List<CrudItem> updates;//要更新数据的时候允许更改的字段列表
        private List<CrudItem> adds;//要添加数据的时候允许增加的数据列表
        private CRUDEvent crudEvent;//按钮事件
        private TreeViewEvent treeViewEvent;//树事件
        

        public abstract CRUDBase refreshData();

        
        public Hashtable Titles
        {
            get
            {
                return Titles1;
            }

            set
            {
                Titles1 = value;
            }
        }



        public Hashtable Titles1
        {
            get
            {
                return titles;
            }

            set
            {
                titles = value;
            }
        }

        public List<CrudItem> Updates
        {
            get
            {
                return updates;
            }

            set
            {
                updates = value;
            }
        }

        public List<CrudItem> Adds
        {
            get
            {
                return adds;
            }

            set
            {
                adds = value;
            }
        }


        public string Sql
        {
            get
            {
                return sql;
            }

            set
            {
                sql = value;
            }
        }

        internal CRUDEvent CrudEvent
        {
            get
            {
                return crudEvent;
            }

            set
            {
                crudEvent = value;
            }
        }

        public Hashtable HashtableTree
        {
            get
            {
                return hashtableTree;
            }

            set
            {
                hashtableTree = value;
            }
        }

        public int DisplayType
        {
            get
            {
                return displayType;
            }

            set
            {
                displayType = value;
            }
        }

        public TreeViewEvent TreeViewEvent
        {
            get
            {
                return treeViewEvent;
            }

            set
            {
                treeViewEvent = value;
            }
        }

        public Hashtable TreeViewNodeTable
        {
            get
            {
                return treeViewNodeTable;
            }

            set
            {
                treeViewNodeTable = value;
            }
        }
    }
}
