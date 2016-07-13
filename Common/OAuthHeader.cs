using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Tweets10.Common
{
    public static class OAuthHeader
    {
        private static readonly string _signingMethod = "HMAC-SHA1";
        public static string GenerateOAuthHeader(string url, string consumerKey, string consumerSecret)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            string oauthtimestamp = Convert.ToInt64(ts.TotalSeconds).ToString();
            string nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));

            var baseString = GenerateBaseString(consumerKey, url, nonce, oauthtimestamp);
            var oauthSignature = GenerateSignature(baseString, consumerSecret);

            var oauthHeaderBuilder = new StringBuilder();

            oauthHeaderBuilder.Append("oauth_consumer_key=" + "\"" + Uri.EscapeDataString(consumerKey) + "\",");
            oauthHeaderBuilder.Append("oauth_nonce=" + "\"" + Uri.EscapeDataString(nonce) + "\",");
            oauthHeaderBuilder.Append("oauth_timestamp=" + "\"" + Uri.EscapeDataString(oauthtimestamp) + "\",");
            oauthHeaderBuilder.Append("oauth_signature_method=" + "\"" + Uri.EscapeDataString(_signingMethod) + "\",");
            oauthHeaderBuilder.Append("oauth_version=" + "\"" + Uri.EscapeDataString("1.0") + "\",");
            oauthHeaderBuilder.Append("oauth_signature=" + "\"" + Uri.EscapeDataString(oauthSignature) + "\"");

            return oauthHeaderBuilder.ToString();

        }
        private static string GenerateSignature(string baseString, string consumerSecret)
        {
            var signatureKey = string.Format("{0}&{1}", consumerSecret, "");
            var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(signatureKey));

            var oauthsignature = Convert.ToBase64String(hmac.ComputeHash(new ASCIIEncoding().GetBytes(baseString)));

            return oauthsignature;
        }

        private static string GenerateBaseString(string consumerKey, string url, string nonce, string timestamp)
        {
            var parameters = new SortedDictionary<string, string>
            {
                {"oauth_consumer_key", consumerKey},
                {"oauth_signature_method", _signingMethod},
                {"oauth_timestamp", timestamp},
                {"oauth_nonce", nonce},
                {"oauth_version", "1.0"}
            };

            string[] queryParams = url.Split('?')[1].Split('=', '&');
            for (int i = 0; i < queryParams.Length; i += 2)
            {
                parameters.Add(queryParams[i], queryParams[i + 1]);
            }

            var baseString = new StringBuilder();
            baseString.Append("GET");
            baseString.Append("&" + Uri.EscapeDataString(url.Split('?')[0]));
            baseString.Append("&" + Uri.EscapeDataString(NormalizeParameters(parameters)));

            return baseString.ToString();

        }

        private static string NormalizeParameters(SortedDictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();

            var i = 0;
            foreach (var parameter in parameters)
            {
                if (i > 0)
                    sb.Append("&");
                sb.AppendFormat("{0}={1}", parameter.Key, parameter.Value);
                i++;
            }
            return sb.ToString();
        }

    }
}
