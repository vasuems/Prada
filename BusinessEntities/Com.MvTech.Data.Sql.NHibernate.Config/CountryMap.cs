using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities;
using FluentNHibernate.Mapping;



namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    public class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            HasMany(x => x.States);
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();
        }
    }
}
