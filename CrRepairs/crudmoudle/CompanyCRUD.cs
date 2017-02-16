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

namespace CrRepairs.crudmoudle
{
    class CompanyCRUD : CRUDBase , CRUDEvent
    {
        private MySqlModule mySqlModule;
        //private string sql;//查询用的sql数据
        //private Hashtable titles;//数据的列名和显示
        //private List<CrudItem> updates;//要更新数据的时候允许更改的字段列表
        //private List<CrudItem> adds;//要添加数据的时候允许增加的数据列表
        //private CRUDEvent crudEvent;//按钮事件
        public CompanyCRUD()
        {
            mySqlModule = new MySqlModule();
            //初始化标题
            Hashtable hashtable = new Hashtable();
            hashtable.Add("CompanyID", "公司编号");
            hashtable.Add("CompanyName", "公司名称");
            this.Titles = hashtable;

            //初始化sql
            this.Sql = "SELECT * FROM location.company";

            //初始化添加数据项
            List<CrudItem> adds = new List<CrudItem>();

            //公司名称
            CrudItem add_company_Name = new CrudItem();
            add_company_Name.IsbeNull = false;
            add_company_Name.Enable = true;
            add_company_Name.Lable = "公司名称:";
            add_company_Name.Value = "";
            add_company_Name.ValueType = CrudItem.TEXTBOX;
            add_company_Name.Valuekey = "CompanyName";
            adds.Add(add_company_Name);
            this.Adds = adds;


            //初始化更新数据项
            List<CrudItem> updates = new List<CrudItem>();

            //更新公司编号
            CrudItem update_company_ID = new CrudItem();
            update_company_ID.IsbeNull = false;
            update_company_ID.Enable = false;
            update_company_ID.Lable = "公司编号:";
            update_company_ID.Value = "";
            update_company_ID.ValueType = CrudItem.TEXTBOX;
            update_company_ID.Valuekey = "CompanyID";
            updates.Add(update_company_ID);

            //更新公司名称
            CrudItem update_company_Name = new CrudItem();
            update_company_Name.IsbeNull = false;
            update_company_Name.Enable = true;
            update_company_Name.Lable = "公司名称:";
            update_company_Name.Value = "";
            update_company_Name.ValueType = CrudItem.TEXTBOX;
            update_company_Name.Valuekey = "CompanyName";
            updates.Add(update_company_Name);

            

            this.Updates = updates;

            this.CrudEvent = this;
        }

        public void add(Hashtable hashtable)
        {
            hashtable.Add("CompanyID", Guid.NewGuid().ToString());
            string sqlbase = "insert into company({0}) values ({1});";
            StringBuilder columns = new StringBuilder();
            StringBuilder values = new StringBuilder();
            foreach (DictionaryEntry de in hashtable)
            {
                columns.Append((string)de.Key);
                columns.Append(",");

                values.Append("'");
                values.Append((string)de.Value);
                values.Append("'");
                values.Append(",");
            }
            string columnstr = columns.ToString().Remove(columns.ToString().Length - 1);
            string valuesstr = values.ToString().Remove(values.ToString().Length - 1);
            string sql = String.Format(sqlbase, columnstr, valuesstr);
            mySqlModule.query(sql);
        }

        public void delete(Hashtable hashtable)
        {
            
            string sqlbase = "DELETE FROM company WHERE CompanyID = '{0}'";
            string sql = String.Format(sqlbase,hashtable["CompanyID"]);
            mySqlModule.query(sql);
        }

        public DataTable loadGridViewData()
        {
            DataTable datatable = mySqlModule.queryDataTable(this.Sql);
            foreach (DictionaryEntry dict in this.Titles)
            {
                if (dict.Value != null)
                {
                    datatable.Columns[(string)dict.Key].ColumnName = (string)dict.Value;
                }
            }
            return datatable;
        }

        public Hashtable loadTreeViewData()
        {
            throw new NotImplementedException();
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
    }
}
