using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities;
using FluentNHibernate.Mapping;


namespace Com.MvTech.Db.Sql.NHibernate.Config.Mapping
{
    public class ChildMenuMap : SubclassMap<ChildMenu>
    {
        public ChildMenuMap()
        {
            KeyColumn("ID");
            References(x => x.ParentMenu);
        }
    }
}
