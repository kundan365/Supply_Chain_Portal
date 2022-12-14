using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Supply_Chain_Portal.Repositories;

namespace Supply_Chain_Portal.Controllers
{
    [ApiController]
    [Route("Walk")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
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
            var valuesDTO=mapper.Map<List<Models.DTO.Walk>>(values);
            return Ok(valuesDTO);
        }
    }
}
