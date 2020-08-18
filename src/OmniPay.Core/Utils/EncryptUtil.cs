using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OmniPay.Core.Utils
{
    /// <summary>
    ///     加密工具类
    /// </summary>
    public static class EncryptUtil
    {
        public static string RSA(string data, string privateKey, string signType)
        {
            return RSA(data, privateKey, "UTF-8", signType, false);
        }


        private static string RSA(string data, string privateKeyPem, string charset, string signType, bool keyFromFile)
        {
            byte[] signatureBytes = null;
            try
            {
                RSA rsaCsp = null;
                if (keyFromFile)
                {
                    //文件读取
                    rsaCsp = LoadCertificateFile(privateKeyPem, signType);
                }
                else
                {
                    //字符串获取
                    rsaCsp = LoadCertificateString(privateKeyPem, signType);
                }

                byte[] dataBytes = null;

                if (string.IsNullOrEmpty(charset))
                {
                    dataBytes = Encoding.UTF8.GetBytes(data);
                }
                else
                {
                    dataBytes = Encoding.GetEncoding(charset).GetBytes(data);
                }

                if (null == rsaCsp)
                {
                    throw new Exception("您使用的私钥格式错误，请检查RSA私钥配置" + ",charset = " + charset);
                }

                if ("RSA2".Equals(signType))
                {
                    signatureBytes = rsaCsp.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                }
                else
                {
                    signatureBytes = rsaCsp.SignData(dataBytes, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
                }
            }
            catch
            {
                throw new Exception("您使用的私钥格式错误，请检查RSA私钥配置" + ",charset = " + charset);
            }

            return Convert.ToBase64String(signatureBytes);
        }
        private static RSA LoadCertificateFile(string filename, string signType)
        {
            using var fs = File.OpenRead(filename);
            var data = new byte[fs.Length];
            byte[] res = null;
            fs.Read(data, 0, data.Length);
            if (data[0] != 0x30)
            {
                res = GetPem("RSA PRIVATE KEY", data);
            }
            try
            {
                return DecodeRSAPrivateKey(res, signType);
            }
            catch
            {
                return null;
            }
        }

        private static RSA LoadCertificateString(string strKey, string signType)
        {
            var data = Convert.FromBase64String(strKey);
            try
            {
                return DecodeRSAPrivateKey(data, signType);
            }
            catch
            {
                return null;
            }
        }

        private static RSA DecodeRSAPrivateKey(byte[] privkey, string signType)
        {
            byte[] modulus, e, d, p, q, dP, dQ, iQ;
            var mem = new MemoryStream(privkey);
            var binr = new BinaryReader(mem);
            try
            {
                var twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                {
                    binr.ReadByte();
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16();
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)
                {
                    return null;
                }

                var bt = binr.ReadByte();
                if (bt != 0x00)
                {
                    return null;
                }

                var elems = GetIntegerSize(binr);
                modulus = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                e = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                d = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                p = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                dP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                dQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                iQ = binr.ReadBytes(elems);

                var bitLen = 1024;
                if ("RSA2".Equals(signType))
                {
                    bitLen = 2048;
                }

                var rsa = System.Security.Cryptography.RSA.Create();
                rsa.KeySize = bitLen;
                var rsaParams = new RSAParameters
                {
                    Modulus = modulus,
                    Exponent = e,
                    D = d,
                    P = p,
                    Q = q,
                    DP = dP,
                    DQ = dQ,
                    InverseQ = iQ
                };
                rsa.ImportParameters(rsaParams);
                return rsa;
            }
            catch
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private static byte[] GetPem(string type, byte[] data)
        {
            var pem = Encoding.UTF8.GetString(data);
            var header = $"-----BEGIN {type}-----\\n";
            var footer = $"-----END {type}-----";
            var start = pem.IndexOf(header) + header.Length;
            var end = pem.IndexOf(footer, start);
            var base64 = pem.Substring(start, end - start);

            return Convert.FromBase64String(base64);
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            var bt = binr.ReadByte();
            if (bt != 0x02)
            {
                return 0;
            }

            bt = binr.ReadByte();

            int count;
            if (bt == 0x81)
            {
                count = binr.ReadByte();
            }
            else if (bt == 0x82)
            {
                var highbyte = binr.ReadByte();
                var lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }

    }
}
