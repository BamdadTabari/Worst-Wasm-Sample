using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Dto.Produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.WhatUserSee
{
    public partial class StorePage
    {
        public List<ProductDto> productDtos { get; set; } = new();
        public MetaData MetaData = new();
        private PagingParameters _pagingParameters = new();

        protected async override Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task SelectedPage(int page)
        {
            _pagingParameters.PageNumber = page;
            await GetProducts();
        }

        public async Task GetProducts()
        {
            var pagingResponse = await _httpRequestHandler.GetPagedProducts(_pagingParameters, "user_vision_store/get_products_paged");
            productDtos = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
    }
}
