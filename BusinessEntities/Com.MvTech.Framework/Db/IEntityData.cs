using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.Framework.Db;

namespace Com.MvTech.Framework.Db
{
    public interface IEntityData
    {
        EntityMetaData GetTableData();
    }
}
