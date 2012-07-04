using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Com.MvTech.BusinessEntities.BP; 
using Com.MvTech.BusinessEntities;
using Com.MvTech.Framework.Db;

namespace Com.MvTech.BusinessComponents
{
    public abstract class BaseBusinessComponent : IDbCommand
    {
        public BaseBusinessComponent()
        {
        }
        public BaseBusinessComponent(BaseEntity baseEntity)
        {
        }

        public virtual void Add()
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete()
        {
            throw new NotImplementedException();
        }

        public virtual object Get()
        {
            throw new NotImplementedException();
        }

        public virtual object GetMany()
        {
            throw new NotImplementedException();
        }

        public virtual object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
