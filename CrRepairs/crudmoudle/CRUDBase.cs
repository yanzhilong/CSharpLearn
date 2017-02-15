using CrRepairs.usercontrol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.crudmoudle
{
    public class CRUDBase
    {
        private string sql;//查询用的sql数据
        private Hashtable titles;//数据的列名和显示
        private List<CrudItem> updates;//要更新数据的时候允许更改的字段列表
        private List<CrudItem> adds;//要添加数据的时候允许增加的数据列表
        private CRUDEvent crudEvent;//按钮事件

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
    }
}
