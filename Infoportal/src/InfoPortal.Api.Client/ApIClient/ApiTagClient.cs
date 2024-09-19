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
    public class ApiTagClient : ApiClient, IApiTagClient
    {
        public ApiTagClient(HttpClient httpClient, IOptionsMonitor<ApiClientSettings> optionsMonitor) : base(httpClient, optionsMonitor)
        {
        }

        public async Task CreateAsync(CreateTagModel createTagModel)
        {
            var url = InfoPortalLinks.CreateTag;
            await PostResponseWithJsonModel(url, createTagModel);
        }

        public async Task Update(UpdateTagModel updateTagModel)
        {
            var url = InfoPortalLinks.UpdateTag;
            await PostResponseWithJsonModel(url, updateTagModel);
        }

        public async Task DeleteTagsAsync(Guid id)
        {
            var url = InfoPortalLinks.DeleteTag(id);
            await DeleteResponse(url);
        }

        public async Task<List<TagModel>> GetAllTagsAsync()
        {
            var url = InfoPortalLinks.GetAllTags;
            return await GetResponse(url, new List<TagModel>());
        }

        public async Task<TagModel> GetTagsAsync(Guid id)
        {
            var url = InfoPortalLinks.GetTag(id);
            return await GetResponse(url,new TagModel());
        }

    }
}
