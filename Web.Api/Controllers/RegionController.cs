using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Repositories;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        public IRegionRepository _regionRepository { get; }
        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }


        [HttpGet]
        public IActionResult GetAllRegion()
        {
            var regions = _regionRepository.GetAll();
            return Ok(regions);
        }
    }
}
