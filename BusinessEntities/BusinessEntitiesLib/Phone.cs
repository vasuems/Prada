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
using Com.MvTech.BusinessEntities;

namespace Com.MvTech.BusinessEntities
{
    public abstract class Phone : BaseEntity
    {
        public virtual short NatinalCode
        {
            get;
            set;
        }
        public virtual short CityCode
        {
            get;
            set;
        }
    }
}

