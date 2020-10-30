using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OmniPay.Core.Utils
{
    public class Cert
    {
        public AsymmetricKeyParameter key;
        public X509Certificate cert;
        public string certId;
    }

    public class CertUtil
    {
        private static Dictionary<string, Cert> signCerts = new Dictionary<string, Cert>();


        private static void initSignCert(string certPath, string certPwd)
        {

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(certPath, FileMode.Open, FileAccess.Read);

                Pkcs12Store store = new Pkcs12Store(fileStream, certPwd.ToCharArray());

                string pName = null;
                foreach (string n in store.Aliases)
                {
                    if (store.IsKeyEntry(n))
                    {
                        pName = n;
                        //break;
                    }
                }

                Cert signCert = new Cert();
                signCert.key = store.GetKey(pName).Key;
                X509CertificateEntry[] chain = store.GetCertificateChain(pName);
                signCert.cert = chain[0].Certificate;
                signCert.certId = signCert.cert.SerialNumber.ToString();
          
                signCerts[certPath] = signCert;

            }
            catch (Exception e)
            {
                //_logger.LogError("签名证书读取失败，异常：" + e);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

        }

        /// <summary>
        /// 获取签名证书的证书序列号
        /// </summary>
        /// <returns></returns>
        public static string GetSignCertId(string certPath, string certPwd)
        {
            if (!signCerts.ContainsKey(certPath))
            {
                initSignCert(certPath, certPwd);
            }
            return signCerts[certPath].certId;
        }

    }
}
