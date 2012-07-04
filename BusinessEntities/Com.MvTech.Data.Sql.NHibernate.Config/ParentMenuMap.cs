using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities;
using FluentNHibernate.Mapping;

namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    public class ParentMenuMap : SubclassMap<ParentMenu>
    {
        public ParentMenuMap()
        {
            KeyColumn("ID");
            HasManyToMany(x => x.Applications)
            .Cascade.All()
            .Table("MenuApplicationMapping");
            //HasMany(x => x.ChildMenus).Inverse().Cascade.All();
        }
    }
}
