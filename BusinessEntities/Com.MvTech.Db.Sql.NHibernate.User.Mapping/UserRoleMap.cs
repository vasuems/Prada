using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities.Users;


namespace Com.MvTech.Db.Sql.NHibernate.Users.Mapping
{
    public class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Table("UserRoleMapping");
            CompositeId().KeyReference(x => x.User,"User").KeyReference(x => x.Role,"RoleId");
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();
        }
    }
}
