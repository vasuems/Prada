using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.MvTech.BusinessEntities
{
    /// <summary>
    /// Provides a description for an enumerated type.
    /// </summary>
    /// <see cref="http://www.codeproject.com/KB/cs/enumdatabinding.aspx?fid=447577&fr=51#xx0xx"/>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        private string description;

        /// <summary>
        /// the description (Descripton) stored in this attribute.
        /// </summary>
        /// <value>The description stored in the attribute.</value>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="EnumDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">The description to store in this attribute.
        /// </param>
        public EnumDescriptionAttribute(string description)
            : base()
        {
            this.description = description;
        }
    }


    /// <summary>
    /// Provides a second key for an enumerated type.
    /// </summary>
    /// <see cref="http://www.codeproject.com/KB/cs/enumdatabinding.aspx?fid=447577&fr=51#xx0xx"/>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumKeyAttribute : Attribute
    {
        private string description;

        /// <summary>
        /// description (the Key) stored in this attribute.
        /// </summary>
        /// <value>The description stored in the attribute.</value>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="EnumKeyAttribute"/> class.
        /// </summary>
        /// <param name="description">The description to store in this attribute.
        /// </param>
        public EnumKeyAttribute(string description)
            : base()
        {
            this.description = description;
        }
    }


}
