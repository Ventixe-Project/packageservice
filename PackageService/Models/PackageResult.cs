namespace PackageService.Models
{
    public class PackageResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
    }

    public class PackageResult<T> : PackageResult
    {
        public T? Result { get; set; }
    }
}
