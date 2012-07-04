using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MvTech.BusinessEntities
{
    public enum AddressType
    {
        [EnumKey("0")]
        [EnumDescription("PermanentAddress")]
        PermanentAddress,
        [EnumKey("1")]
        [EnumDescription("CommunicationAddress")]
        CommunicationAddress,
    }
}
