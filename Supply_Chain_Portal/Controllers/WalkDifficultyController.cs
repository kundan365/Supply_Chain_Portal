using Microsoft.AspNetCore.Mvc;
using Supply_Chain_Portal.Repositories;

namespace Supply_Chain_Portal.Controllers
{
    [ApiController]
    [Route("WalkDifficulty")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository)
        {
           
            this.walkDifficultyRepository = walkDifficultyRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getWalkDifficulty()
        {
            var value= await walkDifficultyRepository.GetDifficultyAsync();

            //return DTO Models
            var valuesDTO =new List<Models.DTO.WalkDifficulty>();
              value.ToList().ForEach(value => { 
            var valueDTO=new Models.DTO.WalkDifficulty()
            {
                Id = value.Id,
                Code = value.Code,
            };
                valuesDTO.Add(valueDTO);
            });

            return Ok(valuesDTO);
        }
    }
}
