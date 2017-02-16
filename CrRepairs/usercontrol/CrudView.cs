using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using CrRepairs.viewinterface;
using CrRepairs.crudmoudle;

namespace CrRepairs.usercontrol
{
    public partial class CrudView : UserControl
    {
        public const int ADD = 0;
        public const int UPDATE = 1;

        private int OperaterType;
        private ViewEventI ve;
        private CRUDEvent crudEvent;
        private List<CrudItem> crudItems;//要添加或修改的字段
        public CrudView(CRUDEvent crudEvent, ViewEventI i,int operatertype)
        {
            InitializeComponent();
            this.ve = (ViewEventI)i;
            this.crudEvent = crudEvent;
            this.OperaterType = operatertype;
        }


        //public void addItems(Hashtable hashtable)
        //{
        //    foreach (DictionaryEntry dict in hashtable)
        //    {
        //        string lable = (string)dict.Key;
        //        string value = (string)dict.Value;
        //        CRUDLableTextBox crudltb = new CRUDLableTextBox(lable, value);
        //        this.flowLayoutPanel1.Controls.Add(crudltb);
        //    }
        //}

        public void addItems(List<CrudItem> crudItems)
        {
            this.crudItems = crudItems;
            foreach (CrudItem cruditem in crudItems)
            {
                switch (cruditem.ValueType)
                {
                    case CrudItem.TEXTBOX:
                        CRUDLableTextBox crudTextBox = new CRUDLableTextBox(cruditem.Lable, cruditem.Value,cruditem.Enable);
                        crudTextBox.Tag = cruditem.Valuekey;
                        this.flowLayoutPanel1.Controls.Add(crudTextBox);
                        break;
                    case CrudItem.COMBOBOX:
                        CRUDLableCombo crudLableCombo = new CRUDLableCombo(cruditem.Lable, cruditem.Combovalue);
                        crudLableCombo.Tag = cruditem.Valuekey;
                        this.flowLayoutPanel1.Controls.Add(crudLableCombo);
                        break;
                    case CrudItem.TREEVIEW:
                        //Cr crudLableCombo = new CRUDLableCombo(cruditem.Lable, cruditem.Combovalue);
                        //crudLableCombo.Tag = cruditem.Valuekey;
                        break;
                    case CrudItem.RADIOBUTTON:
                        CRUDLableRadioButton CRUDLRB = new CRUDLableRadioButton(cruditem.Lable,cruditem.Combovalue);
                        CRUDLRB.Tag = cruditem.Valuekey;
                        this.flowLayoutPanel1.Controls.Add(CRUDLRB);
                        break;
                    case CrudItem.TIP:
                        CRUDLable lab = new CRUDLable(cruditem.Lable);
                        this.flowLayoutPanel1.Controls.Add(lab);
                        break;
                }
                //string lable = (string)dict.Key;
                //string value = (string)dict.Value;
                //CRUDLableTextBox crudltb = new CRUDLableTextBox(lable, value);
                //this.flowLayoutPanel1.Controls.Add(crudltb);
            }
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            ve.exit();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            Hashtable result = new Hashtable();
            //判断是否有非空值未填写
            foreach (CrudItem cruditem in crudItems)
            {
                if(cruditem.ValueType == CrudItem.TIP)
                {
                    continue;
                }
                string[] itemvalue = getCRUDItemValue(cruditem.Valuekey);
                if (!cruditem.IsbeNull && itemvalue == null || itemvalue[1] == "")
                {
                    if(itemvalue != null && itemvalue.Length > 1)
                    {
                        MessageBox.Show(itemvalue[1] + "不能为空");
                    }else
                    {
                        MessageBox.Show("数据不能为空!");
                    }
                    return;
                }
                result.Add(itemvalue[0], itemvalue[1]);
                //switch (cruditem.ValueType)
                //{
                //    case CrudItem.TEXTBOX:
                //        CRUDLableTextBox crudTextBox = new CRUDLableTextBox(cruditem.Lable, cruditem.Value);
                //        crudTextBox.Tag = cruditem.Valuekey;
                //        this.flowLayoutPanel1.Controls.Add(crudTextBox);
                //        break;
                //    case CrudItem.COMBOBOX:
                //        CRUDLableCombo crudLableCombo = new CRUDLableCombo(cruditem.Lable, cruditem.Combovalue);
                //        crudLableCombo.Tag = cruditem.Valuekey;
                //        this.flowLayoutPanel1.Controls.Add(crudLableCombo);
                //        break;
                //    case CrudItem.TREEVIEW:
                //        //Cr crudLableCombo = new CRUDLableCombo(cruditem.Lable, cruditem.Combovalue);
                //        //crudLableCombo.Tag = cruditem.Valuekey;
                //        break;
                //}
                //string lable = (string)dict.Key;
                //string value = (string)dict.Value;
                //CRUDLableTextBox crudltb = new CRUDLableTextBox(lable, value);
                //this.flowLayoutPanel1.Controls.Add(crudltb);
            }

            if(OperaterType == ADD)
            {
                crudEvent.add(result);
            }
            else
            {
                crudEvent.update(result);
            }
            ve.exit();
        }

        /// <summary>
        /// 获得控件的值
        /// </summary>
        /// <param name="key">指定控件的TAG</param>
        /// <returns>返回数组[key,value]</returns>
        private string[] getCRUDItemValue(string key)
        {
            foreach (Control control in this.flowLayoutPanel1.Controls)
            {
                string ckey = (string)control.Tag;
                if(ckey == key)
                {
                    CRUDItemVIewI crudItemView = (CRUDItemVIewI)control;
                    return new string[] { ckey,crudItemView.getValue() };
                }
            }
            return null;
        }

    }
}
