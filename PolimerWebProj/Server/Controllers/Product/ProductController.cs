using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Dto.Produt;
using PolimerWebProj.Shared.Repository.Image;
using PolimerWebProj.Shared.Repository.Product;
using System.Threading.Tasks;

namespace PolimerWebProj.Server.Controllers.Product
{
    [Route("product_handler")]
    [ApiController]
    [Authorize(Roles = "Adminstrator")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IImageRepo _imageRepo;

        public ProductController(IProductRepo productRepo, IImageRepo imageRepo)
        {
            _productRepo = productRepo;
            _imageRepo = imageRepo;
        }

        [HttpPost]
        [Route("add_product_handler")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var image = await _imageRepo.GetImageById(productDto.ProductImageId);
            productDto.ProductImageAlt = image.Alt;
            productDto.ProductImageAddress = image.Path;
            var result = await _productRepo.AddProductAsync(productDto);
            return Created("", result);
        }

        [HttpGet]
        [Route("get_paged_Product_handler")]
        public async Task<IActionResult> GetPagedProducts([FromQuery] PagingParameters pagingParameters)
        {
            var result = await _productRepo.GetPagedProducts(pagingParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet]
        [Route("get_product_handler/{productId}")]
        public async Task<IActionResult> GetProduct([FromRoute] int productId)
        {
            var result = await _productRepo.GetProductByIdAsync(productId);
            return Ok(result);
        }

        [HttpPut]
        [Route("update_product_handler")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            var result = await _productRepo.UpdateProductAsync(productDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete_product_handler/{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var result = await _productRepo.DeleteProductByIdAsync(productId);
            return Ok(result);
        }
    }
}
