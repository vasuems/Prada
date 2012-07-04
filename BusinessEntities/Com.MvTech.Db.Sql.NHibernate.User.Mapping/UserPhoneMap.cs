using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities.Users;


namespace Com.MvTech.Db.Sql.NHibernate.Users.Mapping
{
    public class UserPhoneMap : ClassMap<UserPhone>
    {
        public UserPhoneMap()
        {
            Table("UserMobilePhoneDetails");
            CompositeId().KeyReference(x => x.User,"UserId").KeyReference(x => x.MobilePhone,"MobilePhone");
            Map(x => x.IsDefault);
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();
        }
    }
}
