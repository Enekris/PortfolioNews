using System.ComponentModel.DataAnnotations;

namespace InfoPortalWpf.Models
{
    public class UpdateNews
    {
        public Guid Id { get; set; }
        [Required]
        public string Header { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;
        public List<Guid> TagsId { get; set; } = [];
    }
}
