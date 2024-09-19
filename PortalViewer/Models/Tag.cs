namespace InfoPortalWpf.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; } = null!;
    }
}
