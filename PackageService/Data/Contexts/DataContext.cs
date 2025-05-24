using Microsoft.EntityFrameworkCore;
using PackageService.Entities;

namespace PackageService.Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<PackageEntity> Packages { get; set; }
    }
}
