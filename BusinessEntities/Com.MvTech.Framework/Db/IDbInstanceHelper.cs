using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MvTech.Framework.Db
{
    public interface IDbInstanceHelper
    {
        void AddDbInstance(DbInstanceDetails dbInstanceDetails);
        void UpdateDbInstance(DbInstanceDetails dbInstanceDetails);
        DbInstanceDetails GetDbInstance(EntityMetaData entityMetaData);
        IList<DbInstanceDetails> GetAllDbInstance();
    }
}
