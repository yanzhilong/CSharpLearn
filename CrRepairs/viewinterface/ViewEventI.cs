using CrRepairs.usercontrol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.viewinterface
{
    public interface ViewEventI
    {
        void exit();//返回
        void submit(List<CrudItem> crudItems);//确认
    }
}
