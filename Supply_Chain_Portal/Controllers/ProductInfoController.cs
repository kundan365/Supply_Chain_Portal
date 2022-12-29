using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Supply_Chain_Portal.Models.Domain;
using Supply_Chain_Portal.Models.DTO;
using Supply_Chain_Portal.Repositories;

namespace Supply_Chain_Portal.Controllers
{
    [ApiController]
    [Route("ProductDetails")]
    public class ProductInfoController : Controller
    {
        private readonly IProductInfoRepository productInfoRepository;
        private readonly IMapper mapper;

        public ProductInfoController(IProductInfoRepository productInfoRepository, IMapper mapper)
        {
            this.productInfoRepository = productInfoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        {
            var values = await productInfoRepository.GetProductsDetailsAsync();

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

        [HttpGet]
        [Route("{Id:int}")]
        [ActionName("GetAllProductAsync")]
        public async Task<IActionResult> GetAllProductAsync(int Id)
        {
            var values = await productInfoRepository.GetAllProductAsync(Id);
            if (values == null)
            {
                return NotFound();
            }
            var ProductDTO = mapper.Map<Models.DTO.ProductDetails>(values);
            return Ok(ProductDTO);
        }

        [HttpPost]
        //Request Dto to Domain Models
        public async Task<IActionResult> AddAllProductAsync(Models.DTO.ProductDetails productDetails)
        {
            //validate Code
            if (!ValidateAddAllProductAsync(productDetails))
            {
                return BadRequest(ModelState);
            }

            var ProductData = new Models.Domain.ProductDetails()
            {
                Id = productDetails.Id,
                ProductName = productDetails.ProductName,
                PartNumber = productDetails.PartNumber,
                ProductType = productDetails.ProductType,
                BoardNumber = productDetails.BoardNumber,
                Price = productDetails.Price,
            };


            //Pass Details to Repository   
            ProductData = await productInfoRepository.AddProductDetailsAsync(ProductData);

            //convert back to DTO
            var ProductDTO = new Models.DTO.ProductDetails()
            {
                Id = productDetails.Id,
                ProductName = productDetails.ProductName,
                PartNumber = productDetails.PartNumber,
                ProductType = productDetails.ProductType,
                BoardNumber = productDetails.BoardNumber,
                Price = productDetails.Price,
            };
            return CreatedAtAction(nameof(GetAllProductAsync), new { Id = ProductDTO.Id }, ProductDTO);
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateAllProductDeatailsAsync([FromRoute] int Id, [FromBody] Models.DTO.UpdateRequestProductDetails updateRequestProductDetails)
        {
            // validate Update Code
            if(!ValidateUpdateAllProductDeatailsAsync(updateRequestProductDetails))
            {
                return BadRequest(ModelState);
            }
            //Convert DTO to Domain models

            var product = new Models.Domain.ProductDetails()
            {
                ProductName = updateRequestProductDetails.ProductName,
                PartNumber = updateRequestProductDetails.PartNumber,
                ProductType = updateRequestProductDetails.ProductType,
                BoardNumber = updateRequestProductDetails.BoardNumber,
                Price = updateRequestProductDetails.Price,
            };

            //Update Product details using repository

            product = await productInfoRepository.UpdateProductDetailsAsync(Id, product);

            //if Null then Not found
            if (product == null)
            {
                return NotFound();
            }
            //Convert Domain Back To DTO
            var ProductDTO = new Models.DTO.ProductDetails()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                PartNumber = product.PartNumber,
                ProductType = product.ProductType,
                BoardNumber = product.BoardNumber,
                Price = updateRequestProductDetails.Price,
            };
            //return Ok Response
            return Ok(ProductDTO);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetDeleteProductDetails(int Id)
        {
            var values = await productInfoRepository.DeleteProductDetailsAsync(Id);
            if (values == null)
            {
                return NotFound();
            }
            var valueDTO = mapper.Map<Models.DTO.ProductDetails>(values);
            return Ok(valueDTO);
        }

       
        
        
        #region validate ProductInfo Private Method
        private bool ValidateAddAllProductAsync(Models.DTO.ProductDetails productDetails)
        {
            if (productDetails == null)
            {
                ModelState.AddModelError(nameof(productDetails), $"Add Region Data is required");
                return false;
            }
            if (string.IsNullOrWhiteSpace(productDetails.ProductName))
            {
                ModelState.AddModelError(nameof(productDetails.ProductName), $"{nameof(productDetails.ProductName)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(productDetails.PartNumber))
            {
                ModelState.AddModelError(nameof(productDetails.PartNumber), $"{nameof(productDetails.PartNumber)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(productDetails.ProductType))
            {
                ModelState.AddModelError(nameof(productDetails.ProductType), $"{nameof(productDetails.ProductType)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(productDetails.BoardNumber))
            {
                ModelState.AddModelError(nameof(productDetails.BoardNumber), $"{nameof(productDetails.BoardNumber)} can't null or empty or white Space");
            }
            if (productDetails.Price <= 0)
            {
                ModelState.AddModelError(nameof(productDetails.Price), $"{nameof(productDetails.Price)} can't equal to Zero or less than Zero");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }

        private bool ValidateUpdateAllProductDeatailsAsync(Models.DTO.UpdateRequestProductDetails updateRequestProductDetails)
        {
            if (updateRequestProductDetails == null)
            {
                ModelState.AddModelError(nameof(updateRequestProductDetails), $"Add Region Data is required");
                return false;
            }
            if (string.IsNullOrWhiteSpace(updateRequestProductDetails.ProductName))
            {
                ModelState.AddModelError(nameof(updateRequestProductDetails.ProductName), $"{nameof(updateRequestProductDetails.ProductName)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(updateRequestProductDetails.PartNumber))
            {
                ModelState.AddModelError(nameof(updateRequestProductDetails.PartNumber), $"{nameof(updateRequestProductDetails.PartNumber)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(updateRequestProductDetails.ProductType))
            {
                ModelState.AddModelError(nameof(updateRequestProductDetails.ProductType), $"{nameof(updateRequestProductDetails.ProductType)} can't null or empty or white Space");
            }
            if (string.IsNullOrWhiteSpace(updateRequestProductDetails.BoardNumber))
            {
                ModelState.AddModelError(nameof(updateRequestProductDetails.BoardNumber), $"{nameof(updateRequestProductDetails.BoardNumber)} can't null or empty or white Space");
            }
            if (updateRequestProductDetails.Price <= 0)
            {
                ModelState.AddModelError(nameof(updateRequestProductDetails.Price), $"{nameof(updateRequestProductDetails.Price)} can't equal to Zero or less than Zero");
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
