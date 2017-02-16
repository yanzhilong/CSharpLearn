using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.usercontrol
{
    /// <summary>
    /// 增改的单项
    /// </summary>
    public class CrudItem
    {
        public const int TEXTBOX = 0;//文本框
        public const int COMBOBOX = 1;//下拉列表框
        public const int TREEVIEW = 2;//树型选择框
        public const int RADIOBUTTON = 3;//单选 
        public const int TIP = 4;//提示信息 

        private string valuekey;//用于获取数据
        private string lable;//显示标签
        private string value;//值
        private bool isbeNull;//是否可以为空
        private bool enable;//是否可编辑
        private int valueType;//值类型
        private string[] combovalue;//下拉列表选择值
        private Hashtable treevalue;//树型选择框

        public string Lable
        {
            get
            {
                return lable;
            }

            set
            {
                lable = value;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

       

        public int ValueType
        {
            get
            {
                return valueType;
            }

            set
            {
                valueType = value;
            }
        }

        public string[] Combovalue
        {
            get
            {
                return combovalue;
            }

            set
            {
                combovalue = value;
            }
        }

        public Hashtable Treevalue
        {
            get
            {
                return treevalue;
            }

            set
            {
                treevalue = value;
            }
        }

        public string Valuekey
        {
            get
            {
                return valuekey;
            }

            set
            {
                valuekey = value;
            }
        }

        public bool IsbeNull
        {
            get
            {
                return isbeNull;
            }

            set
            {
                isbeNull = value;
            }
        }

        public bool Enable
        {
            get
            {
                return enable;
            }

            set
            {
                enable = value;
            }
        }
    }
}
