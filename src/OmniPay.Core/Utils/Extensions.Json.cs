using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace OmniPay.Core.Utils {
    public static partial class Extensions {
        /// <summary>
        ///     反序列化
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static object ToJson (this string Json) {
            return Json == null ? null : JsonConvert.DeserializeObject (Json);
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson (this object obj) {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject (obj, timeConverter);
        }
        public static string ToJson (this object obj, string datetimeformats) {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject (obj, timeConverter);
        }
        public static T ToObject<T> (this string Json) {
            return Json == null ? default (T) : JsonConvert.DeserializeObject<T> (Json);
        }
        public static List<T> ToList<T> (this string Json) {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>> (Json);
        }
        public static DataTable ToTable (this string Json) {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable> (Json);
        }
        public static JObject ToJObject (this string Json) {
            return Json == null ? JObject.Parse ("{}") : JObject.Parse (Json.Replace ("&nbsp:", ""));
        }

    }
}