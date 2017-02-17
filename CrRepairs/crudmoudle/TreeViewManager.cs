using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.crudmoudle
{
    class TreeViewManager
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
        private string[] getTreeViewIdArray(string treeviewId, Hashtable treeviewIdtable)
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
}
