using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using OmniPay.Core.Utils;

namespace OmniPay.Core.Request
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
        ///     转换对象字符串规则策略
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="stringCase">字符串规则策略</param>
        /// <returns></returns>
        public object ToStringCaseObj(object obj, StringCase stringCase = StringCase.Snake)
        {
            dynamic dynamicObj = new System.Dynamic.ExpandoObject();
            foreach (var (itemKey, value) in _values)
            {
                var key = "";
                if (stringCase is StringCase.Camel)
                {
                    key = itemKey.ToCamelCase();
                }
                else if (stringCase is StringCase.Snake)
                {
                    key = itemKey.ToSnakeCase();
                }
                else
                {
                    key = itemKey;
                }
                if (value is null || string.IsNullOrEmpty(value.ToString()))
                {
                    continue;
                }
                ((IDictionary<string, object>)dynamicObj).Add(key, value);
            }
            return dynamicObj;
        }

        /// <summary>
        ///     添加参数
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="stringCase">字符串规则策略</param>
        /// <returns></returns>
        public bool AddParameters(object obj, StringCase stringCase = StringCase.Snake)
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
        ///     将数据转换成Json格式数据
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            if (_values.Count != 0)
            {
                var sb = new StringBuilder();
                sb.Append("{");
                foreach (var (key, value) in _values)
                {
                    var val = value;

                    sb.AppendFormat(key, value);
                }

                sb.Append("}");
            }

            return string.Empty;
        }

        /// <summary>
        /// 将网关数据转换为表单数据
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public string ToForm(string url)
        {
            var html = new StringBuilder();
            html.AppendLine("<body>");
            html.AppendLine($"<form name='gateway' method='post' action ='{url}'>");
            foreach (var item in _values)
            {
                html.AppendLine($"<input type='hidden' name='{item.Key}' value='{item.Value}'>");
            }
            html.AppendLine("</form>");
            html.AppendLine("<script language='javascript' type='text/javascript'>");
            html.AppendLine("document.gateway.submit();");
            html.AppendLine("</script>");
            html.AppendLine("</body>");

            return html.ToString();
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
        public T ToObject<T>(StringCase stringCase = StringCase.Snake)
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

        /// <summary>
        /// 将网关数据转换为Url格式数据
        /// </summary>
        /// <param name="isUrlEncode">是否需要url编码</param>
        /// <returns></returns>
        public string ToUrl(bool isUrlEncode = true)
        {
            return string.Join("&",
                _values
                    .Select(a => $"{a.Key}={(isUrlEncode ? WebUtility.UrlEncode(a.Value.ToString()) : a.Value.ToString())}"));
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
        public void Remove(string key)
        {
            _values.Remove(key);
        }
        public virtual void Execute() { }
    }
}
