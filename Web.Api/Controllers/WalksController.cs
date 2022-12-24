using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models.DTO;
using Web.Api.Repositories;

namespace Web.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkAsync()
        {
            var walks = await walkRepository.GetAllAsync();
            var walksDto = mapper.Map<List<WalkDto>>(walks);
            return Ok(walksDto);
        }
    }
}
