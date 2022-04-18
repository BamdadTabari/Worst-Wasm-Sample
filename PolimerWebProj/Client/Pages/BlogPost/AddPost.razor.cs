using MudBlazor;
using PolimerWebProj.Shared.Dto.BlogPost;
using PolimerWebProj.Shared.Dto.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.BlogPost
{
    public partial class AddPost
    {
        public BlogPostDto BlogPostDto = new();
        public List<ImageDto> ImageDtoList = new();

        protected override async Task OnInitializedAsync()
        {
            ImageDtoList = await _httpRequestHandler.GetListData<ImageDto>("image_file_handler/get_image_list_handler");
        }

        public async Task OnValidSubmit()
        {
            var result = await _httpRequestHandler.PostAsHttpJsonAsync(BlogPostDto, "blog_post_handler/add_blog_post_handler");

            if (result)
            {
                _snackbar.Add("Post Added Successfully", Severity.Success);
            }
            else
            {
                _snackbar.Add("Operation Faild", Severity.Error);
            }
        }

    }
}
