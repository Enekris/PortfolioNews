namespace InfoPortal.Api.Models.Response
{
    public class ErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? ErrorLog { get; set; }
        public int StatusCode { get; set; }

    }
}
