using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Com.MvTech.BusinessEntities.BP; 
using Com.MvTech.BusinessEntities;

namespace Com.MvTech.BusinessComponents
{
    public class BusinessPartnerBusinessComponent : BaseBusinessComponent
    {
        private BusinessPartner bp;
        public BusinessPartnerBusinessComponent(BaseEntity baseEntity)
        {
            this.bp = baseEntity as BusinessPartner;
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override object Get()
        {
            throw new NotImplementedException();
        }

        public override object GetMany()
        {
            throw new NotImplementedException();
        }

        public override object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
