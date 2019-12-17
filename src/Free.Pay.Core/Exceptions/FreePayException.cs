using System;

namespace Free.Pay.Core.Exceptions
{
    public class FreePayException:Exception
    {
        public FreePayException(string message)
         : base(message)
        {
        }

    }
}
