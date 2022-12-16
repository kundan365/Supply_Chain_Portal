using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Supply_Chain_Portal.Models.DTO;
using Supply_Chain_Portal.Repositories;

namespace Supply_Chain_Portal.Controllers
{
    [ApiController]
    [Route("Walk")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var values = await walkRepository.GetWalksAsync();

            //return DTO Models
            //var valuesDTO = new List<Models.DTO.Walk>();
            //values.ToList().ForEach(values => { 
            //var valueDTO=new Models.DTO.Walk()
            //{
            //    Id = values.Id,
            //    Name = values.Name,
            //    Length = values.Length,
            //};
            //    valuesDTO.Add(valueDTO);
            //});
            var valuesDTO = mapper.Map<List<Models.DTO.Walk>>(values);
            return Ok(valuesDTO);
        }
        
        [HttpGet]
        [Route("{Id:Guid}")]
        [ActionName("GetAllWalksByIdAsync")]
        public async Task<IActionResult> GetAllWalksByIdAsync(Guid Id)
        {
            var WalkResult = await walkRepository.GetWalkByIdAsync(Id);
            if (WalkResult == null)
            {
                return NotFound();
            }
            var WalkDTO = mapper.Map<Models.DTO.Walk>(WalkResult);
            return Ok(WalkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Models.DTO.AddRequestWalk addRequestWalk)
        {
            //Convert DTO to Domain Object
            var WalkValue = new Models.Domain.Walk
            {
                Name = addRequestWalk.Name,
                Length = addRequestWalk.Length,
                WalkDifficultyId = addRequestWalk.WalkDifficultyId,
                RegionId = addRequestWalk.RegionId,
            };
            //pass Domain object to repository
            WalkValue = await walkRepository.AddWalksAsync(WalkValue);
            //convert back to Dto model object
            var WalkDto = new Models.DTO.Walk
            {
                Id = WalkValue.Id,
                Name = WalkValue.Name,
                Length = WalkValue.Length,
                WalkDifficultyId = WalkValue.WalkDifficultyId,
                RegionId = WalkValue.RegionId,
            };
            //SEND dTO TO RESPONSE BACK 
            return CreatedAtAction(nameof(GetAllWalksByIdAsync), new { Id = WalkDto.Id }, WalkDto);

        }
       
        [HttpPut]
        [Route("{Id:Guid}")]
       
        public async Task<IActionResult> UpdateWalkAsync([FromRoute]Guid Id,[FromBody]Models.DTO.UpdateRequestWalk updateRequestWalk)
        {

            //Convert DTO to Domain Object
            var WalkValue = new Models.Domain.Walk
            {
                Name = updateRequestWalk.Name,
                Length = updateRequestWalk.Length,
                WalkDifficultyId = updateRequestWalk.WalkDifficultyId,
                RegionId = updateRequestWalk.RegionId,
            };
            //pass Domain object to repository

            WalkValue = await walkRepository.UpdatewalksAsync(Id,WalkValue);
            
            //handle null not found
            if(WalkValue == null)
            {
                return NotFound();
            }
            //Convert Domain to DTO Object
            var WalkValueDTO = new Models.DTO.Walk
            {
                Id = WalkValue.Id,
                Name = WalkValue.Name,
                Length = WalkValue.Length,
                RegionId = WalkValue.RegionId,
                WalkDifficultyId = WalkValue.WalkDifficultyId,
            };
            return Ok(WalkValueDTO);
        }
        [HttpDelete]
       
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteWalksAsync(Guid Id)
        {
           var ExistwalkData=await walkRepository.DeletewalkAsync(Id);
            if(ExistwalkData == null)
            {
                return NotFound();
            }
            var WalksDTO=mapper.Map<Models.DTO.Walk>(ExistwalkData);
            return Ok(WalksDTO);    
        }
    }
}
