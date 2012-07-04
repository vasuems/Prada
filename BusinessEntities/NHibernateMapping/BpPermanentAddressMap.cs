using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities;


namespace Com.MvTech.Db.Sql.NHibernate.Bp.Mapping
{
    public class BpPermanentAddressMap : SubclassMap<BpPermanentAddress>
    {
        public BpPermanentAddressMap()
        {
            DiscriminatorValue(1);           
        }        
    }
}