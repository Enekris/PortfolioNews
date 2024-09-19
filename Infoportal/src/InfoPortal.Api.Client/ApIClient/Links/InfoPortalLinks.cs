namespace InfoPortal.Api.Client.ApIClient.Links
{
    public static class InfoPortalLinks
    {
        private static string baseUrl;

        public static void Initialize(string BaseUrl)
        {
            if (string.IsNullOrEmpty(BaseUrl))
            {
                throw new InvalidOperationException("Base URL has not been initialized.");
            }
            baseUrl = BaseUrl;
        }

        private static string newsName => "/News";
        private static string tagsName => "/Tag";
        private static string create => "/Create";
        private static string update => "/Update";
        private static string delete => "/delete";
        private static string getAll => "/get-all";
        private static string getModel => "/get";

        private static string getAllSortedNews => "/get-all-sorted";

        public static string CreateTag => baseUrl + tagsName + create;
        public static string CreateNews => baseUrl + newsName + create;
        public static string UpdateTag => baseUrl + tagsName + update;
        public static string UpdateNews => baseUrl + newsName + update;
        public static string DeleteTag(Guid id) => baseUrl + tagsName + delete+$"/{id}";
        public static string DeleteNews(Guid id) => baseUrl + newsName + delete + $"/{id}";
        public static string GetTag(Guid id) => baseUrl + tagsName + getModel + $"/{id}";
        public static string GetNews(Guid id) => baseUrl + newsName + getModel + $"/{id}";
        public static string GetAllTags => baseUrl + tagsName + getAll;
        public static string GetAllNews => baseUrl + newsName + getAll;
        public static string GetAllSortedNews => baseUrl + newsName + getAllSortedNews;

    }
}
