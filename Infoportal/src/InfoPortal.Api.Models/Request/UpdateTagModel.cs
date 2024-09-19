using System.ComponentModel.DataAnnotations;

namespace InfoPortal.Api.Models.Request
{
    public class UpdateTagModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

    }
}
