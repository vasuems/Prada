using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Com.MvTech.BusinessEntities;


namespace Com.MvTech.Db.Sql.NHibernate.Bp.Mapping
{
    public class BpCommunicationAddressMap : SubclassMap<BpCommunicationAddress>
    {
        public BpCommunicationAddressMap()
        {
            DiscriminatorValue(0);
        }        
    }
}