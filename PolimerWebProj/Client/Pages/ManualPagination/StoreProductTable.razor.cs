using Microsoft.AspNetCore.Components;
using PolimerWebProj.Shared.Dto.Produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.ManualPagination
{
    public partial class StoreProductTable
    {

        [Parameter]
        public List<ProductDto> ProductDtos { get; set; }

        public async Task GetProductDetail(int Id)
        {
            NavigationManager.NavigateTo($"product_store_detail/{Id}");
        }
    }
}
