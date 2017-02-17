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
    public abstract class CrudGridViewBase
    {
        /// <summary>
        /// 增加事件
        /// </summary>
        /// <param name="crudItems"></param>
        public abstract void Add(List<CrudItem> crudItems);

        /// <summary>
        /// 更新事件
        /// </summary>
        /// <param name="crudItems"></param>
        public abstract void Update(List<CrudItem> crudItems);

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="deleRow">要删除的行数据</param>
        public abstract void Delete(Hashtable deleRow);


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
        /// 加载用于显示的表格数据
        /// </summary>
        /// <returns></returns>
        public abstract DataTable getGridViewData();//加载表格数据
    }
}
