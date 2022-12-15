using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supply_Chain_Portal.Repositories;

namespace Supply_Chain_Portal.Controllers
{
    [ApiController]
    [Route("WalkDifficulty")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {

            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        
        public async Task<IActionResult> getWalkDifficultyAsync()
        {
            var value = await walkDifficultyRepository.GetDifficultyAsync();

            //return DTO Models
            //var valuesDTO =new List<Models.DTO.WalkDifficulty>();
            //  value.ToList().ForEach(value => { 
            //var valueDTO=new Models.DTO.WalkDifficulty()
            //{
            //    Id = value.Id,
            //    Code = value.Code,
            //};
            //    valuesDTO.Add(valueDTO);
            //});
            var ValuesDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(value);
            return Ok(ValuesDTO);
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        [ActionName("getAllWalkDifficultyAsync")]
        public async Task<IActionResult> getAllWalkDifficultyAsync(Guid Id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAllDifficultyAsync(Id);
            if(walkDifficulty == null)
            {
                return NotFound();
            }
            var Result = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(Result);
        }
        [HttpPost]
        public async Task<IActionResult> AddWalkDificultyData(Models.DTO.AddRequestWalkDifficulty addRequestWalkDifficulty)
        {
            //Request Dto to Domain Models
            var WalkDificultyData = new Models.Domain.WalkDifficulty
            {
                Code = addRequestWalkDifficulty.Code,
            };
            //Pass Details to Repository   
            WalkDificultyData = await walkDifficultyRepository.AddDifficultyAsync(WalkDificultyData);

            //convert back to DTO
            var WalkDificultyDTO = new Models.Domain.WalkDifficulty
            {
                Id= WalkDificultyData.Id,
               Code = WalkDificultyData.Code,
            };
            return AcceptedAtAction(nameof(getAllWalkDifficultyAsync), new { Id = WalkDificultyDTO.Id }, WalkDificultyDTO);
            
        }
    }
}
