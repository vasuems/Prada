using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MvTech.Framework.Db
{
    public class DbInstanceDetails
    {
        public int Id
        {
            get;
            set;
        }
        public int StartRecordId
        {
            get;
            set;
        }
        public int EndRecordId
        {
            get;
            set;
        }
        public string DbInstanceName
        {
            get;
            set;
        }
        public string ConnectionString
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get;
            set;
        }
        public bool TimeStamp
        {
            get;
            set;
        }
    }
}
