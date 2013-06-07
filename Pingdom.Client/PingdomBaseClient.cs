using System.Web;

namespace Pingdom.Client
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Collections.Generic;

    public class PingdomBaseClient
    {
        private readonly HttpClient _baseClient;

        private readonly string _baseAddress;

        private readonly PingdomClientConfiguration _configuration;

        public PingdomBaseClient()
        {
            _configuration = new PingdomClientConfiguration();

            _baseAddress = string.Format(_configuration.BaseAddress, _configuration.Version);

            var credentials = new CredentialCache
                {
                    {
                        new Uri(_baseAddress), "basic", new NetworkCredential(_configuration.UserName, _configuration.Password)
                    }
                };

            var requestHandler = new WebRequestHandler { Credentials = credentials };

            _baseClient = new HttpClient(requestHandler) { BaseAddress = new Uri(_baseAddress) };
            _baseClient.DefaultRequestHeaders.Add("app-key", _configuration.AppKey);
        }

        #region Rest Methods
        
        public JsonStringResult Get(string apiMethod)
        {
            return new JsonStringResult(_baseClient.GetStringAsync(apiMethod).Result);
        }

        public JsonStringResult Post(string apiMethod, object data)
        {
            var response = _baseClient.PostAsJsonAsync(apiMethod, data);
            var responseContent = response.Result.Content;
            var contentString = responseContent.ReadAsStringAsync().Result;

            return new JsonStringResult(contentString);
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

        private dynamic UploadString(string apiMethod, HttpMethod httpMethod)
        {
            return UploadString(apiMethod, null, httpMethod);
        }

        private dynamic UploadString(string apiMethod, object data, HttpMethod httpMethod)
        {
            var request = new HttpRequestMessage(httpMethod, apiMethod);

            if (data != null) request.Content = GetFormUrlEncodedContent(data);

            var response = _baseClient.SendAsync(request);

            return response.Result.Content.ReadAsStringAsync();
        }

        private static FormUrlEncodedContent GetFormUrlEncodedContent(object anonymousObject)
        {
            var properties = from propertyInfo in anonymousObject.GetType().GetProperties()
                             where propertyInfo.GetValue(anonymousObject, null) != null
                             select new KeyValuePair<string, string>(propertyInfo.Name, HttpUtility.UrlEncode(propertyInfo.GetValue(anonymousObject, null).ToString()));

            return new FormUrlEncodedContent(properties);
        }

        #endregion

    }
}