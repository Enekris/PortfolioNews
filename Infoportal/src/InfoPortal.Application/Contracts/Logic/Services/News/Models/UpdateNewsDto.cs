namespace InfoPortal.Application.Contracts.Logic.Services.News.Models
{
    public class UpdateNewsDto
    {
        public Guid Id { get; set; }
        public string Header { get; set; } = null!;
        public string Text { get; set; } = null!;
        public List<Guid> TagsId { get; set; } = new List<Guid>();
    }
}
