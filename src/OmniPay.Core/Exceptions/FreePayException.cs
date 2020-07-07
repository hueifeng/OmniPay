using System;

namespace OmniPay.Core.Exceptions
{
    public class FreePayException:Exception
    {
        public FreePayException(string message)
         : base(message)
        {
        }

    }
}
