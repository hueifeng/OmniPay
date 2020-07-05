using Free.Pay.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Free.Pay.Core.Request
{
    public abstract class BaseRequest<TModel, TResponse> 
    {
        private readonly SortedDictionary<string, object> _values;

        protected BaseRequest()
        {
            _values = new SortedDictionary<string, object>();
        }

        /// <summary>
        ///     请求地址
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        ///     添加参数
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="stringCase">字符串规则策略</param>
        /// <returns></returns>
        public bool AddParameters(object obj, StringCase stringCase=StringCase.Snake)
        {
            var type = obj.GetType();
            MemberInfo[] properties = type.GetProperties();
            MemberInfo[] fields = type.GetFields();

            Add(properties);
            Add(fields);
            return true;

            void Add(MemberInfo[] info)
            {

                foreach (var item in info)
                {
                    string key;
                    if (stringCase is StringCase.Camel)
                    {
                        key = item.Name.ToCamelCase();
                    }
                    else if (stringCase is StringCase.Snake)
                    {
                        key = item.Name.ToSnakeCase();
                    }
                    else
                    {
                        key = item.Name;
                    }

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
            if (_values.Count != 0)
            {
                var sb = new StringBuilder();
                sb.Append("<xml>");
                foreach (var (key, value) in _values)
                {
                    sb.AppendFormat(value is string ? "<{0}><![CDATA[{1}]]></{0}>" : "<{0}>{1}</{0}>", key,
                        value);
                }

                sb.Append("</xml>");

                return sb.ToString();
            }

            return string.Empty;
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public bool Add(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key", "参数名不能为空");

            if (!(value is null) && !string.IsNullOrEmpty(value.ToString()))
            {
                if (Exists(key))
                {
                    _values[key] = value;
                }
                else
                {
                    _values.Add(key, value);
                }

                return true;
            }

            return false;
        }
        /// <summary>
        ///     将xml数据加起来
        /// </summary>
        /// <param name="xml"></param>
        public void FromXml(string xml)
        {
            Clear();
            try
            {
                if (!string.IsNullOrEmpty(xml))
                {
                    var xmlDoc = new XmlDocument()
                    {
                        XmlResolver = null
                    };
                    xmlDoc.LoadXml(xml);
                    var xmlElement = xmlDoc.DocumentElement;
                    if (xmlElement == null) return;
                    var nodes = xmlElement.ChildNodes;
                    foreach (var item in nodes)
                    {
                        var xe = (XmlElement)item;
                        Add(xe.Name, xe.InnerText);
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
        /// <summary>
        /// 将参数转为类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public T ToObject<T>(StringCase stringCase=StringCase.Snake)
        {
            var type = typeof(T);
            var obj = Activator.CreateInstance(type);
            var properties = type.GetProperties();
            
            foreach (var item in properties)
            {
                var key = stringCase switch
                {
                    StringCase.Camel => item.Name.ToCamelCase(),
                    StringCase.Snake => item.Name.ToSnakeCase(),
                    _ => item.Name
                };
                _values.TryGetValue(key, out var value);

                if (value != null)
                {
                    item.SetValue(obj, Convert.ChangeType(value, item.PropertyType));
                }
            }
            return (T)obj;
        }
        public string GetSign()
        {
            var key = "b7c996fbda5a9633ee4feb6b991c3919";
            var data = string.Join("&",
                _values
                    .Select(a => $"{a.Key}={a.Value}"));
            data += $"&key={key}";

            var byteData = Encoding.UTF8.GetBytes(data);
            var byteKey = Encoding.UTF8.GetBytes(key);
            var hmacsha256 = new HMACSHA256(byteKey);
            var result = hmacsha256.ComputeHash(byteData);
            return BitConverter.ToString(result).Replace("-", "").ToUpper();
        }

        /// <summary>
        ///     清空数据
        /// </summary>
        public void Clear()
        {
            _values.Clear();
        }

        /// <summary>
        /// 是否存在指定参数名
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public bool Exists(string key) => _values.ContainsKey(key);

        /// <summary>
        /// 根据参数名获取值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            _values.TryGetValue(key, out var value);
            return value;
        }
        /// <summary>
        ///     根据参数名获取值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public string GetStringValue(string key)
        {
           return GetValue(key)?.ToString();
        }
        /// <summary>
        ///     根据参数名删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Remove(string key) {
            _values.Remove(key);
        }
        public virtual void Execute(){ }
    }
}
