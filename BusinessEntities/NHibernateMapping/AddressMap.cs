using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities;


namespace Com.MvTech.Db.Sql.NHibernate.Bp.Mapping
{
    public enum ActivityType
    {
        [EnumKey("1")]
        [EnumDescription("ImportFromFile")]
        ImportFromFile,
    }
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("BPAddress");
            Id(x => x.ID);
            References(x => x.BP).Column("BPID");
            Map(x => x.Address1);
            Map(x => x.Address2);
            Map(x => x.PinCode);
            Map(x => x.CityId);
            Map(x => x.StateId).Column("StateId");
            Map(x => x.CountryId);
            //Map(x => x.AddressType).CustomType<int>().Column("AddressType").Not.Nullable();
            DiscriminateSubClassesOnColumn<byte>("AddressType",0).AlwaysSelectWithValue();
           // DiscriminateSubClassesOnColumn("AddressType")
           //.AlwaysSelectWithValue()
           //.Formula("arbitrary SQL expression")
           //.ReadOnly()
           //.Length(12)
           //.Not.Nullable()
           //.CustomType<string>();
            Map(x => x.IsEnabled);
            Version(x => x.TimeStamp).Generated.Always();
        }        
    }
}