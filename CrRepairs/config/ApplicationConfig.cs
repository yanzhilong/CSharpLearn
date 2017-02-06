using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyz.ibean.model;

namespace xyz.ibean.config
{
    class ApplicationConfig
    {
        //MySql参数
        public static string mysql_user = "root";
        public static string mysql_password = "tiger";
        public static string mysql_server = "localhost";
        public static string mysql_database = "location";
        public static string mysql_port = "3306";
        public static string mysql_connection = String.Format("server={0};port={1};database={2};user={3};password={4}",mysql_server,mysql_port,mysql_database,mysql_user, mysql_password);
    }
}
