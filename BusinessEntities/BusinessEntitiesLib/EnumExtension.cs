using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Data;

namespace Com.MvTech.BusinessEntities
{


    /// <summary>
    /// Functions to help with enum's
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// used to support locking in multi-threaded scenario
        /// </summary>
        private static readonly object _lockObject = new object();

        /// <summary>
        /// Using Key collection to hold an array by child type (full name of enum).
        /// This way the Keys only need to load once.
        /// Each enum will have its own array in the dictionary
        /// </summary>
        private static HybridDictionary _keys = new HybridDictionary();
        /// <summary>
        /// Holds an array of Description of the values per child type (full name of enum).
        /// This way the Description names only need to load once.
        /// Each enum will have its own array in the dictionary
        /// </summary>
        private static HybridDictionary _descriptions = new HybridDictionary();


        /// <summary>
        /// Gets the <see cref="EnumDescriptionAttribute" /> of an <see cref="Enum" /> 
        /// type value.
        /// Might not work right with enum having flagattribute
        /// </summary>
        /// <param name="value">The <see cref="Enum" /> type value.</param>
        /// <returns>A string containing the text of the
        /// <see cref="EnumDescriptionAttribute"/>.</returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            //get enum type
            Type enumType = value.GetType();

            //retrieve description dictionary
            Dictionary<string, string> enumDict = GetDescriptionDictionaryForEnum(enumType);

