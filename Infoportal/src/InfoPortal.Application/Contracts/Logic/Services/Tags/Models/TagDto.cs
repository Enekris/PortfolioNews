using InfoPortal.Application.Contracts.Logic.Services.BaseEntity.Models;
using InfoPortal.Application.Contracts.Logic.Services.News.Models;

namespace InfoPortal.Application.Contracts.Logic.Services.Tags.Models
{
    public class TagDto : BaseEntityDto
    {
        public string Name { get; set; } = null!;
        public List<NewsDto> News { get; set; } = new List<NewsDto>();
    }
}
