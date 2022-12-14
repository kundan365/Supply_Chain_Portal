using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supply_Chain_Portal.Models.Domain;
using Supply_Chain_Portal.Repositories;

namespace Supply_Chain_Portal.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionController : Controller
    {
        private readonly IResionRepository resionRepository;
        private readonly IMapper mapper;

        public RegionController(IResionRepository resionRepository,IMapper mapper)
        {
            this.resionRepository = resionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllRegion()
        {

            //var regions = new List<Region>()
            //{
            //    new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Kundan",
            //        Code="101",
            //        Area=2.5,
            //        Lat=1.4563,
            //        Long=399.488,
            //        Population=374755,
            //    },
            //};
            var regions = await resionRepository.GetAllAsync();

            //return DTO Models
            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(regions =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = regions.Id,
            //        Name = regions.Name,
            //        Code = regions.Code,
            //        Area = regions.Area,
            //        Lat = regions.Lat,
            //        Long = regions.Long,
            //        Population = regions.Population,
            //    };
            //    regionsDTO.Add(regionDTO);
            //});
            var regionsDTO=mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }
           
    }
}

