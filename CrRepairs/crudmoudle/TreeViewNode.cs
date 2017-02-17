using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.crudmoudle
{
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
