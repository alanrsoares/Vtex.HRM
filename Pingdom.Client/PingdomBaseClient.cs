using System.Threading.Tasks;
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

        public Task<string> GetAsync(string apiMethod)
        {
            return _baseClient.GetStringAsync(apiMethod);
        }

        public async Task<string> PostAsync(string apiMethod, object data)
        {
            var response = await _baseClient.PostAsJsonAsync(apiMethod, data);

            var responseContent = response.Content;

            return await responseContent.ReadAsStringAsync();
        }

        public Task<string> PutAsync(string apiMethod, object data)
        {
            return SendAsync(apiMethod, data, HttpMethod.Put);
        }

        public async Task<JsonStringResult> DeleteAsync(string apiMethod)
        {
            var response = await SendAsync(apiMethod, HttpMethod.Delete);
            return new JsonStringResult(response);
        }

        public async Task<JsonStringResult> DeleteAsync(string apiMethod, object data)
        {
            var response = await SendAsync(apiMethod, data, HttpMethod.Delete);
            return new JsonStringResult(response);
        }

        #endregion

        #region Private Methods

        private Task<string> SendAsync(string apiMethod, HttpMethod httpMethod)
        {
            return SendAsync(apiMethod, null, httpMethod);
        }

        private async Task<string> SendAsync(string apiMethod, object data, HttpMethod httpMethod)
        {
            var request = new HttpRequestMessage(httpMethod, apiMethod);

            if (data != null) request.Content = GetFormUrlEncodedContent(data);

            var response = await _baseClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
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