using System;

namespace Free.Pay.Core.Utils
{
    public static partial class Extensions
    {
        public static string GetNonceStr()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
