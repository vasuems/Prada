﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.MvTech.BusinessEntities.BP
{

    public class BusinessPartner : BaseEntity
    {
        //byte[] timeStamp;
        public virtual Address communicationAddress
        {
            get;
            set;
        }

        public virtual Address PermanentAddress
        {
            get;
            set;
        }

        public virtual byte [] TimeStamp
        {
            get;
            set;
        }
        public virtual bool IsEnabled
        {
            get;
            set;
        }
    }
}

