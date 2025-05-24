using System.Linq.Expressions;
using PackageService.Entities;
using PackageService.Models;

namespace PackageService.Interfaces
{
    public interface IPackageRepository
    {
        Task<RepositoryResult> AddAsync(PackageEntity entity);
        Task<RepositoryResult<IEnumerable<PackageEntity>>> GetAllAsync();
        Task<RepositoryResult<PackageEntity?>> GetAsync(
            Expression<Func<PackageEntity, bool>> expression
        );
        Task<RepositoryResult<IEnumerable<PackageEntity>>> GetByEventIdAsync(string eventId);
    }
}
