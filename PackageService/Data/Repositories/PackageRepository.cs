using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PackageService.Data.Contexts;
using PackageService.Entities;
using PackageService.Interfaces;
using PackageService.Models;

namespace PackageService.Data.Repositories
{
    public class PackageRepository(DataContext context)
        : BaseRepository<PackageEntity>(context),
            IPackageRepository
    {
        // Create
        public override async Task<RepositoryResult> AddAsync(PackageEntity entity)
        {
            try
            {
                await _table.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new RepositoryResult { Success = true };
            }
            catch (Exception ex)
            {
                return new RepositoryResult { Success = false, Error = ex.Message };
            }
        }

        // Read
        public override async Task<RepositoryResult<IEnumerable<PackageEntity>>> GetAllAsync()
        {
            try
            {
                var entities = await _table.ToListAsync();
                return new RepositoryResult<IEnumerable<PackageEntity>>
                {
                    Success = true,
                    Result = entities,
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<IEnumerable<PackageEntity>>
                {
                    Success = false,
                    Error = ex.Message,
                };
            }
        }

        public override async Task<RepositoryResult<PackageEntity?>> GetAsync(
            Expression<Func<PackageEntity, bool>> expression
        )
        {
            try
            {
                var entity = await _table.FirstOrDefaultAsync(expression);
                return new RepositoryResult<PackageEntity?> { Success = true, Result = entity };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<PackageEntity?> { Success = false, Error = ex.Message };
            }
        }

        public async Task<RepositoryResult<IEnumerable<PackageEntity>>> GetByEventIdAsync(
            string eventId
        )
        {
            try
            {
                var entities = await _table.Where(x => x.EventId == eventId).ToListAsync();
                return new RepositoryResult<IEnumerable<PackageEntity>>
                {
                    Success = true,
                    Result = entities,
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<IEnumerable<PackageEntity>>
                {
                    Success = false,
                    Error = ex.Message,
                };
            }
        }

        // Update
    }
}
