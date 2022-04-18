using Microsoft.AspNetCore.Components;
using MudBlazor;
using PolimerWebProj.Shared.Dto.Image;
using PolimerWebProj.Shared.Dto.Produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.Product
{
    public partial class EditProductPage
    {
        [Parameter]
        public int productId { get; set; }
        public ProductDto ProductDto = new();
        public List<ImageDto> ImageDtoList = new();

        protected override async Task OnParametersSetAsync()
        {
            ImageDtoList = await _httpRequestHandler.GetListData<ImageDto>("image_file_handler/get_image_list_handler");
            ProductDto = await _httpRequestHandler.GetById<ProductDto>(productId, "product_handler/get_product_handler");
        }

        public async Task OnValidSubmit()
        {
            var result = await _httpRequestHandler.UpdateByDto(ProductDto, "product_handler/update_product_handler");

            if (result)
            {
                _snackbar.Add("Product Updated Successfully", Severity.Success);
            }
            else
            {
                _snackbar.Add("Operation Failed", Severity.Success);
            }
        }
    }
}
