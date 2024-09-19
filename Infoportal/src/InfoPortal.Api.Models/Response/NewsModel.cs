namespace InfoPortal.Api.Models.Response
{
    public class NewsModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Header { get; set; } = null!;
        public string Text { get; set; } = null!;
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
    }
}
