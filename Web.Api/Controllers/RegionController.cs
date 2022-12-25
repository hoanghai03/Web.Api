using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models.Domain;
using Web.Api.Models.DTO;
using Web.Api.Repositories;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        public IRegionRepository _regionRepository { get; }
        public IMapper Mapper { get; }

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _regionRepository.GetAllAsync();
            // AutoMapper
            var regionDto = Mapper.Map<List<RegionDto>>(regions);
            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }
            // AutoMapper
            var regionDto = Mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRgionRequest)
        {
            if(!ValidateAddRegionAsync(addRgionRequest))
            {
                return BadRequest(ModelState);
            }
            // Request to Domain model
            var region = new Region()
            {
                Area = addRgionRequest.Area,
                Code = addRgionRequest.Code,
                Lat = addRgionRequest.Lat,
                Long = addRgionRequest.Long,
                Name = addRgionRequest.Name,
                Population = addRgionRequest.Population
            };
            region = await _regionRepository.AddAsync(region);
            // convert region domain to regionDto
            var regionDto = Mapper.Map<RegionDto>(region);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.RegionId }, regionDto);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            var regionDto = Mapper.Map<RegionDto>(region);
            return Ok(region);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id,[FromBody]UpdateRegionRequest updateRegionRequest)
        {
            var region = new Region()
            {
                Code= updateRegionRequest.Code,
                Area= updateRegionRequest.Area,
                Lat= updateRegionRequest.Lat,
                Long= updateRegionRequest.Long,
                Name= updateRegionRequest.Name,
                Population= updateRegionRequest.Population
            };
            region = await _regionRepository.UpdateAsync(id, region);
            if(region == null)
            {
                return NotFound();
            }

            var regionDto = Mapper.Map<RegionDto>(region);
            return Ok(region);
        }

        #region method private
        private bool ValidateAddRegionAsync(AddRegionRequest addRgionRequest)
        {
            if(addRgionRequest == null)
            {
                ModelState.AddModelError(nameof(addRgionRequest), "dcm data required");
            }

            if (string.IsNullOrEmpty(addRgionRequest.Code))
            {
                ModelState.AddModelError(nameof(addRgionRequest.Code), $"{addRgionRequest.Code} cannot be null or empty or white space");
            }

            if (addRgionRequest.Long <=0)
            {
                ModelState.AddModelError(nameof(addRgionRequest.Long), $"{nameof(addRgionRequest.Long)} cannot be less than or equal to zero");
            }

            if(ModelState.ErrorCount> 0) {
                return false;
            }

            return true;
        }
        #endregion
    }
}
