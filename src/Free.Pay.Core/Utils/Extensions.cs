using System;

namespace Free.Pay.Core.Utils
{
    public class Extensions
    {
        public static string GetNonceStr()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
