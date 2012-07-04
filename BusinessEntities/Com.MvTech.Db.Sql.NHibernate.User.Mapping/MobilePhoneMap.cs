﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities;


namespace Com.MvTech.Db.Sql.NHibernate.Users.Mapping
{
    public class MobilePhoneMap : SubclassMap<MobilePhone>
    {
        public MobilePhoneMap()
        {
            KeyColumn("MobilePhone");
        }
    }
}