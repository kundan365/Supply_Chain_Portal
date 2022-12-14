using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supply_Chain_Portal.Repositories;

namespace Supply_Chain_Portal.Controllers
{
    [ApiController]
    [Route("ProductDetails")]
    public class ProductInfoController : Controller
    {
        private readonly IProductInfoRepository productInfoRepository;
        private readonly IMapper mapper;

        public ProductInfoController(IProductInfoRepository productInfoRepository,IMapper mapper)
        {
            this.productInfoRepository = productInfoRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        {
            var values=await productInfoRepository.GetProductsDetailsAsync();

            //return DTO Models
            //var valuesDTO = new List<Models.DTO.ProductDetails>();
            //values.ToList().ForEach(values =>
            //{
            //    var valueDTO = new Models.DTO.ProductDetails()
            //    {
            //        Id = values.Id,
            //        PartNumber = values.PartNumber,
            //        BoardNumber = values.BoardNumber,
            //        ProductType = values.ProductType,
            //        ProductName = values.ProductName,
            //        Price = values.Price,
            //    };
            //    valuesDTO.Add(valueDTO);
            //});
            var valuesDTO = mapper.Map<List<Models.DTO.ProductDetails>>(values);
            return Ok(valuesDTO);
        }
             
    }
}
