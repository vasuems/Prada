using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities;


namespace Com.MvTech.Db.Sql.NHibernate.Users.Mapping
{
    public class PhoneMap : ClassMap<Phone>
    {
        public PhoneMap()
        {
            Id(x => x.ID).Column("PhoneNumber"); ;
            Map(x => x.NatinalCode);
            Map(x => x.CityCode);
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();
        }
    }
}
