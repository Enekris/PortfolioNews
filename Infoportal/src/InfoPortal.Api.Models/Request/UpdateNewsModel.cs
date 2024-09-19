using System.ComponentModel.DataAnnotations;

namespace InfoPortal.Api.Models.Request
{
    public class UpdateNewsModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Header { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;
        public List<Guid> TagsId { get; set; } = new List<Guid>();
    }
}
