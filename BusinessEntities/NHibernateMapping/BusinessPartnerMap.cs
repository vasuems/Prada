using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities.BP;
//using NHibernate.Mapping.ByCode;
//using NHibernate.Mapping.ByCode.Conformist;
using Com.MvTech.Db.Sql.NHibernate.Config.Mapping;
using System.Reflection;
//using NHibernate.Type;
using NHibernate;
using FluentNHibernate.Mapping;


namespace Com.MvTech.Db.Sql.NHibernate.Bp.Mapping
{
    public class BusinessPartnerMap : ClassMap<BusinessPartner>
    {
        public BusinessPartnerMap()
        {
            Id(x => x.ID);
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always().Access.Property();
            
        }
    }
}

