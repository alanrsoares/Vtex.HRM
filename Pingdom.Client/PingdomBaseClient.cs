using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Pingdom.Client
{
    public class PingdomBaseClient
    {
        private readonly WebClient _baseWebClient;

        private readonly string _baseUrl;

        public PingdomBaseClient()
        {
            var configuration = new
                                    {
                                        AppKey = GetConfigurationKey("AppKey"),
                                        Version = GetConfigurationKey("Version"),
                                        BaseUrl = GetConfigurationKey("BaseUrl"),
                                        UserName = GetConfigurationKey("UserName"),
                                        Password = GetConfigurationKey("Password"),
                                    };

            _baseUrl = string.Format(configuration.BaseUrl, configuration.Version);

            _baseWebClient = new WebClient
                              {
                                  Credentials = new NetworkCredential(configuration.UserName, configuration.Password),
                                  Headers = new WebHeaderCollection
                                                {
                                                    { "app-key", configuration.AppKey },
                                                    { HttpRequestHeader.ContentType, "application/x-www-form-urlencoded" }
                                                },
                              };
        }

        private Uri GetUri(string apiMethod)
        {
            return new Uri(_baseUrl + apiMethod);
        }

        private string GetConfigurationKey(string key)
        {
            return ConfigurationManager.AppSettings[string.Format("pingdomAPI:{0}", key)];
        }

        public dynamic Get(string apiMethod)
        {
            return _baseWebClient.DownloadString(GetUri(apiMethod));
        }

        public dynamic Post(string apiMethod, object data)
        {
            return UploadString(apiMethod, data, HttpMethod.Post);
        }

        public dynamic Put(string apiMethod, string data)
        {
            return UploadString(apiMethod, data, HttpMethod.Put);
        }

        public dynamic Delete(string apiMethod, string data)
        {
            return UploadString(apiMethod, data, HttpMethod.Delete);
        }

        private dynamic UploadString(string apiMethod, object data, HttpMethod httpMethod)
        {
            var serializedData = GetQueryString(data);
            var uri = GetUri(apiMethod);
            return _baseWebClient.UploadString(uri, httpMethod.ToString(), serializedData);
        }

        private string GetQueryString(object anonymousObject)
        {
            var properties = from propertyInfo in anonymousObject.GetType().GetProperties()
                             where propertyInfo.GetValue(anonymousObject, null) != null
                             select propertyInfo.Name + "=" + HttpUtility.UrlEncode(propertyInfo.GetValue(anonymousObject, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}