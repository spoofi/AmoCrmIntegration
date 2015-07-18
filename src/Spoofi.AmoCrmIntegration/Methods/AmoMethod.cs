using System;
using System.IO;
using System.Net;
using System.Text;
using RestSharp;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.Methods
{
    internal static class AmoMethod
    {
        private static CookieContainer _cookies;
        private static DateTime _lastSessionStarted;
        private const int AuthSessionLimit = 15;

        internal static T Post<T>(string url, string data, AmoCrmConfig crmConfig) where T : class, IAmoCrmResponse, new()
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

        internal static T Get<T>(AmoCrmConfig crmConfig, params Parameter[] parameters) where T : class, IAmoCrmResponse, new()
        {
            var client = new RestClient(crmConfig.GetUrl<T>())
            {
                CookieContainer = GetCookies(crmConfig)
            };

            var request = new RestRequest(Method.GET);
            request.AddParameter("limit_rows", crmConfig.LimitRows ?? 500);
            request.AddParameter("limit_offset", crmConfig.LimitOffset ?? 0);
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }
            if (crmConfig.ModifiedSince.HasValue)
                request.AddHeader("If-Modified-Since", crmConfig.ModifiedSince.Value.ToString("u"));

            var response = client.Execute(request);
            if (response.ErrorException != null)
                throw new AmoCrmException(response.ErrorMessage, response.ErrorException);
            return response.Content.DeserializeTo<T>();
        }

        private static CookieContainer GetCookies(AmoCrmConfig crmConfig)
        {
            var sessionLimitIsExceeded = DateTime.Now - new TimeSpan(0, 0, AuthSessionLimit, 0) > _lastSessionStarted;
            if (_cookies == null || sessionLimitIsExceeded) _cookies = GetNewCookies(crmConfig);
            return _cookies;
        }

        private static CookieContainer GetNewCookies(AmoCrmConfig crmConfig)
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("USER_LOGIN", crmConfig.UserLogin);
            request.AddParameter("USER_HASH", crmConfig.UserHash);

            var response = new RestClient(crmConfig.AuthUrl).Execute(request);

            var newCookieContainer = new CookieContainer();
            foreach (var cookie in response.Cookies)
            {
                newCookieContainer.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            }

            _lastSessionStarted = DateTime.Now;
            return newCookieContainer;
        }
    }
}