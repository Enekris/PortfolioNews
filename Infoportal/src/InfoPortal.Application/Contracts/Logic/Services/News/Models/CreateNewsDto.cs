namespace InfoPortal.Application.Contracts.Logic.Services.News.Models
{
    public class CreateNewsDto
    {
        public string Header { get; set; } = null!;
        public string Text { get; set; } = null!;
        public List<Guid> TagsId { get; set; } = new List<Guid>();
    }
}
