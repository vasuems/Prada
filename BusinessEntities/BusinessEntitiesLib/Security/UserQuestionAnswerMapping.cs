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
    public class UserQuestionAnswerMapping
    {
        public virtual string Answer
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

        public virtual IEnumerable<SecurityQuestion> SecurityQuestion
        {
            get;
            set;
        }

        public virtual EntityTracking EntityTracking
        {
            get;
            set;
        }

    }
}

