using Microsoft.AspNetCore.Mvc;
using PackageService.Models;
using PackageService.Services;

namespace PackageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController(IPackageService packageService) : ControllerBase
    {
        private readonly IPackageService _packageService = packageService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? eventId)
        {
            if (!string.IsNullOrEmpty(eventId))
            {
                var packages = await _packageService.GetPackagesByEventAsync(eventId);
                return Ok(packages);
            }
            var allPackages = await _packageService.GetPackagesAsync();
            return Ok(allPackages);
        }

        [HttpGet("{packageId}")]
        public async Task<IActionResult> Get(string packageId)
        {
            var currentPackage = await _packageService.GetPackageAsync(packageId);
            return currentPackage != null ? Ok(currentPackage) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePackageRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _packageService.CreatePackageAsync(request);
            return result.Success ? Ok() : StatusCode(500, result.Error);
        }
    }
}
