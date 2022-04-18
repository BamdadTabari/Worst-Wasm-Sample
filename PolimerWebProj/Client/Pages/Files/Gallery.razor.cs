using PolimerWebProj.Shared.Dto.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.Files
{
    public partial class Gallery
    {
        public List<ImageDto> ImageDtoList = new();

        protected override async Task OnInitializedAsync()
        {
            ImageDtoList = await GetImageList();
        }

        public async Task<List<ImageDto>> GetImageList()
        {
            return await _httpRequestHandler.GetListData<ImageDto>("image_file_handler/get_image_list_handler");
        }

        public async Task OnChange()
        {
            ImageDtoList = await GetImageList();
        }
    }
}
