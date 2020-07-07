using System;

namespace OmniPay.Core.Utils
{
    public static partial class Extensions
    {
        public static string GetNonceStr()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
