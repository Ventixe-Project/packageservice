using PackageService.Models;

namespace PackageService.Services
{
    public interface IPackageService
    {
        Task<PackageResult> CreatePackageAsync(CreatePackageRequest request);
        Task<PackageResult<Package?>> GetPackageAsync(string packageId);
        Task<PackageResult<IEnumerable<Package>>> GetPackagesAsync();
    }
}
