using InfoPortal.Application.Contracts.Logic.Services.BaseEntity.Models;
using InfoPortal.Application.Contracts.Logic.Services.Tags.Models;

namespace InfoPortal.Application.Contracts.Logic.Services.News.Models
{
    public class NewsDto : BaseEntityDto
    {
        public string Header { get; set; } = null!;
        public string Text { get; set; } = null!;
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
