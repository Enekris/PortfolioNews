using InfoPortal.Api.Models.Request;
using InfoPortal.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPortal.Api.Client.ApIClient.Interfaces
{
    public interface IApiNewsClient
    {
        public Task<List<NewsModel>> GetAllNewsAsync();
        public Task<List<NewsModel>> GetAllSortedAsync();
        public Task<NewsModel> GetNewsAsync(Guid id);
        public Task CreateAsync(CreateNewsModel createNewsModel);
        public Task Update(UpdateNewsModel updateNewsModel);
        public Task DeleteNewsAsync(Guid id);
    }
}
