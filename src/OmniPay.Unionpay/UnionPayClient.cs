using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using OmniPay.Core.Exceptions;
using OmniPay.Core.Request;
using OmniPay.Core.Utils;
using OmniPay.Unionpay.Request;
using OmniPay.Unionpay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmniPay.Core.Utils.UnionPayUntil;

namespace OmniPay.Unionpay
{
    public class UnionPayClient : IUnionPayClient
    {

        private readonly UnionPayOptions _unionPayOptions;
        private readonly ILogger<UnionPayClient> _logger;

        private UnionPayCertificate SignCertificate;
        private UnionPayCertificate EncryptCertificate;
        private UnionPayCertificate MiddleCertificate;
        private UnionPayCertificate RootCertificate;


        public UnionPayClient(IOptions<UnionPayOptions> unionPayOptions, ILogger<UnionPayClient> logger)
        {
            this._unionPayOptions = unionPayOptions.Value;
            this._logger = logger;

            if (string.IsNullOrWhiteSpace(_unionPayOptions.Version))
            {
                throw new OmniPayException(nameof(_unionPayOptions.Version));
            }
            if (string.IsNullOrWhiteSpace(_unionPayOptions.SignCertPath))
            {
                throw new OmniPayException(nameof(_unionPayOptions.SignCertPath));
            }
            if (string.IsNullOrWhiteSpace(_unionPayOptions.SignCertPwd))
            {
                throw new OmniPayException(nameof(_unionPayOptions.SignCertPwd));
            }

            SignCertificate = UnionPayUntil.GetSignCertificate(_unionPayOptions.SignCertPath, _unionPayOptions.SignCertPwd);
            EncryptCertificate = UnionPayUntil.GetCertificate(_unionPayOptions.EncryptCertPath);
            MiddleCertificate = UnionPayUntil.GetCertificate(_unionPayOptions.MiddleCertPath);
            RootCertificate = UnionPayUntil.GetCertificate(_unionPayOptions.RootCertPath);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TResponse> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {
            BuildParams(request);
            if (request is FrontTransRequest || request is BackTransRequest)
            {
                return (TResponse)Activator.CreateInstance(typeof(TResponse), request);
            }

            string result = await HttpUtil.PostAsync(request.RequestUrl, request.ToUrl());
            var jObject = JObject.Parse(result);
            var jToken = jObject.First.First;
            var baseResponse = (BaseResponse)(object)jToken.ToObject<TResponse>();
            return (TResponse)(object)baseResponse;
        }

        private void BuildParams<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {
            request.Add("version", _unionPayOptions.Version);
            request.Add("encoding", _unionPayOptions.Encoding);
            request.Add("bizType", _unionPayOptions.BizType);
            request.Add("txnTime", _unionPayOptions.TxnTime);
            request.Add("backUrl", _unionPayOptions.BackUrl);
            request.Add("currencyCode", _unionPayOptions.CurrencyCode);
            request.Add("txnType", _unionPayOptions.TxnType);
            request.Add("txnSubType", _unionPayOptions.TxnSubType);
            request.Add("accessType", _unionPayOptions.AccessType);
            request.Add("frontUrl", _unionPayOptions.FrontUrl);
            request.Add("signMethod", _unionPayOptions.SignMethod);
            request.Add("channelType", _unionPayOptions.ChannelType);
            request.Add("merId", _unionPayOptions.MerId);
            request.Add("certId", SignCertificate.certId);
            var strData = request.ToUrl();


            //UnionPayUntil.Sign();
            //var signDigest = SecurityUtil.Sha256(strData, System.Text.Encoding.UTF8);
            //var stringSignDigest = BitConverter.ToString(signDigest).Replace("-", "").ToLower();

            //string stringSign = Convert.ToBase64String(byteSign);

            var stringSignDigest = SHA256.Compute(strData);
            var strSign = UnionPayUntil.SignSha256WithRsa(stringSignDigest, SignCertificate.key);

            request.Add("signature", strSign);

            request.RequestUrl = _unionPayOptions.BaseUrl + request.RequestUrl;
        }
    }
}
