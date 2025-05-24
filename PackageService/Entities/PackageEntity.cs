using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackageService.Entities
{
    public class PackageEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string EventId { get; set; } = null!;
        public string PackageName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;
        public string Type { get; set; } = null!;
    }
}
