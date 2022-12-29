using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supply_Chain_Portal.Models.DTO;
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
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var Result = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(Result);
        }


        [HttpPost]
        public async Task<IActionResult> AddWalkDificultyData(Models.DTO.AddRequestWalkDifficulty addRequestWalkDifficulty)
        {
            //validate Code
            //if(!ValidateAddWalkDificultyData(addRequestWalkDifficulty))
            //{
            //    return NotFound(ModelState);
            //}
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
                Id = WalkDificultyData.Id,
                Code = WalkDificultyData.Code,
            };
            return AcceptedAtAction(nameof(getAllWalkDifficultyAsync), new { Id = WalkDificultyDTO.Id }, WalkDificultyDTO);

        }


        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid Id, [FromBody] Models.DTO.UpdateRequestWalkDifficulty updateRequestWalkDifficulty)
        {
            //validate Code
            //if (!ValidateUpdateWalkDifficulty(updateRequestWalkDifficulty))
            //{
            //    return NotFound(ModelState);
            //}
            //Convert DTO to Domain models
            var Walkdiffi = new Models.Domain.WalkDifficulty()
            {
                Code = updateRequestWalkDifficulty.Code,
            };
            //Update WalkDifficulty details using repository
            Walkdiffi = await walkDifficultyRepository.UpdatewalkDifficultyAsync(Id, Walkdiffi);

            //if Null then Not found
            if (Walkdiffi == null)
            {
                return NotFound();
            }
            //Convert Domain Back to DTO
            var WalkdiffiDTO = new Models.DTO.WalkDifficulty()
            {
                Id = Walkdiffi.Id,
                Code = Walkdiffi.Code
            };
            return Ok(WalkdiffiDTO);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteWlakDifficultyById(Guid Id)
        {
            var WalkDiff = await walkDifficultyRepository.DeleteDifficultyAsync(Id);
            if (WalkDiff == null)
            {
                return NotFound();
            }
            var WalkDiffDTO = mapper.Map<Models.Domain.WalkDifficulty>(WalkDiff);
            return Ok(WalkDiffDTO);
        }
        #region validate code Private method
        private bool ValidateAddWalkDificultyData(Models.DTO.AddRequestWalkDifficulty addRequestWalkDifficulty)
        {
            if (addRequestWalkDifficulty == null)
            {
                ModelState.AddModelError(nameof(addRequestWalkDifficulty), $"{nameof(addRequestWalkDifficulty)} can't be empty ");
                return false;
            }
            if (string.IsNullOrWhiteSpace(addRequestWalkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(addRequestWalkDifficulty.Code), $"{nameof(addRequestWalkDifficulty.Code)} can't null or empty or white Space");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;

        }
        private bool ValidateUpdateWalkDifficulty(Models.DTO.UpdateRequestWalkDifficulty updateRequestWalkDifficulty)
        {
            if (updateRequestWalkDifficulty == null)
            {
                ModelState.AddModelError(nameof(updateRequestWalkDifficulty), $"{nameof(updateRequestWalkDifficulty)} can't be empty ");
                return false;
            }
            if (string.IsNullOrWhiteSpace(updateRequestWalkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(updateRequestWalkDifficulty.Code), $"{nameof(updateRequestWalkDifficulty.Code)} can't null or empty or white Space");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;

        }
        
        #endregion
    }
}


