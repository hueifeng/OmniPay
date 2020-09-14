﻿using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;


namespace OmniPay.Alipay.Request
{
    public class BarCodePayRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public BarCodePayRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.pay");
        }
    }
}
