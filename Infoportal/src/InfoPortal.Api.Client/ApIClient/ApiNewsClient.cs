using InfoPortal.Api.Client.ApIClient.Interfaces;
using InfoPortal.Api.Client.ApIClient.Links;
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
    public class ApiNewsClient : ApiClient, IApiNewsClient
    {
        public ApiNewsClient(HttpClient httpClient, IOptionsMonitor<ApiClientSettings> optionsMonitor) : base(httpClient, optionsMonitor)
        {
        }

        public async Task CreateAsync(CreateNewsModel createNewsModel)
        {
            var url = InfoPortalLinks.CreateNews;
            await PostResponseWithJsonModel(url, createNewsModel);
        }

        public async Task Update(UpdateNewsModel updateNewsModel)
        {
            var url = InfoPortalLinks.UpdateNews;
            await PostResponseWithJsonModel(url, updateNewsModel);
        }

        public async Task DeleteNewsAsync(Guid id)
        {
            var url = InfoPortalLinks.DeleteNews(id);
            await DeleteResponse(url);
        }

        public async Task<List<NewsModel>> GetAllNewsAsync()
        {
            var url = InfoPortalLinks.GetAllNews;
            return await GetResponse(url, new List<NewsModel>());
        }

        public async Task<List<NewsModel>> GetAllSortedAsync()
        {
            var url = InfoPortalLinks.GetAllSortedNews;
            return await GetResponse(url, new List<NewsModel>());
        }

        public async Task<NewsModel> GetNewsAsync(Guid id)
        {
            var url = InfoPortalLinks.GetNews(id);
            return await GetResponse(url, new NewsModel());
        }

    }
}
