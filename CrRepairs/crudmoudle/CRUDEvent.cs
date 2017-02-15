using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.crudmoudle
{
    public interface CRUDEvent
    {
        void add(Hashtable hashtable);//添加数据
        void update(Hashtable hashtable);//修改数据
        void delete(Hashtable hashtable);//删除
    }
}
