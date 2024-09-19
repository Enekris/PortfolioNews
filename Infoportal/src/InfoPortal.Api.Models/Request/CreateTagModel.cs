using System.ComponentModel.DataAnnotations;

namespace InfoPortal.Api.Models.Request
{
    public class CreateTagModel
    {
        [Required]
        public string Name { get; set; } = null!;

    }
}
