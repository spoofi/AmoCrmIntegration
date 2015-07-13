using System;
using System.IO;
using System.Net;
using System.Text;
using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.Methods
{
    internal static class AmoMethod
    {
        private static CookieContainer _cookies;
        private static DateTime _lastSessionStarted;
        private const int AuthSessionLimit = 15;

        internal static T Post<T>(string url, string data, AmoCrmConfig crmConfig) where T : class
        {
            var request = (HttpWebRequest) WebRequest.Create(new Uri(url));
            request.Method = WebRequestMethods.Http.Post;
            request.KeepAlive = false;
            request.CookieContainer = GetCookies(crmConfig);

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                if (data != null) writer.Write(data);
            }

            using (var webResponse = (HttpWebResponse) request.GetResponse())
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream == null) throw new NullReferenceException("responseStream");
                    using (var responseReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        var responseResult = responseReader.ReadToEnd();
                        return responseResult.DeserializeTo<T>();
                    }
                }
            }
        }

        internal static T Get<T>(string url, AmoCrmConfig crmConfig) where T : class
        {
            if (crmConfig.LimitRows.HasValue) url += "&limit_rows=" + crmConfig.LimitRows;
            if (crmConfig.LimitOffset.HasValue) url += "&limit_offset=" + crmConfig.LimitOffset;

            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;

            if (crmConfig.ModifiedSince.HasValue) request.IfModifiedSince = crmConfig.ModifiedSince.Value;

            request.CookieContainer = GetCookies(crmConfig);
            request.KeepAlive = false;

            using (var webResponse = (HttpWebResponse) request.GetResponse())
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream == null) throw new NullReferenceException("responseStream");
                    using (var responseReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        var responseResult = responseReader.ReadToEnd();
                        return responseResult.DeserializeTo<T>();
                    }
                }
            }
        }

        private static CookieContainer GetCookies(AmoCrmConfig crmConfig)
        {
            var sessionLimitIsExceeded = DateTime.Now - new TimeSpan(0, 0, AuthSessionLimit, 0) > _lastSessionStarted;
            if (_cookies == null || sessionLimitIsExceeded) _cookies = GetNewCookies(crmConfig);
            return _cookies;
        }

        private static CookieContainer GetNewCookies(AmoCrmConfig crmConfig)
        {
            var postData = "USER_LOGIN=" + crmConfig.UserLogin + "&USER_HASH=" + crmConfig.UserHash;
            var request = (HttpWebRequest) WebRequest.Create(crmConfig.AuthUrl);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            var encodedPostParams = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = encodedPostParams.Length;
            request.GetRequestStream().Write(encodedPostParams, 0, encodedPostParams.Length);
            request.GetRequestStream().Close();

            request.CookieContainer = new CookieContainer();

            var response = (HttpWebResponse) request.GetResponse();

            var container = new CookieContainer();
            container.Add(response.Cookies);
            _lastSessionStarted = DateTime.Now;
            return container;
        }
    }
}