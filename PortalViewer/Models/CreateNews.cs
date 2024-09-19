using System.ComponentModel.DataAnnotations;

namespace InfoPortalWpf.Models
{
    public class CreateNews
    {
        [Required]
        public string Header { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;

        public List<Guid?>? TagsId { get; set; } = [];
    }
}
