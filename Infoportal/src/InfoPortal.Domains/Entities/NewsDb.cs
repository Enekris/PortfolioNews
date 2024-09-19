namespace InfoPortal.Domains.Entities
{
    public class NewsDb : BaseEntity
    {
        public string Header { get; set; } = null!;
        public string Text { get; set; } = null!;
        public List<TagDb> Tags { get; set; } = new List<TagDb>();
    }
}
