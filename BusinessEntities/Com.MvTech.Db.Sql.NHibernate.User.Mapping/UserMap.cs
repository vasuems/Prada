using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities.Users;


namespace Com.MvTech.Db.Sql.NHibernate.Users.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.ID).GeneratedBy.Assigned();
            Map(x => x.Name).Column("FirstName");
            Map(x => x.LastName);
            Map(x => x.DOB);
            Map(x => x.EMail);
            Map(x => x.Gender);
            //HasManyToMany(x => x.MobilePhones)
            //.Cascade.All()
            //.Table(/"UserPhoneDetails");
            //HasManyToMany(x => x.Roles)
            //.Cascade.All()
            //.Table("UserRoleMapping");
            Version(x => x.TimeStamp).Generated.Always();
        }
    }
}
