using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MvTech.Framework.Db
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class InsertAttribute : Attribute
    {
    }
}
