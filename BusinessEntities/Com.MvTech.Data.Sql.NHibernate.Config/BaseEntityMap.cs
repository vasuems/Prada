using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode.Conformist;
using Com.MvTech.BusinessEntities;

namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    public class BaseEntityMap
    {
        public static Action<IComponentMapper<BaseEntity>> Mapping()
        {
            return c =>
            {
                c.Property(p => p.ID);
                c.Property(p => p.Name);
            };
        }
    }
}
