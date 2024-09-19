namespace InfoPortal.Api.Models.Response
{
    public class TagModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; } = null!;
        // public List<TagsApi> Tags { get; set; } = new List<TagsApi>();
    }
}
