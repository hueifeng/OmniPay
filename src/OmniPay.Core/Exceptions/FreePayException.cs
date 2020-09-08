using System;

namespace OmniPay.Core.Exceptions
{
    public class OmniPayException : Exception
    {
        public OmniPayException(string message)
         : base(message)
        {
        }

    }
}
