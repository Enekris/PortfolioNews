using System.ComponentModel.DataAnnotations;

namespace InfoPortalWpf.Models
{
    public class CreateTag
    {
        [Required]
        public string Name { get; set; } = null!;

    }
}