            //return the value associated to the enum's value's name.
            return enumDict[value.ToString()];

        }

        /// <summary>
        /// Gets the <see cref="EnumDescriptionAttribute" /> of an <see cref="Enum" /> 
        /// type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum" /> type value.</param>
        /// <returns>A string containing the text of the
        /// <see cref="EnumDescriptionAttribute"/>.</returns>
        public static string GetDescription<T>(this T value) 
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            //is ther a way to force this with a where?
            if (!typeof(T).IsEnum) throw new ArgumentException("Type argument must be Enum type");

            Type enumType = value.GetType();

            //retrieve description dictionary
            Dictionary<string, string> enumDict = GetDescriptionDictionaryForEnum(enumType);

            //return value associated to the enum's value's name.
            return enumDict[value.ToString()];

        }

        /// <summary>
        /// Checks if Description Dictionary is loaded, loads, and returns Dictionary
        /// Uses full name of the enum.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetDescriptionDictionaryForEnum(Type enumType)
        {
            Dictionary<string, string> enumDict = (Dictionary<string, string>)_descriptions[enumType.FullName];
            if (enumDict == null)
            {
                //most likely not loaded, so need to load
                LoadDescriptions(enumType);
                //get values out
                enumDict = (Dictionary<string, string>)_descriptions[enumType.FullName];
            }
            return enumDict;
        }


        /// <summary>
        /// Load up Descriptions so that don't have to Reflect over and over
        /// </summary>
        /// <param name="enumType"></param>
        private static void LoadDescriptions(Type enumType)
        {
            //check if have _values loaded
            if (_descriptions.Contains(enumType.FullName) == false)
            {
                lock (_lockObject)
                {
                    //now have locked, check if somebody else still put value in
                    if (_descriptions.Contains(enumType.FullName) == false)
                    {
                        //load up
                        Dictionary<string, string> enumDict = new Dictionary<string, string>();
                        //get values and load up dictionary
                        foreach (string name in Enum.GetNames(enumType))
                        {
                            
                            FieldInfo fieldInfo = enumType.GetField(name);

                            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])
                                                    fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                            if (attributes != null && attributes.Length > 0)
                            {
                                string description = attributes[0].Description;
                                enumDict.Add(name, description);
                            }
                            else
                            {
                                //didn't have a description or attribute so use the name.
                                enumDict.Add(name, name);
                            }
                        }
                        //put dictionary in hybrid.
                        _descriptions.Add(enumType.FullName, enumDict);
                    }

                }

            }
        }


        /// <summary>
        /// Converts the <see cref="Enum" /> type to an <see cref="List" /> 
        /// compatible object. Using KeyValuePair with Key being the value and Description the Value.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="List"/> containing the enumerated
        /// type value and description.</returns>
        public static List<KeyValuePair<Enum, string>> ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            List<KeyValuePair<Enum, string>> list = new List<KeyValuePair<Enum, string>>();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }


        /// <summary>
        /// Gets the <see cref="EnumKeyAttribute" /> of an <see cref="Enum" /> 
        /// type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum" /> type value.</param>
        /// <returns>A string containing the text of the
        /// <see cref="EnumKeyAttribute"/>.</returns>
        public static string GetKey(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Type enumType = value.GetType();

            //retrieve enumDictionary from static
            Dictionary<string, string> enumDict = GetKeyDictionaryForEnum(enumType);
            return enumDict[value.ToString()];

        }

        /// <summary>
        /// Gets the <see cref="EnumKeyAttribute" /> of an <see cref="Enum" /> 
        /// type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum" /> type value.</param>
        /// <returns>A string containing the text of the
        /// <see cref="EnumKeyAttribute"/>.</returns>
        public static string GetKey<T>(this T value) //where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (!typeof(T).IsEnum) throw new ArgumentException("Type argument must be Enum type");

            Type enumType = value.GetType();

            //retrieve enumDictionary from static
            Dictionary<string, string> enumDict = GetKeyDictionaryForEnum(enumType);

            return enumDict[value.ToString()];

        }

        /// <summary>
        /// For an enum, retrieve its Dictionary of Key's
        /// Uses full name of the enum.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetKeyDictionaryForEnum(Type enumType)
        {
            Dictionary<string, string> enumDict = (Dictionary<string, string>)_keys[enumType.FullName];
            if (enumDict == null)
            {
                //most likely not loaded, so need to load
                LoadKeys(enumType);
                enumDict = (Dictionary<string, string>)_keys[enumType.FullName];
            }
            return enumDict;
        }


        private static void LoadKeys(Type enumType)
        {
            //check if have _values loaded
            if (_keys.Contains(enumType.FullName) == false)
            {
                lock (_lockObject)
                {
                    //now have locked, check if somebody else still put value in
                    if (_keys.Contains(enumType.FullName) == false)
                    {
                        //load up
                        Dictionary<string, string> enumDict = new Dictionary<string, string>();
                        //get values
                        //foreach (string name in Enum.GetNames(enumType))
                        //{

                         //   FieldInfo fieldInfo = enumType.GetField(name);
                        const string fieldValueName = "value__";
                        foreach (FieldInfo fieldInfo in enumType.GetFields()) //couldn't use binding
                        {
                            if (fieldInfo.Name != fieldValueName) //hack
                            {

                                EnumKeyAttribute[] attributes = (EnumKeyAttribute[])
                                                        fieldInfo.GetCustomAttributes(typeof(EnumKeyAttribute), false);

                                if (attributes != null && attributes.Length > 0)
                                {
                                    string description = attributes[0].Description;
                                    //enumDict.Add(name, description);
                                    enumDict.Add(fieldInfo.Name, description);
                                }
                                else
                                {
                                    //if don't have a key attribute, load with field name
                                    //enumDict.Add(name, name);
                                    enumDict.Add(fieldInfo.Name, fieldInfo.Name);
                                }
                            }
                        }
                        _keys.Add(enumType.FullName, enumDict);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a DataTable with two columns,
        /// the first for the Description
        /// the second for the Value
        /// </summary>
        public static DataTable GetDescriptionValuesTable(this Type type)
        {

            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (type.IsEnum == false)
            {
                throw new ArgumentException("Type argument must be Enum type");
            }
            const string FieldNameDescription = "Description";
            const string FieldNameValue = "Value";

            //create table
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            DataRow dr;
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = FieldNameDescription;
            dc.AutoIncrement = false;
            dc.Caption = FieldNameDescription;
            dc.ReadOnly = true;
            dc.Unique = true;
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = typeof(Int64); // _value.GetType(); 
            dc.ColumnName = FieldNameValue;
            dc.AutoIncrement = false;
            dc.Caption = FieldNameValue;
            dc.ReadOnly = true;
            dc.Unique = true;
            dt.Columns.Add(dc);


            foreach (Enum enumValue in Enum.GetValues(type))
            {
                dr = dt.NewRow();
                dr[FieldNameDescription] = GetDescription(enumValue);
                dr[FieldNameValue] = enumValue;
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;

        }


        /// <summary>
        /// Returns an enum using stringName to make the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringName"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T EnumParse<T>(this string stringName, bool ignoreCase)
        {

            if (string.IsNullOrEmpty(stringName))
            {
                throw new ArgumentNullException("stringaName","stringName is null or empty");
            }

            stringName = stringName.Trim();

            if (stringName.Length == 0)
            {
                throw new ArgumentException("Must specify valid information for parsing in the string.", "stringName");
            }

            Type t = typeof(T);

            if (!t.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.", "T");
            }

            T enumValue = (T)Enum.Parse(t, stringName, ignoreCase);

            return enumValue;
        }

        /// <summary>
        /// Uses the Key to return an enum.
        /// Key should not have a space in the front or back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T EnumParseKey<T>(this string key, bool ignoreCase)
        {
            //actually an extension of string, not enum.

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key is null or empty","key");
            }

            key = key.Trim();

            if (key.Length == 0)
            {
                throw new ArgumentException("Must specify valid information for parsing in the string.", "value");
            }

            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.", "T");
            }

            Array enumValues = Enum.GetValues(type);
            //probably work faster if stored on Key, but currently storing on value.
            foreach (Enum enumVal in enumValues)
            {
                if (GetKey(enumVal).CompareTo(key) == 0)
                    return (T)Enum.Parse(type, enumVal.ToString(), ignoreCase);
            }
            throw new ArgumentException("Must specify a valid Enum key value.", "value");
        }

        /// <summary>
        /// Uses the Key to return the first enum with the supplied key.
        /// Key may have a space in the front or back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="ignoreCase">if true will not trim off spaces</param>
        /// <returns></returns>
        public static T EnumParseKey<T>(string key, bool ignoreCase, bool ignoreLeadingTrailingSpaces)
        {

            if (String.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key","key is null or empty");
            }

            if (!ignoreLeadingTrailingSpaces)
            {
                key = key.Trim();

                if (key.Length == 0)
                {
                    throw new ArgumentException("Must specify valid information for parsing the key to the enum's value.", "key");
                }
            }

            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("Type provided must be an enum.", "T");
            }

            Array enumValues = Enum.GetValues(type);

            foreach (Enum enumVal in enumValues)
            {
                if (GetKey(enumVal).CompareTo(key) == 0)
                    return (T)Enum.Parse(type, enumVal.ToString(), ignoreCase);
            }
            throw new ArgumentException(string.Format("enum key ({0}) not found.",key), "key");
        }

        /// <summary>
        /// Uses the Key to return the first enum with the supplied key.
        /// Key may have a space in the front or back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="ignoreCase">if true will not trim off spaces</param>
        /// <returns></returns>
        public static T EnumParseKey<T>(this T parseEnum, string key, bool ignoreCase, bool ignoreLeadingTrailingSpaces)
        {
            if (parseEnum == null)
            {
                throw new ArgumentNullException("value");
            }
            //is ther a way to force this with a where?
            if (!typeof(T).IsEnum) throw new ArgumentException("Type argument must be Enum type");

            if (String.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", "key is null or empty");
            }

            if (!ignoreLeadingTrailingSpaces)
            {
                key = key.Trim();

                if (key.Length == 0)
                {
                    throw new ArgumentException("Must specify valid information for parsing the key to the enum's value.", "key");
                }
            }

            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("Type provided must be an enum.", "T");
            }

            Array enumValues = Enum.GetValues(type);

            foreach (Enum enumVal in enumValues)
            {
                if (GetKey(enumVal).CompareTo(key) == 0)
                    return (T)Enum.Parse(type, enumVal.ToString(), ignoreCase);
            }
            throw new ArgumentException(string.Format("enum key ({0}) not found.", key), "key");
        }



        /// <summary>
        /// Returns the first Enum with the supplied Description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T EnumParseDescription<T>(string description, bool ignoreCase)
        {

            if (String.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description","description is null or empty.");
            }

            description = description.Trim();

            if (description.Length == 0)
            {
                throw new ArgumentException("description is null or empty.", "description");
            }

            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.", "T");
            }

            Array enumValues = Enum.GetValues(type);

            foreach (Enum enumVal in enumValues)
            {
                if (GetDescription(enumVal).CompareTo(description) == 0)
                    return (T)Enum.Parse(type, enumVal.ToString(), ignoreCase);
            }
            throw new ArgumentException(string.Format("enum description ({0}) not found.",description), "description");
        }


    }
}

