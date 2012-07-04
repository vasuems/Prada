using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MvTech.BusinessEntities
{
    public class BpCommunicationAddress : Address
    {
        public virtual int AddressId
        {
            get;
            set;
        }
    }
}
