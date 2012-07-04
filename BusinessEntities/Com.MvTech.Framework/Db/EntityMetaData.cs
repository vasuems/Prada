using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MvTech.Framework.Db
{
    public class EntityMetaData
    {
        public object Id
        {
            get;
            set;
        }
        public string EntityName
        {
            get;
            set;
        }
        public CrudOperation CrudOperation
        {
            get;
            set;
        }
    }
}
