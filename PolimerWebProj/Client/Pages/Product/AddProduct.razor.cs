using MudBlazor;
using PolimerWebProj.Shared.Dto.Image;
using PolimerWebProj.Shared.Dto.Produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.Product
{
    public partial class AddProduct
    {
        public ProductDto ProductDto = new();
        public List<ImageDto> ImageDtoList = new();

        protected override async Task OnInitializedAsync()
        {
            ImageDtoList = await _httpRequestHandler.GetListData<ImageDto>("image_file_handler/get_image_list_handler");
        }

        public async Task OnValidSubmit()
        {
            var result = await _httpRequestHandler.PostAsHttpJsonAsync(ProductDto, "product_handler/add_product_handler");

            if (result)
            {
                _snackbar.Add("Product Added Successfully", Severity.Success);
            }
            else
            {
                _snackbar.Add("Operation Failed", Severity.Error);
            }
        }
    }
}
