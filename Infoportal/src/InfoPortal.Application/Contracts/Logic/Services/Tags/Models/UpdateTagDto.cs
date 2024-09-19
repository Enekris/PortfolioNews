namespace InfoPortal.Application.Contracts.Logic.Services.Tags.Models
{
    public class UpdateTagDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Guid> NewsId { get; set; } = new List<Guid>();
    }
}
