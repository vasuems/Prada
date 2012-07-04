using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using Com.MvTech.BusinessEntities;
using FluentNHibernate.Mapping;


namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    class ApplicationMap : ClassMap<Application>
    {
        public ApplicationMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            HasManyToMany(x => x.Menus)
            .Cascade.All()
            .Table("MenuApplicationMapping");
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();
        }
    }
}
