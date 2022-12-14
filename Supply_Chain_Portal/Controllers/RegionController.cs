using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supply_Chain_Portal.Models.Domain;
using Supply_Chain_Portal.Models.DTO;
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
        public async Task<IActionResult> getAllRegionAsync()
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
        
        [HttpGet]
        [Route("{Id:Guid}")]
        [ActionName("getRegionDetailsAsync")]
        public async Task<IActionResult> getRegionDetailsAsync(Guid Id)
        {
            var values=await resionRepository.GetRegionAsync(Id);
            if(values==null)
            {
                return NotFound();
            }
            var RegionDTO= mapper.Map<Models.DTO.Region>(values);
            return Ok(RegionDTO);
        }
       
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddReguestRegion addReguestRegion)
        {

            //validate data
            //if(!validateAddRegionAsync(addReguestRegion))
            //{
            //    return BadRequest(ModelState);
            //}
            //Request Dto to Domain Models
            var regionData = new Models.Domain.Region()
            {
                Name = addReguestRegion.Name,
                Code = addReguestRegion.Code,
                Area = addReguestRegion.Area,
                Lat = addReguestRegion.Lat,
                Long = addReguestRegion.Long,
                Population = addReguestRegion.Population
            };

            //Pass Details to Repository    
         regionData=  await resionRepository.AddRegionDataAsync(regionData);

            //convert back to DTO
            var regionDTO = new Models.DTO.Region()
            {
                Id = regionData.Id,
                Name = regionData.Name,
                Code = regionData.Code,
                Area = regionData.Area,
                Lat = regionData.Lat,
                Long = regionData.Long,
                Population = regionData.Population
            };
            return CreatedAtAction(nameof(getRegionDetailsAsync),new {Id= regionDTO.Id}, regionDTO);

        }
       
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid Id,[FromBody]  Models.DTO.UpdateRequestRegion updateRequestRegion)
        {
            //validate Code
            //if(!validateUpdateRegionAsync(updateRequestRegion))
            //{
            //    return BadRequest(ModelState);
            //}
            //Convert DTO to Domain models
            var region = new Models.Domain.Region()
            {
                Name= updateRequestRegion.Name,
                Code= updateRequestRegion.Code,
                Area= updateRequestRegion.Area,
                Lat= updateRequestRegion.Lat,
                Long= updateRequestRegion.Long,
                Population= updateRequestRegion.Population
            };
            //Update Product details using repository
            region = await resionRepository.UpdateRegionDataAsync(Id, region);


            //if Null then Not found
            if (region == null)
            {
                return NotFound();
            }
            //Convert Domain Back To DTO
            var resionDTO = new Models.DTO.Region()
            {
                Id= region.Id,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };
            return Ok(resionDTO);

        }
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteRegionByIdAync(Guid Id)
        {
            var region=await resionRepository.DeleteRegionDataAsync(Id);
            if(region == null)
            {
                return NotFound();
            }
            var regionDTO= mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }
       
        #region Validate Region private Method
       private bool validateAddRegionAsync(Models.DTO.AddReguestRegion addReguestRegion)
        {
            if(addReguestRegion==null)
            {
                ModelState.AddModelError(nameof(addReguestRegion), $"Add Region Data is required");
                return false;
            }
            if(string.IsNullOrWhiteSpace(addReguestRegion.Code))
            {
                ModelState.AddModelError(nameof(addReguestRegion.Code), $"{nameof(addReguestRegion.Code)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(addReguestRegion.Name))
            {
                ModelState.AddModelError(nameof(addReguestRegion.Name), $"{nameof(addReguestRegion.Code)} can't null or empty or white Space");
            }
            if (addReguestRegion.Area<=0)
            {
                ModelState.AddModelError(nameof(addReguestRegion.Area), $"{nameof(addReguestRegion.Area)} can't less than or Equal to Zero");
            }
            if (addReguestRegion.Lat <= 0)
            {
                ModelState.AddModelError(nameof(addReguestRegion.Lat), $"{nameof(addReguestRegion.Lat)} can't less than or Equal to Zero");
            }
            if (addReguestRegion.Long <= 0)
            {
                ModelState.AddModelError(nameof(addReguestRegion.Long), $"{nameof(addReguestRegion.Long)} can't less than or Equal to Zero");
            }
            if (addReguestRegion.Population < 0)
            {
                ModelState.AddModelError(nameof(addReguestRegion.Population), $"{nameof(addReguestRegion.Population)} can't less than Zero");
            }
            if(ModelState.Count > 0)
            {
                return false;
            }
            return true;
        }

       private bool validateUpdateRegionAsync(Models.DTO.UpdateRequestRegion updateRequestRegion)
        {
            if (updateRequestRegion == null)
            {
                ModelState.AddModelError(nameof(updateRequestRegion), $"Add Region Data is required");
                return false;
            }
            if (string.IsNullOrWhiteSpace(updateRequestRegion.Code))
            {
                ModelState.AddModelError(nameof(updateRequestRegion.Code), $"{nameof(updateRequestRegion.Code)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(updateRequestRegion.Name))
            {
                ModelState.AddModelError(nameof(updateRequestRegion.Name), $"{nameof(updateRequestRegion.Code)} can't null or empty or white Space");
            }
            if (updateRequestRegion.Area <= 0)
            {
                ModelState.AddModelError(nameof(updateRequestRegion.Area), $"{nameof(updateRequestRegion.Area)} can't less than or Equal to Zero");
            }
            if (updateRequestRegion.Lat <= 0)
            {
                ModelState.AddModelError(nameof(updateRequestRegion.Lat), $"{nameof(updateRequestRegion.Lat)} can't less than or Equal to Zero");
            }
            if (updateRequestRegion.Long <= 0)
            {
                ModelState.AddModelError(nameof(updateRequestRegion.Long), $"{nameof(updateRequestRegion.Long)} can't less than or Equal to Zero");
            }
            if (updateRequestRegion.Population < 0)
            {
                ModelState.AddModelError(nameof(updateRequestRegion.Population), $"{nameof(updateRequestRegion.Population)} can't less than Zero");
            }
            if (ModelState.Count > 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }


}

