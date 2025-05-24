namespace PackageService.Models
{
    public class CreatePackageRequest
    {
        public string EventId { get; set; } = null!;
        public string PackageName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public string Type { get; set; } = null!;
    }
}
