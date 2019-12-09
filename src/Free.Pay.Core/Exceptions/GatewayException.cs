using System;

namespace Free.Pay.Core.Exceptions
{
    public class GatewayException:Exception
    {
        public GatewayException(string message)
         : base(message)
        {
        }

    }
}
