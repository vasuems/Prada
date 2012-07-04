using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.Framework.Db;
using FluentNHibernate.Mapping;


namespace Com.MvTech.Db.NHibernateProvider
{
    public class DbInstanceDetailsMap : ClassMap<DbInstanceDetails>
    {
        public DbInstanceDetailsMap()
        {
            Id(x => x.Id);
            Map(x => x.StartRecordId);
            Map(x => x.EndRecordId); 
            Map(x => x.DbInstanceName);
            Map(x => x.ConnectionString);
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();
        }
    }
}
