using Microsoft.AspNetCore.Components;
using MudBlazor;
using PolimerWebProj.Shared.Dto.BlogPost;
using PolimerWebProj.Shared.Dto.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.BlogPost
{
    public partial class EditPostPage
    {
        #region prop's

        [Parameter]
        public int postId { get; set; }

        public BlogPostDto BlogPostDto = new();

        public List<ImageDto> ImageDtoList = new();

        #endregion

        protected override async Task OnInitializedAsync()
        {
            BlogPostDto = await _httpRequestHandler.GetById<BlogPostDto>(postId, "blog_post_handler/get_blog_post_handler");
            ImageDtoList = await _httpRequestHandler.GetListData<ImageDto>("image_file_handler/get_image_list_handler");
        }

        public async Task OnValidSubmit()
        {
            var result = await _httpRequestHandler.UpdateByDto(BlogPostDto, "blog_post_handler/update_blog_post_handler");

            if (result)
            {
                _snackbar.Add("Post Edited Successfully", Severity.Success);
            }
            else
            {
                _snackbar.Add("Operation Faild", Severity.Error);
            }
        }
    }
}
