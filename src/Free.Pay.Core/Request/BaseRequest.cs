using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Free.Pay.Core.Request
{
    public abstract class BaseRequest<TModel, Response>
    {
        private readonly SortedDictionary<string, object> _values;

        public SortedDictionary<string, object>.KeyCollection Keys => _values.Keys;

        public SortedDictionary<string, object>.ValueCollection Values => _values.Values;

        public BaseRequest()
        {
            _values=new SortedDictionary<string, object>();
        }


        public string RequestUrl { get; set; }

        /// <summary>
        ///     获取所有Key-value形式的文本请求参数字典。
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetParameters()
        {
            throw new NotImplementedException("stack not Implement");
        }
        /// <summary>
        ///     添加参数
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public bool AddParameters(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            var fields = type.GetFields();

            Add(properties);
            Add(fields);
            return true;

            void Add(MemberInfo[] info)
            {

                foreach (var item in info)
                {
                    var key = item.Name.ToLower();

                    var value = item.MemberType switch
                    {
                        MemberTypes.Field => ((FieldInfo)item).GetValue(obj),
                        MemberTypes.Property => ((PropertyInfo)item).GetValue(obj),
                        _ => throw new NotImplementedException(),
                    };
                    if (value is null || string.IsNullOrEmpty(value.ToString()))
                    {
                        continue;
                    }
                    _values.Add(key, value);
                }


            }
        }

        /// <summary>
        /// 将数据转成Xml格式数据
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            if (_values.Count == 0)
            {
                return string.Empty;
            }
            var sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (var item in _values)
            {
                if (item.Value is string)
                {
                    sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", item.Key, item.Value);

                }
                else
                {
                    sb.AppendFormat("<{0}>{1}</{0}>", item.Key, item.Value);
                }
            }
            sb.Append("</xml>");

            return sb.ToString();
        }




    }
}
