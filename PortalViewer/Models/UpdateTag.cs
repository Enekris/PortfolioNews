using System.ComponentModel.DataAnnotations;

namespace InfoPortalWpf.Models
{
    public class UpdateTag
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

    }
}
