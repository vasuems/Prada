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
using Com.MvTech.BusinessEntities.Users;

namespace Com.MvTech.BusinessEntities.Security
{
    public class Role : BaseEntity
    {

        public virtual IEnumerable<User> Users
        {
            get;
            set;
        }
    }
}

