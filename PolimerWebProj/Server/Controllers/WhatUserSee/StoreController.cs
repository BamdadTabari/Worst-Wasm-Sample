using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Repository.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Server.Controllers.WhatUserSee
{
    [Route("user_vision_store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public StoreController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [Route("get_products_paged")]
        public async Task<IActionResult> GetStoreProducts([FromQuery] PagingParameters pagingParameters)
        {
            var result = await _productRepo.GetPagedProducts(pagingParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet]
        [Route("get_product_handler/{Id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int Id)
        {
            var result = await _productRepo.GetProductByIdAsync(Id);
            return Ok(result);
        }
    }
}
