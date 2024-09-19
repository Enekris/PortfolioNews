using InfoPortal.Api.Client.ApIClient.Interfaces;
using InfoPortal.Api.Models.Request;
using InfoPortal.Application.Contracts.Logic.Services.News;
using InfoPortal.Application.Contracts.Logic.Services.Tags;

namespace InfoPortal.TestConsole
{
    internal class Startup
    {
        private readonly IApiTagClient _apiTagClient;
        private readonly IApiNewsClient _apiNewsClient;
        private readonly ITagsService _tagsService;

        public Startup(IApiTagClient apiTagClient, IApiNewsClient apiNewsClient)
        {
            _apiTagClient = apiTagClient;
            _apiNewsClient = apiNewsClient;
        }

        public async Task StartAsync()
        {

        //    var tags = await _apiClient.GetAllTagsAsync();
            await _apiTagClient.GetAllTagsAsync();
            await _apiNewsClient.CreateAsync(new CreateNewsModel()
            {
                Header = "Новость1819"

            });

        }
    }
}
