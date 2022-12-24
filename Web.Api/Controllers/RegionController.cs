using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models.DTO;
using Web.Api.Repositories;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        public IRegionRepository _regionRepository { get; }
        public IMapper Mapper { get; }

        public RegionController(IRegionRepository regionRepository,IMapper mapper)
        {
            _regionRepository = regionRepository;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
            var regions = await _regionRepository.GetAllAsync();
            // AutoMapper
            var regionDto = Mapper.Map<List<RegionDto>>(regions);
            return Ok(regionDto);
        }
    }
}
