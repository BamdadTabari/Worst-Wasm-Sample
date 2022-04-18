using Microsoft.AspNetCore.Components;
using PolimerWebProj.Shared.Dto.Produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.WhatUserSee
{
    public partial class ProductUserView
    {
        [Parameter]
        public int productId { get; set; }
        public ProductDto ProductDto = new();

        protected override async Task OnParametersSetAsync()
        {
            ProductDto = await _httpRequestHandler.GetById<ProductDto>(productId, "user_vision_store/get_product_handler");
        }
    }
}
