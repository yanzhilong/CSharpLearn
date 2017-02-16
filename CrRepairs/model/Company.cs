using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrRepairs.model
{
    class Company
    {
        private string companyID;
        private string companyName;

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

        public string CompanyName
        {
            get
            {
                return companyName;
            }

            set
            {
                companyName = value;
            }
        }
    }
}
