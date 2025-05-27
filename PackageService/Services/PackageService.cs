using PackageService.Entities;
using PackageService.Interfaces;
using PackageService.Models;

namespace PackageService.Services
{
    public class PackageService(IPackageRepository packageRepository) : IPackageService
    {
        private readonly IPackageRepository _packageRepository = packageRepository;

        public async Task<PackageResult> CreatePackageAsync(CreatePackageRequest request)
        {
            try
            {
                var packageEntity = new PackageEntity
                {
                    EventId = request.EventId,
                    PackageName = request.PackageName,
                    Description = request.Description,
                    Price = request.Price,
                    Type = request.Type,
                };
                var result = await _packageRepository.AddAsync(packageEntity);
                return result.Success
                    ? new PackageResult { Success = true }
                    : new PackageResult { Success = false, Error = result.Error };
            }
            catch (Exception ex)
            {
                return new PackageResult { Success = false, Error = ex.Message };
            }
        }

        public async Task<PackageResult<IEnumerable<Package>>> GetPackagesAsync()
        {
            var result = await _packageRepository.GetAllAsync();
            var packages = result.Result?.Select(x => new Package
            {
                EventId = x.EventId,
                Id = x.Id,
                PackageName = x.PackageName,
                Description = x.Description,
                Price = x.Price,
                Type = x.Type,
            });

            return new PackageResult<IEnumerable<Package>> { Success = true, Result = packages };
        }

        public async Task<PackageResult<Package?>> GetPackageAsync(string packageId)
        {
            var result = await _packageRepository.GetAsync(x => x.Id == packageId);
            if (result.Success && result.Result != null)
            {
                var currentPackage = new Package
                {
                    EventId = result.Result.EventId,
                    Id = result.Result.Id,
                    PackageName = result.Result.PackageName,
                    Description = result.Result.Description,
                    Price = result.Result.Price,
                    Type = result.Result.Type,
                };

                return new PackageResult<Package?> { Success = true, Result = currentPackage };
            }
            return new PackageResult<Package?> { Success = false, Error = "Package not found" };
        }

        public async Task<PackageResult<IEnumerable<Package>>> GetPackagesByEventAsync(
            string eventId
        )
        {
            var result = await _packageRepository.GetByEventIdAsync(eventId);
            var packages = result.Result?.Select(x => new Package
            {
                EventId = x.EventId,
                Id = x.Id,
                PackageName = x.PackageName,
                Description = x.Description,
                Price = x.Price,
                Type = x.Type,
            });

            return new PackageResult<IEnumerable<Package>> { Success = true, Result = packages };
        }
    }
}
