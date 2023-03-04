namespace API.Domain.Settings
{
    public class AppSettings
    { 
        public ApplicationDetail? ApplicationDetail { get; set; }
    }
    public class ApplicationDetail
    {
        public string? ApplicationName { get; set; }
        public string? Description { get; set; }
        public string? ContactWebsite { get; set; }
        public string? LicenseDetail { get; set; }
    }
}
