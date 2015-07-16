﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using RestSharp;
using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.Methods
{
    internal static class AmoMethod
    {
        private static CookieContainer _cookies;
        private static DateTime _lastSessionStarted;
        private const int AuthSessionLimit = 15;


        /*internal static T RestPost<T>(string url, string data, AmoCrmConfig crmConfig) where T : class
        {
            var restClient = new RestClient();
        }*/

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
            url += "&limit_rows=" + (crmConfig.LimitRows ?? 500);
            url += "&limit_offset=" + (crmConfig.LimitOffset ?? 0);

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