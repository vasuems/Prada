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
using Com.MvTech.BusinessEntities.BP;
namespace Com.MvTech.BusinessEntities
{

    public abstract class Address : BaseEntity
    {
        public virtual BusinessPartner BP
        {
            get;
            set;
        }
        public virtual string Address1
        {
            get;
            set;
        }
        public virtual string Address2
        {
            get;
            set;
        }
        public virtual int PinCode
        {
            get;
            set;
        }
        public virtual int CityId
        {
            get;
            set;
        }
        public virtual City City
        {
            get;
            set;
        }
        public virtual int StateId
        {
            get;
            set;
        }
        public virtual State State
        {
            get;
            set;
        }
        public virtual int CountryId
        {
            get;
            set;
        }
        public virtual Country Country
        {
            get;
            set;
        }
        //public virtual string AddressType
        //{
        //    get;
        //    set;
        //}
    }
}