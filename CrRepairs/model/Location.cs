using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.model
{
    /// <summary>
    /// 地址实体
    /// </summary>
    public class Location
    {
        private string locationID;//地址ID
        private string locationPID;//上一级地址ID
        private string locationName;//地址名称
        private string locationCode;//地址编码
        private string locationFullName;//地址全名
        private int locationLevel;//地址级别
        private string companyID;//公司编号

        public string LocationID
        {
            get
            {
                return locationID;
            }

            set
            {
                locationID = value;
            }
        }

        public string LocationPID
        {
            get
            {
                return locationPID;
            }

            set
            {
                locationPID = value;
            }
        }

        public string LocationName
        {
            get
            {
                return locationName;
            }

            set
            {
                locationName = value;
            }
        }

        public string LocationCode
        {
            get
            {
                return locationCode;
            }

            set
            {
                locationCode = value;
            }
        }

        public string LocationFullName
        {
            get
            {
                return locationFullName;
            }

            set
            {
                locationFullName = value;
            }
        }

        public int LocationLevel
        {
            get
            {
                return locationLevel;
            }

            set
            {
                locationLevel = value;
            }
        }

        public string CompanyID
        {
            get
            {
                return companyID;
            }

            set
            {
                companyID = value;
            }
        }
    }
}
