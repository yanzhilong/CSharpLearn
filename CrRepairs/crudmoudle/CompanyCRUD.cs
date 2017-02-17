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
    public class CompanyCRUD : CrudGridViewBase
    {
        private MySqlModule mySqlModule;
        private string sql = "SELECT * FROM location.company";

        public CompanyCRUD()
        {
            mySqlModule = new MySqlModule();
        }

        public override void Add(List<CrudItem> crudItems)
        {
            CrudItem crudItemID = new CrudItem();
            crudItemID.Valuekey = "公司编号";
            crudItemID.Value = Guid.NewGuid().ToString();
            crudItems.Add(crudItemID);

            string sqlbase = "insert into company({0}) values ({1});";
            StringBuilder columns = new StringBuilder();
            StringBuilder values = new StringBuilder();

            foreach (CrudItem crudItem in crudItems)
            {
                string columnName = getColumeName(crudItem.Valuekey);
                columns.Append(columnName);
                columns.Append(",");

                values.Append("'");
                values.Append(crudItem.Value);
                values.Append("'");
                values.Append(",");
            }

            string columnstr = columns.ToString().Remove(columns.ToString().Length - 1);
            string valuesstr = values.ToString().Remove(values.ToString().Length - 1);
            string sql = String.Format(sqlbase, columnstr, valuesstr);
            mySqlModule.query(sql);
        }

        public override void Delete(Hashtable deleRow)
        {
            string sqlbase = "DELETE FROM company WHERE CompanyID = '{0}'";
            string sql = String.Format(sqlbase, deleRow["公司编号"]);
            mySqlModule.query(sql);
        }

        public override List<CrudItem> getAdds()
        {
            //初始化添加数据项
            List<CrudItem> adds = new List<CrudItem>();

            //公司名称
            CrudItem add_company_Name = new CrudItem();
            add_company_Name.IsbeNull = false;
            add_company_Name.Enable = true;
            add_company_Name.Lable = "公司名称:";
            add_company_Name.Value = "";
            add_company_Name.ValueType = CrudItem.TEXTBOX;
            add_company_Name.Valuekey = "公司名称";
            adds.Add(add_company_Name);

            return adds;
        }

        public override DataTable getGridViewData()
        {
            Hashtable titles = new Hashtable();
            titles.Add("CompanyID", "公司编号");
            titles.Add("CompanyName", "公司名称");

            DataTable datatable = mySqlModule.queryDataTable(this.sql);
            foreach (DictionaryEntry dict in titles)
            {
                datatable.Columns[(string)dict.Key].ColumnName = (string)dict.Value;
            }
            return datatable;
        }

        public override List<CrudItem> getUpdates()
        {
            //初始化更新数据项
            List<CrudItem> updates = new List<CrudItem>();

            //更新公司编号
            CrudItem update_company_ID = new CrudItem();
            update_company_ID.IsbeNull = false;
            update_company_ID.Enable = false;
            update_company_ID.Lable = "公司编号:";
            update_company_ID.Value = "";
            update_company_ID.ValueType = CrudItem.TEXTBOX;
            update_company_ID.Valuekey = "公司编号";
            updates.Add(update_company_ID);

            //更新公司名称
            CrudItem update_company_Name = new CrudItem();
            update_company_Name.IsbeNull = false;
            update_company_Name.Enable = true;
            update_company_Name.Lable = "公司名称:";
            update_company_Name.Value = "";
            update_company_Name.ValueType = CrudItem.TEXTBOX;
            update_company_Name.Valuekey = "公司名称";
            updates.Add(update_company_Name);

            return updates;
        }

        public override void Update(List<CrudItem> crudItems)
        {
            string sqlbase = "UPDATE company SET {0} WHERE CompanyID = '{1}'";
            StringBuilder updates = new StringBuilder();
            CrudItem curdItemID = null;
            foreach (CrudItem crudItem in crudItems)
            {
                if ((string)crudItem.Valuekey == "公司编号")
                {
                    curdItemID = crudItem;
                    continue;
                }
                string columnName = getColumeName(crudItem.Valuekey);
                updates.Append(columnName);
                updates.Append("=");

                updates.Append("'");
                updates.Append(crudItem.Value);
                updates.Append("'");
                updates.Append(",");
            }
            string updatestr = updates.ToString().Remove(updates.ToString().Length - 1);
            string sql = String.Format(sqlbase, updatestr, curdItemID.Value);
            mySqlModule.query(sql);
        }

        private string getColumeName(string valuekey)
        {
            if(valuekey == "公司编号")
            {
                return "CompanyID";
            }else if(valuekey == "公司名称")
            {
                return "CompanyName";
            }
            else
            {
                return "";
            }
        }

    }
}
