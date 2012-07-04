using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities.Security;

namespace Com.MvTech.BusinessEntities.Users
{
    public class UserRole : BaseEntity
    {
        public virtual User User
        {
            get;
            set;
        }
        public virtual Role Role
        {
            get;
            set;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as UserRole;
            if (t == null)
                return false;
            if (User == t.User && Role == t.Role)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return (User.ID + "|" + Role.ID).GetHashCode();
        }
    }
}
