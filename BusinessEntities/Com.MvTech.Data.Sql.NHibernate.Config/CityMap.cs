using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities;
using FluentNHibernate.Mapping;


namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            References(x => x.State).Column("StateId");
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();            
        }
    }
}
