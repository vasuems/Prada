using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    public class TaxMasterMap : ClassMapping<Tax>
    {
        public TaxMasterMap()
        {            
            Id(x => x.ID);
            Property(x => x.Name);
            //Component(x => x.EntityTracking, EntityTrackingMap.Mapping());        
        }
    }
}
