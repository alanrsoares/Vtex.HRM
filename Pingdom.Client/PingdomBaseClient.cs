namespace Pingdom.Client
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using Controllers;

    public class PingdomBaseClient
    {
        private readonly WebClient _baseWebClient;

        private readonly string _baseUrl;

        private readonly PingdomClientConfiguration _configuration;

        public PingdomBaseClient()
        {
            _configuration = new PingdomClientConfiguration();

            _baseUrl = string.Format(_configuration.BaseUrl, _configuration.Version);

            _baseWebClient = new WebClient
                              {
                                  Credentials = new NetworkCredential(_configuration.UserName, _configuration.Password),
                                  Headers = new WebHeaderCollection
                                                {
                                                    { "app-key", _configuration.AppKey },
                                                    { HttpRequestHeader.ContentType, "application/x-www-form-urlencoded" }
                                                },
                              };
        }

        #region Rest Methods
        public JsonStringResult Get(string apiMethod)
        {
            return new JsonStringResult(_baseWebClient.DownloadString(GetUri(apiMethod)));
        }

        public JsonStringResult Post(string apiMethod, object data)
        {
            return new JsonStringResult(UploadString(apiMethod, data, HttpMethod.Post));
        }

        public JsonStringResult Put(string apiMethod, object data)
        {
            return new JsonStringResult(UploadString(apiMethod, data, HttpMethod.Put));
        }

        public JsonStringResult Delete(string apiMethod)
        {
            return new JsonStringResult(UploadString(apiMethod, HttpMethod.Delete));
        }

        public JsonStringResult Delete(string apiMethod, object data)
        {
            return new JsonStringResult(UploadString(apiMethod, data, HttpMethod.Delete));
        }
        #endregion

        #region Private Methods

        private Uri GetUri(string apiMethod)
        {
            return new Uri(string.Concat(_baseUrl, apiMethod));
        }

        private dynamic UploadString(string apiMethod, HttpMethod httpMethod)
        {
            return UploadString(apiMethod, null, httpMethod);
        }

        private dynamic UploadString(string apiMethod, object data, HttpMethod httpMethod)
        {
            var uri = GetUri(apiMethod);

            if (data == null)
                return _baseWebClient.UploadString(uri, httpMethod.ToString());

            var serializedData = GetQueryString(data);

            return _baseWebClient.UploadString(uri, httpMethod.ToString(), serializedData);
        }

        private static string GetQueryString(object anonymousObject)
        {
            var properties = from propertyInfo in anonymousObject.GetType().GetProperties()
                             where propertyInfo.GetValue(anonymousObject, null) != null
                             select propertyInfo.Name + "=" + HttpUtility.UrlEncode(propertyInfo.GetValue(anonymousObject, null).ToString());

            return String.Join("&", properties.ToArray());
        }
        #endregion

    }
}