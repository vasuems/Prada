using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities;
//using NHibernate.Mapping.ByCode;
//using NHibernate.Cfg;
//using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    public class EntityTrackingMap : ComponentMap<EntityTracking>
    {
        public EntityTrackingMap()
        {
            Map(x => x.IsEnabled);
            
        }
    }
}
