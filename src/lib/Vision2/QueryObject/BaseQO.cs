﻿ using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Vision2.Attributes;

namespace Vision2.QueryObject {
    public abstract class BaseQO {
        public BaseQO() {
            PageNumber = 0;
            RecordsPerPage = 20;
        }

        [QO("PageIndex")]
        public int? PageNumber { get; set; }

        [QO("PageSize")]
        public int? RecordsPerPage { get; set; }

        [QOIgnore]
        public bool IncludeNulls { get; set; }

        internal string ToQueryString() { //non-encoded query string
            var sb = new StringBuilder();

            var dict = ToDictionary();
            foreach (var key in dict.Keys) {
                sb.Append(key).Append('=').Append(dict[key]).Append('&');
            }

            return sb.ToString().TrimEnd('&');
        }

        internal Dictionary<string, object> ToDictionary() {
            var ret = new Dictionary<string, object>();
            var props = GetType().GetProperties();

            foreach (var p in props) {
                if (!IgnoreProperty(p)) {
                    if (IsRightType(p.PropertyType)) {
                        var value = p.GetValue(this, null);
                        if ((value != null && value.ToString() != string.Empty) || IncludeNulls) {// null means the property won't be the part of search parameters
                            //ret.Add(GetKey(p), value.ToString());
                            var d = value as Nullable<DateTime>;
                            if (d != null) { // DateTime need special handling for converting to string.
                                var format = GetFormat(p);
                                ret.Add(GetKey(p), d.Value.ToString(format == null ? "yyyy-MM-ddThh:mm:ss.fffZ" : format));
                            }
                            else {
                                ret.Add(GetKey(p), value == null ? null : value);
                            }
                        }
                    }
                    else {
                        var message = "All the properties in the DataAccess query object have to be nullable primitive or nullabel datetime or nullable enum or string, property \"" + p.Name + "\" has type : " + p.PropertyType.ToString();
                        throw new Exception(message);
                    }
                }
            }
            return ret;
        }

        private bool IgnoreProperty(PropertyInfo pi) {
            var pa = pi.GetCustomAttributes(typeof(QOIgnoreAttribute), false);
            return pa.Length > 0;
        }

        private string GetKey(PropertyInfo pi) {
            var pa = pi.GetCustomAttributes(typeof(QOAttribute), false);
            return pa.Length == 0 ? pi.Name : ((QOAttribute)pa[0]).Value;
        }

        private string GetFormat(PropertyInfo pi) {
            var pa = pi.GetCustomAttributes(typeof(QOAttribute), false);
            return pa.Length == 0 ? null : ((QOAttribute)pa[0]).Format;
        }

        private bool IsRightType(Type t) {

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                var types = t.GetGenericArguments();
                if (types.Length != 1) // we only take one argument nullable type.
                    return false;
                else
                    t = types[0];
            }

            return AllowedType(t);
        }

        private bool AllowedType(Type t) {
            return t == typeof(string) || t == typeof(DateTime) || t == typeof(TimeSpan) || t == typeof(decimal) || t.IsPrimitive || t.IsEnum;
        }
    }
}
