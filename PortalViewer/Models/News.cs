namespace InfoPortalWpf.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Header { get; set; } = null!;
        public string Text { get; set; } = null!;

        public List<Tag> Tags { get; set; } = [];
    }
}
