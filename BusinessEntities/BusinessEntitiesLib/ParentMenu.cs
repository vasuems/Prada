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

namespace Com.MvTech.BusinessEntities
{
    public class ParentMenu : Menu
    {
        public virtual int ApplicationId
        {
            get;
            set;
        }
        public virtual IList<Application> Applications
        {
            get;
            set;
        }
        public virtual IList<ChildMenu> ChildMenus
        {
            get;
            set;
        }
    }
}

