using InfoPortal.Api.Models.Request;
using InfoPortal.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPortal.Api.Client.ApIClient.Interfaces
{
    public interface IApiTagClient
    {
        public Task<List<TagModel>> GetAllTagsAsync();
        public Task<TagModel> GetTagsAsync(Guid id);
        public Task CreateAsync(CreateTagModel createTagModel);
        public Task Update(UpdateTagModel updateTagModel);
        public Task DeleteTagsAsync(Guid id);
    }
}
