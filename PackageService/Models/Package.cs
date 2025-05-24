namespace PackageService.Models
{
    public class Package
    {
        public string Id { get; set; } = null!;
        public string EventId { get; set; } = null!;
        public string PackageName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Type { get; set; } = null!;
    }
}
