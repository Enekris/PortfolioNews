using InfoPortal.Api.Client.ApIClient.Interfaces;
using InfoPortal.Api.Client.ApIClient.Links;
using InfoPortal.Api.Client.Exceptions;
using InfoPortal.Api.Client.Exceptions;
using InfoPortal.Api.Client.Settings;
using InfoPortal.Api.Models.Request;
using InfoPortal.Api.Models.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;

namespace InfoPortal.Api.Client.ApIClient
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ApiClientSettings apiClientSettings;

        internal ApiClient(HttpClient httpClient, IOptionsMonitor<ApiClientSettings> optionsMonitor)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            apiClientSettings = optionsMonitor.CurrentValue;
            var baseUrl = apiClientSettings.BaseAddress;
            InfoPortalLinks.Initialize(baseUrl);
        }

        internal async Task PostResponseWithJsonModel<T>(string url, T model)
        {
            string jsonCreateTagsModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonCreateTagsModel,
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync(url, content);
            await HandleResponseAsync(response);
        }

        private static async Task HandleResponseAsync(HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch
            {
                var msg = await response.Content.ReadAsStringAsync();
                var ex = JsonConvert.DeserializeObject<ErrorModel>(msg);
                throw new ApiClientException(ex);
            }
        }

        internal async Task DeleteResponse(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            await HandleResponseAsync(response);
        }

        internal async Task<T> GetResponse<T>(string url, T model)
        {
            var responce = await _httpClient.GetAsync(url);
            await HandleResponseAsync(responce);

            string responseContent = await responce.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<T>(responseContent);
            return responseModel;
        }
    }
}
