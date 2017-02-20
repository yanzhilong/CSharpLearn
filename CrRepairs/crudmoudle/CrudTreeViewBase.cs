using CrRepairs.usercontrol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.crudmoudle
{
    public abstract class CrudTreeViewBase
    {
        /// <summary>
        /// 增加事件
        /// </summary>
        /// <param name="crudItems">值</param>
        /// <param name="treeViewNode">节点</param>
        public abstract void Add(List<CrudItem> crudItems,TreeViewNode treeViewNode);

        /// <summary>
        /// 更新事件
        /// </summary>
        /// <param name="crudItems">值 </param>
        /// <param name="treeViewNode">节点</param>
        public abstract void Update(List<CrudItem> crudItems, TreeViewNode treeViewNode);

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="treeViewNode">要删除的节点</param>
        public abstract void Delete(TreeViewNode treeViewNode);
        
        /// <summary>
        /// 获得添加所需的字段数据
        /// </summary>
        /// <returns></returns>
        public abstract List<CrudItem> getAdds();

        /// <summary>
        /// 获得更新所需的字段数据
        /// </summary>
        /// <returns></returns>
        public abstract List<CrudItem> getUpdates();

        /// <summary>
        /// 加载用于树形数据,存放id和父id
        /// </summary>
        /// <returns></returns>
        public abstract Hashtable getTreeViewData();


        /// <summary>
        /// 加载用于树形数据,存放id和TreeViewNode
        /// </summary>
        /// <returns></returns>
        public abstract Hashtable getTreeViewNode();

        /// <summary>
        /// 刷新数据
        /// </summary>
        public abstract void refreshData();
    }
}
