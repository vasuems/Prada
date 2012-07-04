using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MvTech.BusinessEntities.Users
{
    public class UserPhone : BaseEntity
    {
        public virtual User User
        {
            get;
            set;
        }
        public virtual MobilePhone MobilePhone
        {
            get;
            set;
        }
        public virtual bool IsDefault
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as UserPhone;
            if (t == null)
                return false;
            if (User == t.User && MobilePhone == t.MobilePhone)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return (User.ID + "|" + MobilePhone.ID).GetHashCode();
        }
    }
}
