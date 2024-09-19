namespace InfoPortal.Domains.Entities
{
    public class TagDb : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<NewsDb> News { get; set; } = new List<NewsDb>();
    }
}
