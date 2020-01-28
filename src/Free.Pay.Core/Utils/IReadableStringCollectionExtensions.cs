using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.Extensions.Primitives;

namespace Free.Pay.Core.Utils
{
    public static class IReadableStringCollectionExtensions
    {
        public static NameValueCollection AsNameValueCollection(this IEnumerable<KeyValuePair<string,StringValues>> collection){
            var nv=new NameValueCollection();
            foreach (var field in collection)
            {
                nv.Add(field.Key,field.Value.First());
            }
            return nv;
        }

        public static NameValueCollection AsNameValueCollection(this IDictionary<string,StringValues> collection){
            var nv=new NameValueCollection();
            foreach (var field in collection)
            {
                 nv.Add(field.Key,field.Value.First());
            }
            return nv;
        }
    }
}